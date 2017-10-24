# By NiuXuan(ZuoMu) QQ:79069622

import socket
import Image
#from VideoCapture import Device  
import time, string
import struct
import threading
import cv
import pygame,pygame.camera

class MyCam(threading.Thread):

    def __init__(self, sock,ip, interval, port,sizemode):
        sizes = ((160,120),(320,240))
        threading.Thread.__init__(self)
        self.size = sizes[sizemode]
        self.ip = ip
        self.port = port
        self.interval = interval  
        self.thread_stop = False
        self.sock = sock
		
        pygame.camera.init()
        self.cam = pygame.camera.Camera('/dev/video0', self.size ,"RGB")
        self.cam.start()
        
    def run(self):
        quant = self.interval * .1  
        starttime = time.time()
        s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        while not self.thread_stop:
            #CV
            try:
                if self.cam.query_image() :
                    im = self.cam.get_image()
                    img = Image.fromstring("RGB",self.size ,pygame.image.tostring(im,"RGB"))
                    da = img.tostring(('jpeg'),("RGB"))
                    single = 1450
                    clen = 0
                    alen = len(da)%single>0 and len(da)/single+1 or len(da)/single
                    while clen<=alen:
                        alllen = str(len(da))
                        cIndex = str(clen)
                        if(clen==alen):
                            pack = alllen+"|"+cIndex+"|"+da[clen*single:len(da)-(clen-1)*single]
                        else:
                            pack = alllen+"|"+cIndex+"|"+da[clen*single:clen*single+single]
                        self.sock.sendto(pack,(self.ip,self.port))
                        clen=clen+1
            except Exception,e:
                print '-----------------cam error---------------'
                print e
                pass
            time.sleep(quant)  

    def stop(self):
        self.thread_stop = True
        self.cam.stop()
    
    def send(message,ip):
        s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
        s.sendto(message,(ip,12345))
