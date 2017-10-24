# By NiuXuan(ZuoMu) QQ:79069622

import serial

ser = serial.Serial('/dev/ttyAMA0',9600,timeout=0)
ser.open()

def goUp():
    ser.write("GG 0$");
    ser.flush();
def goDown():
    ser.write("GD 0$");
    ser.flush();
def goLeft():
    ser.write("GL 0$");
    ser.flush();
def goRight():
    ser.write("GR 0$");
    ser.flush();
def goStop():
    ser.write("GS 0$");
    ser.flush();
def c_Up():
    ser.write("CU 0$");
    ser.flush();
def c_Down():
    ser.write("CD 0$");
    ser.flush();
def c_Middle():
    ser.write("CM 0$");
    ser.flush();
def c_Stop():
    ser.write("CS 0$");
    ser.flush();
def d_Up():
    ser.write("DU 0$");
    ser.flush();
def d_Down():
    ser.write("DD 0$");
    ser.flush();
def d_Middle():
    ser.write("DM 0$");
    ser.flush();
def d_Stop():
    ser.write("DS 0$");
    ser.flush();
def l_Up():
    ser.write("LU 0$");
    ser.flush();
def l_Down():
    ser.write("LD 0$");
    ser.flush();
def l_Left():
    ser.write("LL 0$");
    ser.flush();
def l_Right():
    ser.write("LR 0$");
    ser.flush();
def d_ctrl(dgree):
    ser.write("".join(["DC ",str(dgree),"$"]));
    ser.flush();
def c_ctrl(dgree):
    ser.write("".join(["CC ",str(dgree),"$"]));
    ser.flush();
