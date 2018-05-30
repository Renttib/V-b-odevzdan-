char znak;
String retezec = "";
int i = 0;
void setup() {

  pinMode(13, OUTPUT);
  Serial.begin(9600);

 
}




void loop() {

   
  while (Serial.available() <= 0) {
  }

  retezec = Serial.readString();

  if (retezec != "")
    Serial.println(retezec);

}



