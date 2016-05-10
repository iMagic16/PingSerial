#include <SoftwareSerial.h>

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  Serial.print("BEGIN POWER ON\n");
  Serial.print("1 for on, 0 for off\n");
  //Set all the pins we need to output pins
  pinMode(13, OUTPUT);
  digitalWrite(13, HIGH); 
}

void loop() {
  // put your main code here, to run repeatedly:
delay(250);


//if (LightsOn == true){
 //         LightsOn = false;
 //         digitalWrite(10, LOW);
//        }
//        else
//        {
//         LightsOn = true;
//        digitalWrite(10, HIGH); 
//}
       
       
if (Serial.available()) {
Serial.print("1 for on, 0 for off");
    //read serial as a character
    String serialIn;
    
    serialIn = Serial.readString();
    
    bool LightsOn;
    //NOTE because the serial is read as "char" and not "int", the read value must be compared to character numbers
    //hence the quotes around the numbers in the case statement
 
    Serial.print("I received: ");
    Serial.println(serialIn);  
    
      if (serialIn == "1"){
        
        digitalWrite(13, HIGH); 
        
             }
             
             else if (serialIn == "0"){
               
               digitalWrite(13, LOW); 
               
             }      
             
  }
}
