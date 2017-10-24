/*
 * By ���� QQ��79069622
 */
 
#include <Servo.h>

int servopin=9;//�������ֽӿ�9 ���Ӷ���ź���
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
//��ƿ�����
class lightTask{
  public: 
    //���캯��
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

//ʵ����LED��
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
    
	//ǰ��
    void up()
	{
		analogWrite(EnaL,255);
		
		analogWrite(EnaR,255);

		digitalWrite(PinL2,LOW);
			
		digitalWrite(PinL1,HIGH);

		digitalWrite(PinR2,LOW);
			
		digitalWrite(PinR1,HIGH);
	};

	//��ת
	void left()
	{
		analogWrite(EnaL,255);
		
		analogWrite(EnaR,255);

		digitalWrite(PinR2,LOW);
			
		digitalWrite(PinR1,HIGH);

		digitalWrite(PinL2,HIGH);
			
		digitalWrite(PinL1,LOW);
	};

	//��ת
	void right()
	{
		analogWrite(EnaL,255);
		
		analogWrite(EnaR,255);

		digitalWrite(PinL2,LOW);
			
		digitalWrite(PinL1,HIGH);

		digitalWrite(PinR2,HIGH);
			
		digitalWrite(PinR1,LOW);
	};

	//����
	void down()
	{
		analogWrite(EnaL,255);
		
		analogWrite(EnaR,255);

		digitalWrite(PinL2,HIGH);
			
		digitalWrite(PinL1,LOW);

		digitalWrite(PinR2,HIGH);
			
		digitalWrite(PinR1,LOW);
	};
    
	//ͣ
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

//ֱ�����������
class motorTask{
  public: 
    //���캯��,��Ҫ��������ĸ����
    motorTask(DCmotor* m){
      motor = m;
      isTask = false;
    };
    
    //���һ������
    void addTask(int type){
      isTask = true;
      mType = type;
    };
    
    //ִ�е�ǰԤԼ�Ķ���
    void doTask(){
      if(isTask){
        motor->run(mType);
        isTask = false;
      }
    };
    
    //�����ǰԤԼ�Ķ���
    void clearTask(){
      isTask = false;
    };
  private:
    DCmotor* motor;
    bool isTask;
    int mType;
    uint8_t mSpeed;
};

//ʵ�������
motorTask mTask(&motor1);

//���������
class servoTask{
  public:
  //���캯��,��Ҫ��������ĸ����
    servoTask(Servo* s, int pin, int degree){
      servo = s;
      servo->write(degree);
      updateTime = millis();
      currentDegree = degree;
      targetDegree = degree;
    };
    
    //��Ӷ���,����Ҫ��ת��Ŀ��Ƕ�
    void addTask(int degree){
      targetDegree = degree;
    };
    
    //ִ�ж���,����Ŀ��Ƕ�תȥ.
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
    
    //�����ǰԤԼ�Ķ���
    void clearTask(){
      targetDegree = currentDegree;
    }
  public:
    Servo* servo;
    int currentDegree;
    int targetDegree;
    unsigned long updateTime;
};

//�����������,һ����������ת��,һ����������ת��
Servo servoUD;  //  servo UD
Servo servoLR;  //  servo LR
//������󶨵��Լ��Ķ����������,�趨�����ĳ�ʼλ��.
servoTask sTaskLR(&servoUD, 5, 85);
servoTask sTaskUD(&servoLR, 6, 115);

//��������
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
	//��ȡ��������
  resolveSerial();
  
  mTask.doTask();  
  sTaskUD.doTask();
  sTaskLR.doTask();
  lTask.doTask();
}
