# Galaxy Quest

## Overview

This application translates intergalactic numbering systems based on Roman numerals and calculates prices for various commodities.

## Get Started
This application is built on .Net 6, so install it if necessary (link below).

[.Net 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)

1. Clone this repo to your computer
   1. Open the solution in Visual Studio 2022 or JetBrains Rider
   2. In Visual Studio 2022, Click on Debug --> Start Debugging or Start Without Debugging
2. Alternatively, you can compile and run from the command line
   1. In a terminal window, navigate to the folder that contains the **GalaxyQuest.csproj** file
   2. Type `dotnet run` and press Enter

## User Manual
- The lexical structure of the input is essential to running this application correctly
  - To map a roman numeral to it's intergalactic equivalent, the input should be structured as `something is Roman numeral`
  - To set the value of a commodity, the input should be structured as `value1 value2 Commodity is 34 credits`
  - To retrieve the value of the mapped values, the input should be structured as `how much is value1 value2?`
  - To calculate the value of a previously entered commodity, the input should be structured as `how many credits is value value commodity?`
- Any invalid or unrecognized input will return the message "**I have no idea what you are talking about**"
- To exit the application, enter `exit` or simply close the console window

## Sample Input
glob is I  
prok is V  
pish is X  
tegj is L  
glob glob Silver is 34 Credits  
glob prok Gold is 57800 Credits  
pish pish Iron is 3910 Credits  
how much is pish tegj glob glob?  
how many Credits is glob prok Silver?  
how many Credits is glob prok Gold?  
how many Credits is glob prok Iron?  
how much wood could a woodchuck chuck if a woodchuck could chuck wood?

## Sample Output
pish tegj glob glob is 42  
glob prok Silver is 68 Credits  
glob prok Gold is 57800 Credits  
glob prok Iron is 782 Credits  
I have no idea what you are talking about  

## Notes/Assumptions
- Input is not case-sensitive
- Question marks at the end of the sentence are optional
- Any invalid or unrecognized input will return the message "**I have no idea what you are talking about**"