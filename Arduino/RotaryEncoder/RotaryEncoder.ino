/*
 * Code om 2 rotary encoders tegelijk te laten werken
 * Rotary encoders werken met afwisselende blokgolven (als de ene hoog is en de andere laag -> bv. links is optellen)
 * Met de hulp van Mr. Van Weyenberg
 * 4-5 maart 2017
*/

#define ROTARYINPUTPIN1A 2 //rotaryEncoder 1 - pin A
#define ROTARYINPUTPIN2A 3 //rotaryEncoder 2 - pin A

#define ROTARYINPUTPIN1B 4 //rotaryEncoder 1 - pin B
#define ROTARYINPUTPIN2B 5 //rotaryEncoder 2 - pin B

//volatile voor interruptgebruik, om na te kijken of er een interrupt is opgetreden
volatile boolean BOOLROTPIN1A = false; 
volatile boolean BOOLROTPIN2A = false;

//NIET NODIG
volatile boolean BOOLROTPIN1B = false;
volatile boolean BOOLROTPIN2B = false;

//om de links/rechts beweging bij te houden
long teller1 = 0; //rotary1 counter
long teller2 = 0; //rotary2 counter

void setup() {
  Serial.begin(9600);
  //pullup om interne verbindingen met weerstand naar 5V te maken
  pinMode(ROTARYINPUTPIN1A, INPUT_PULLUP);
  pinMode(ROTARYINPUTPIN2A, INPUT_PULLUP);
  
  pinMode(ROTARYINPUTPIN1B, INPUT_PULLUP);
  pinMode(ROTARYINPUTPIN2B, INPUT_PULLUP);

  //klaarmaken van interrupts
  attachInterrupt(digitalPinToInterrupt(ROTARYINPUTPIN1A), ISRRotEncod1A, FALLING);
  attachInterrupt(digitalPinToInterrupt(ROTARYINPUTPIN2A), ISRRotEncod2A, FALLING);
}

void loop()
{
  //Rotary tussen 1A & 1B
  if(BOOLROTPIN1A) //als 1A true
  {
    BOOLROTPIN1A=false; //reset voor de volgende keer
    //lees hier de pin 1B om te zien of je moet optellen of aftellen
    //Linksom is positief, rechtsom is negatief
    if(digitalRead(ROTARYINPUTPIN1B)) //meet of pin 1B hoog of laag is
    {
      teller1++;
    }
    else
    {
      teller1--;
    }
      Serial.println("Encoder1: " + String(teller1));  //geformateerd in een string, wordt later toch opgevangen in unity
      delay(10); //10 ms delay voor de ontdendering van de encoder (anders teveel metingen na elkaar) en voor kleine draaibewegingen
    }

  //Rotary tussen 2A & 2B
  if(BOOLROTPIN2A)  //als 2A true
  {
    BOOLROTPIN2A=false; //reset voor de volgende keer
    //lees hier de pin 2B om te zien of je moet optellen of aftellen
    //Linksom is positief, rechtsom is negatief
    if(digitalRead(ROTARYINPUTPIN2B)) //meet of pin 2B hoog of laag is
    {
      teller2++;
    }
    else
    {
      teller2--;
    }
      Serial.println("Encoder2: " + String(teller2)); //geformateerd in een string, wordt later toch opgevangen in unity
      delay(10); //10 ms delay voor de ontdendering van de encoder (anders teveel metingen na elkaar) en voor kleine draaibewegingen
  }

  if (teller1 <= -9223372036854775700 || teller 1 >= 9223372036854775700) //om het maximum en minimum van de long teller op te vangen mocht het spel veel aan 1 stuk gespeeld worden (beetje kleiner getal om overloading op te vangen)
  {
    teller1 = 0;
  }

  if (teller2 <= -9223372036854775700 || teller 2 >= 9223372036854775700) //om het maximum en minimum van de long teller op te vangen mocht het spel veel aan 1 stuk gespeeld worden. (beetje kleiner getal om overloading op te vangen)
  {
    teller2 = 0;
  }
}


//INTERRUPTS (interrupt als blokgolf FALLING wordt)
void ISRRotEncod1A(void){ BOOLROTPIN1A = true; } 
void ISRRotEncod2A(void){ BOOLROTPIN2A = true; }
