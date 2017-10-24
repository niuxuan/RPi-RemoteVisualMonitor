# By NiuXuan(ZuoMu) QQ:79069622

import socket
import socketImgThread
#import DistanceThread
import ArduinoRun
import uuid

ip = ""
interal = 0.5
thread1 = None
thread2 = None
#
def main():
    sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    sock.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR,1)
    sock.bind(('0.0.0.0',8888))
    global ip,thread1,vkey,sizemode
    while True:
        
        try:
            buf ,adress = sock.recvfrom(1024)
            print buf
            print adress
            bufary = buf.split(":")
            
            if(bufary[0]=="connect"):
                if(ip==""):
                    ip = adress[0]
                    sizemode = int(bufary[1])
                    vkey = str(uuid.uuid1())
                    sock.sendto("success|"+vkey,adress);
                else:
                    sock.sendto("fail|used by "+ip,adress);
            elif(bufary[0]=="video"):
                if(ip!=""):
                    print ip
                    print adress
                    if(ip==adress[0] and bufary[1]==vkey):
                        
                        sock.sendto("success|video",adress);
                        
                        thread1 = socketImgThread.MyCam(sock, adress[0],interal,adress[1],sizemode)
                        thread1.start()
                    else:
                        sock.sendto("fail|video",adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="dispose"):
                if(ip!=""):
                    print ip
                    print adress
                    if(ip==adress[0]):
                        ip = ""
                        thread1.stop()
                        sock.sendto("success|dispose",adress);
                    else:
                        sock.sendto("fail|dispose",adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="g-up"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.goUp()
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);                                       
            elif(bufary[0]=="g-down"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.goDown()
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="g-left"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.goLeft()
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="g-right"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.goRight()
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="g-stop"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.goStop()
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="c-up"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.c_Up();
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="c-down"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.c_Down();
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="c-m"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.c_Middle();
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="c-s"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.c_Stop();
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="d-up"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.d_Up();
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="d-down"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.d_Down();
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="d-m"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.d_Middle();
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="d-s"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.d_Stop()
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="l-up"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.l_Up()
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="l-down"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.l_Down()
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="l-left"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.l_Left()
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="l-right"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.l_Right()
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="c-c"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.c_ctrl(bufary[1]);
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            elif(bufary[0]=="d-c"):
                if(ip!=""):
                    if(ip==adress[0]):
                        ArduinoRun.d_ctrl(bufary[1]);
                    else:
                        sock.sendto("fail| used by "+ip,adress);
                else:
                    sock.sendto("fail|no run",adress);
            else:
                sock.sendto("unknow",adress);

            print bufary[0]
        except socket.timeout:
            print 'time out'

      
if __name__ == '__main__':
    main()
