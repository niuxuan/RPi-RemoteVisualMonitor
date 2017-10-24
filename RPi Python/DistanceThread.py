# By NiuXuan(ZuoMu) QQ:79069622

import random, sys
import threading,thread
import time
import datetime as dt
import RPi.GPIO as GPIO
import socket
GPIO.setmode(GPIO.BOARD)

#sound GPIO
GPIO.setup(16, GPIO.OUT)
GPIO.setup(18, GPIO.IN)
GPIO.output(16, False)
GPIO.setup(19, GPIO.OUT)
GPIO.setup(21, GPIO.IN)
GPIO.output(19, False)
GPIO.setup(22, GPIO.OUT)
GPIO.setup(24, GPIO.IN)
GPIO.output(22, False)

class Distance(threading.Thread):

    def __init__(self,ip,port):
        threading.Thread.__init__(self)  
        self.ip = ip  
        self.port = port  
        self.thread_stop = False  
        
    def run(self):
        while not self.thread_stop:  
            updis = self.UpDis()
            leftdis = self.LeftDis()
            rightdis = self.RightDis()
            
            s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
            s.sendto(str(updis)+"|"+str(leftdis)+"|"+str(rightdis),(self.ip,self.port))
        
    def stop(self):  
        self.thread_stop = True
    
    def UpDis(self):
        #while True:
        try:
            time.sleep(0.1)
            GPIO.output(16,GPIO.HIGH)
            time.sleep(0.00001)
            GPIO.output(16,GPIO.LOW)
            t1 = time.time()

            upDistance = 0
            while GPIO.input(18) == False:
                if(time.time()-t1>1):
                    t1 = time.time()
                    break
                pass

            while GPIO.input(18):
                pass

            t2 = time.time()

            t3 = t2-t1

            if 0.023529 >t3 >0.000117:
                upDistance = t3*34000/2
                #if(upDistance<25):
                    #print 'Up: %s' % (upDistance)
            elif t3 <0.000117:
                upDistance = 2
            else :
                upDistance = 400
        except:
            upDistance = -1

        return upDistance
        #thread.exit_thread() 

    def LeftDis(self):
        try:
            time.sleep(0.1)

            GPIO.output(19,GPIO.HIGH)
            time.sleep(0.00001)
            GPIO.output(19,GPIO.LOW)
            t1 = time.time()

            leftDistance = 0
            while GPIO.input(21) == False:
                if(time.time()-t1>1):
                    t1 = time.time()
                    break
                pass

            while GPIO.input(21):
                pass

            t2 = time.time()

            t3 = t2-t1

            if 0.023529 >t3 >0.000117:
                leftDistance = t3*34000/2
                #if(leftDistance<25):
                    #print 'Left: %s' % (leftDistance)
            elif t3 <0.000117:
                leftDistance = 2
            else :
                leftDistance = 400
        except:
            leftDistance = -1
        #thread.exit_thread()
        return leftDistance

    def RightDis(self):
        #while True:
        try:
            time.sleep(0.1)

            GPIO.output(22,GPIO.HIGH)
            time.sleep(0.00001)
            GPIO.output(22,GPIO.LOW)
            t1 = time.time()

            rightDistance = 0
            while GPIO.input(24) == False:
                if(time.time()-t1>1):
                    t1 = time.time()
                    break
                pass

            while GPIO.input(24):
                pass

            t2 = time.time()

            t3 = t2-t1

            if 0.023529 >t3 >0.000117:
                rightDistance = t3*34000/2
                #if(rightDistance<25):
                    #print 'Right: %s' % (rightDistance)
            elif t3 <0.000117:
                rightDistance = 2
            else :
                rightDistance = 400
        except:
            rightDistance = -1
            
        #thread.exit_thread()
        return rightDistance
        
