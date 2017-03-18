#include <Mouse.h>
//for mouse input
const int xAxis = A1;         //analog sensor for X axis  
const int yAxis = A2;         // analog sensor for Y axis
//WAARSCHIJNLIJK ONBRUIKBAAR -> GEBRUIK CODE VAN PROJECT 3 IVM SERIAL COM INPUT

int range = 12;               // output range of X or Y movement
int responseDelay = 2;       // response delay of the mouse, in ms
int threshold = range/4;      // resting threshold
int center = range/2;         // resting position value
int minima[] = {
  1023, 1023};                // actual analogRead minima for {x, y}
int maxima[] = {
  0,0};                       // actual analogRead maxima for {x, y}
int axis[] = {
  xAxis, yAxis};              // pin numbers for {x, y}
int mouseReading[2];          // final mouse readings for {x, y}

//for interrupt pins
#define HORINPUT1 2
#define HORINPUT2 3
//vertical nog

attachInterrupt(digitalPinToInterrupt(OPTOINPUT), ISRreadTime, FALLING);

void setup() {
  Mouse.begin(); //to start mouse communication
  attachInterrupt(digitalPinToInterrupt(OPTOINPUT), MoveHorizontal, FALLING);
  attachInterrupt(digitalPinToInterrupt(OPTOINPUT), MoveHorizontal, RISING);
  //vertical nog
}

void loop() {
}

void MoveHorizontal(){ //interrupt method
// read and scale the two axes:
  int xReading = readAxis(0);
//hoe nog doen
  
  Mouse.move(xReading, 0, 0);
  delay(responseDelay);
}

void MoveVertical(){ //interrupt method
    int yReading = readAxis(1);
    Mouse.move(0, yReading, 0);
    delay(responseDelay);
}

void end(){
   Mouse.end(); //to stop mouse communication
}

/*
  reads an axis (0 or 1 for x or y) and scales the
  analog input range to a range from 0 to <range>
  code from Arduino - MouseMove
*/

int readAxis(int axisNumber) {
  int distance = 0;    // distance from center of the output range

  // read the analog input:
  int reading = analogRead(axis[axisNumber]);

// of the current reading exceeds the max or min for this axis,
// reset the max or min:
  if (reading < minima[axisNumber]) {
    minima[axisNumber] = reading;
  }
  if (reading > maxima[axisNumber]) {
    maxima[axisNumber] = reading;
  }

  // map the reading from the analog input range to the output range:
  reading = map(reading, minima[axisNumber], maxima[axisNumber], 0, range);

 // if the output reading is outside from the
 // rest position threshold,  use it:
  if (abs(reading - center) > threshold) {
    distance = (reading - center);
  }

  // the Y axis needs to be inverted in order to
  // map the movemment correctly:
  if (axisNumber == 1) {
    distance = -distance;
  }

  // return the distance for this axis:
  return distance;
}
