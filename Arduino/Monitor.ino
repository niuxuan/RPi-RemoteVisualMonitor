/*
 * By 左牧 QQ：79069622
 */
 
#include <Servo.h>

int servopin=9;//定义数字接口9 连接舵机信号线
int val;

class Light
{
	public:
	Light(int a)
	{
		PinL = 12;
		PinR = 13;

		pinMode(PinL,OUTPUT); 
		pinMode(PinR,OUTPUT); 
		
		LightOff();
	};

	void LightOn()
	{
		digitalWrite(PinL,HIGH);
		
		digitalWrite(PinR,HIGH);
	};

	void LightOff()
	{
		digitalWrite(PinL,LOW);
		
		digitalWrite(PinR,LOW);
	};

	void LightOnL()
	{
		digitalWrite(PinL,HIGH);
		
		digitalWrite(PinR,LOW);
	};

	void LightOnR()
	{
		digitalWrite(PinL,LOW);
		
		digitalWrite(PinR,HIGH);
	};

	void run(int type)
	{
		switch(type)
		{
		case 1:
			LightOn();
			break;
		case 2:
			LightOnL();
			break;
		case 3:
			LightOnR();
			break;
		case 0:
			LightOff();
			break;
		};
	};

	private:
		int PinL;
		int PinR;
};

Light light1(0);
//电灯控制类
class lightTask{
  public: 
    //构造函数
    lightTask(Light* m){
      light = m;
      isTask = false;
    };
    
    void addTask(int type){
      isTask = true;
      mType = type;
    };
    
    void doTask(){
      if(isTask){
        light->run(mType);
        isTask = false;
      }
    };
    
    void clearTask(){
      isTask = false;
    };
  private:
    Light* light;
    bool isTask;
    int mType;
};

//实例化LED灯
lightTask lTask(&light1);

class DCmotor{
  public: 
    DCmotor(int a){
		PinL1 = 3;
		PinL2 = 4;

		PinR1 = 7;
		PinR2 = 8;

		EnaL = 10;
		EnaR = 11;

		pinMode(PinL1,OUTPUT); 
		pinMode(PinL2,OUTPUT); 
		pinMode(PinR1,OUTPUT); 
		pinMode(PinR2,OUTPUT); 
 
		digitalWrite(PinL1,OUTPUT);
		digitalWrite(PinL2,OUTPUT);
		digitalWrite(PinR1,OUTPUT);
		digitalWrite(PinR2,OUTPUT);
 
		pinMode(EnaL,OUTPUT);
		pinMode(EnaR,OUTPUT);
    };
    
	//前进
    void up()
	{
		analogWrite(EnaL,255);
		
		analogWrite(EnaR,255);

		digitalWrite(PinL2,LOW);
			
		digitalWrite(PinL1,HIGH);

		digitalWrite(PinR2,LOW);
			
		digitalWrite(PinR1,HIGH);
	};

	//左转
	void left()
	{
		analogWrite(EnaL,255);
		
		analogWrite(EnaR,255);

		digitalWrite(PinR2,LOW);
			
		digitalWrite(PinR1,HIGH);

		digitalWrite(PinL2,HIGH);
			
		digitalWrite(PinL1,LOW);
	};

	//右转
	void right()
	{
		analogWrite(EnaL,255);
		
		analogWrite(EnaR,255);

		digitalWrite(PinL2,LOW);
			
		digitalWrite(PinL1,HIGH);

		digitalWrite(PinR2,HIGH);
			
		digitalWrite(PinR1,LOW);
	};

	//后退
	void down()
	{
		analogWrite(EnaL,255);
		
		analogWrite(EnaR,255);

		digitalWrite(PinL2,HIGH);
			
		digitalWrite(PinL1,LOW);

		digitalWrite(PinR2,HIGH);
			
		digitalWrite(PinR1,LOW);
	};
    
	//停
	void stop()
	{
		digitalWrite(PinR2,LOW);
			
		digitalWrite(PinR1,LOW);
			
		digitalWrite(PinL2,LOW);
			
		digitalWrite(PinL1,LOW);

		analogWrite(EnaL,0);
		
		analogWrite(EnaR,0);
	};

	void run(int type)
	{
		switch(type)
		{
			case 1:
				Serial.println("up");
				up();
				break;
			case 2:
				left();
				break;
			case 3:
				down();
				break;
			case 4:
				right();
				break;
			case 0:
				stop();
				break;
		};
	};

  private:
    int PinL1;
    int PinL2;
    int PinR1;
    int PinR2;
    int EnaL;
    int EnaR;
};

DCmotor motor1(0);

//直流电机控制类
class motorTask{
  public: 
    //构造函数,需要传入控制哪个电机
    motorTask(DCmotor* m){
      motor = m;
      isTask = false;
    };
    
    //添加一个动作
    void addTask(int type){
      isTask = true;
      mType = type;
    };
    
    //执行当前预约的动作
    void doTask(){
      if(isTask){
        motor->run(mType);
        isTask = false;
      }
    };
    
    //清除当前预约的动作
    void clearTask(){
      isTask = false;
    };
  private:
    DCmotor* motor;
    bool isTask;
    int mType;
    uint8_t mSpeed;
};

//实例化电机
motorTask mTask(&motor1);

//舵机控制类
class servoTask{
  public:
  //构造函数,需要传入控制哪个舵机
    servoTask(Servo* s, int pin, int degree){
      servo = s;
      servo->write(degree);
      updateTime = millis();
      currentDegree = degree;
      targetDegree = degree;
    };
    
    //添加动作,即需要旋转的目标角度
    void addTask(int degree){
      targetDegree = degree;
    };
    
    //执行动作,向着目标角度转去.
    void doTask(){
      if(currentDegree != targetDegree){
        unsigned long now = millis();
        if(now - updateTime >= 5){
          targetDegree>currentDegree?currentDegree++:currentDegree--;
		  servo->write(currentDegree);;
          updateTime = now;
        }
          
		//servo->write(targetDegree);
		//currentDegree = targetDegree;
      }
    };
    
    //清除当前预约的动作
    void clearTask(){
      targetDegree = currentDegree;
    }
  public:
    Servo* servo;
    int currentDegree;
    int targetDegree;
    unsigned long updateTime;
};

//定义两个舵机,一个控制左右转动,一个控制上下转动
Servo servoUD;  //  servo UD
Servo servoLR;  //  servo LR
//将舵机绑定到自己的舵机控制类上,设定座机的初始位置.
servoTask sTaskLR(&servoUD, 5, 85);
servoTask sTaskUD(&servoLR, 6, 115);

//解析参数
#define max_para_cnt 5
#define max_para_len 16
char para[max_para_cnt][max_para_len];
int paraInt[max_para_cnt];
int pc=0;
int pl=0;
char cmd;
void resolveSerial() {
  while(Serial.available()){
    cmd = Serial.read();
    if( (cmd>='A' && cmd<='Z') || (cmd>='a' && cmd<='z') || (cmd>='0' && cmd<='9') || cmd=='-' || cmd=='.'){
      para[pc][pl] = cmd;
      if(cmd>='0' && cmd<='9'){
        if(paraInt[pc]==9999){
          if(cmd!='0'){
            paraInt[pc]=0-(cmd-'0');
          }
        }
        else {
          paraInt[pc]*=10;
          if(paraInt[pc]>=0)
            paraInt[pc]+=cmd-'0';
          else
            paraInt[pc]-=cmd-'0';
        }
      } else if(cmd == '-'){
        if(paraInt[pc]==0)
          paraInt[pc] = 9999;
        else
          paraInt[pc]*=-1;
      }
      pl++;
    }
    else if(cmd == '$'){
      doPara();
      memset(para,0,sizeof(char)*max_para_cnt*max_para_len);
      memset(paraInt,0,sizeof(paraInt));
      pc = 0;
      pl = 0;
    }
    else {
      if(pl>0){
        pc++;
        if(pc>=max_para_cnt){
          Serial.println("Error : pc too long");
        }
        pl = 0;
      }
    }
  };
}

void output(const char* str, int x){
  Serial.print(str);
  Serial.println(x);
}
void doPara(){
  for(int i=0; i<max_para_cnt; i++)
  {
    if(paraInt[i]==9999)
      paraInt[i] = 0;
  }
  Serial.print("Do para : ");
  //output(para[0],paraInt[1]);
  if(para[0][0]=='G'){  //Go

    if(para[0][1]=='L'){
      mTask.addTask(2);
    }
    else if(para[0][1]=='R'){
      mTask.addTask(4);
    }
	else if(para[0][1]=='G'){
      mTask.addTask(1);
    }
	else if(para[0][1]=='D'){
      mTask.addTask(3);
    }
	else{
      mTask.addTask(0);
    }
  }
  else if(para[0][0]=='D'){  //See
    uint8_t degree = abs(paraInt[1]);
    if(para[0][1]=='U'){//UD
      sTaskUD.addTask(0);
    }
	else if(para[0][1]=='D'){//UD
      sTaskUD.addTask(180);
    }
	else if(para[0][1]=='M'){//UD
		sTaskUD.addTask(115);
		//servoLR.attach(9,0,180);
    }
	else if(para[0][1]=='S'){//UD
		sTaskUD.addTask(sTaskUD.currentDegree);
    }
	else if(para[0][1]=='C'){//UD
      sTaskUD.addTask(degree);
    }
  }
  else if(para[0][0]=='C'){ 
    uint8_t degree = abs(paraInt[1]);
    if(para[0][1]=='U'){
      sTaskLR.addTask(0);
    }
	else if(para[0][1]=='D'){
      sTaskLR.addTask(150);
    }
	else if(para[0][1]=='M'){
		sTaskLR.addTask(60);
		//servoLR.attach(9,0,180);
    }
	else if(para[0][1]=='S'){
		sTaskLR.addTask(sTaskLR.currentDegree);
    }
	else if(para[0][1]=='C'){
      sTaskLR.addTask(degree);
    }
  }
   else if(para[0][0]=='L'){  //LED
		if(para[0][1]=='L'){
		  lTask.addTask(2);
		}
		else if(para[0][1]=='R'){
		  lTask.addTask(3);
		}
		else if(para[0][1]=='U'){
		  lTask.addTask(1);
		}
		else{
		  lTask.addTask(0);
		}
  }
}

void setup()
{
	memset(para,0,sizeof(char)*max_para_cnt*max_para_len);
	memset(paraInt,0,sizeof(paraInt));
  
	Serial.begin(9600);
	
	servoUD.attach(5,0,180);
	servoLR.attach(6,0,120);
}

void loop()
{
	//读取串口输入
  resolveSerial();
  
  mTask.doTask();  
  sTaskUD.doTask();
  sTaskLR.doTask();
  lTask.doTask();
}
