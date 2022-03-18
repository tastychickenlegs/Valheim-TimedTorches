# Valheim-TimedTorches_Fix
Original Mod by Gurrlin and found here [TimedTorches Original](https://www.nexusmods.com/valheim/mods/962)
I received Permission from Gurrlin to fix, modify and repost this mod

## Fixed for Valheim Frost Cave Update
Original Mod by Gurrlin all credit goes back to them for creating the mod

Mod dll can be found here [TimeTorches Fixed](https://github.com/tastychickenlegs/Valheim-TimedTorches/releases)

This has been fixed for the Valheim Frost Cave Update  
### This is not my mod and all credit goes back to the original author Gurrlin
I will do my best to answer questions and fix issues.
Client side only mode.

### About the Mod
Tired of having to add resin to the tens or hundreds of torches lighting up your viking village? 
This mod takes care of that by allowing you to set a time-span during which they are always on, 
even if they burned all their fuel. Never let your base go dark again!

### Background
I created this mod because I got tired of having to re-light all the torches in my base from time to time when all I wanted was for it to look pretty in the dark.
Timed Torches allows you to have a global timer for any light source/fireplace that uses fuel.
This means that you can finally have a village full of torches and have it light up every night when the sun sets
and then turn off when it rises in the morning without constantly having to refill them with resin or other fuel sources

### Configuration

- OnTime - Time of day when torches should turn ON. (The default is set to 4.30pm in-game time)
- OffTime - Time of day when torches should turn OFF. (The default is set to 6.30am in-game time)
- AlwaysOnInDarkBiomes - If true, objects listed in AffectedFireplaceSources will always burn in areas that Valheim considers 'always dark'. E.g Mistlands or any biome during a storm.
- AffectedFireplaceSources - List of objects to be affected by the mod (see below for list of supported objects). By default only torches are added.
- AllowAddingFuel - If true, enable adding fuel to torches which will make them burn during daytime as well.
- FuelDurationMultiplier - Multiplies the duration of each fuel added to objects listed in the FuelDurationSources.
- FuelDurationSources - See FuelDurationMultiplier.

Note: If OnTime and OffTime is set to the same value, for example 0 and 0 the fireplaces listed in AffectedFireplaceSources will burn 24/7.

The config file is located in "<GameDirectory>\Bepinex\config" (You need to start the game with the mod installed for the config file to be created).

### List of supported objects:
  
piece_groundtorch  
piece_groundtorch_wood  
piece_groundtorch_green  
piece_brazierceiling01  
piece_walltorch  
hearth  
bonfire  
fire_pit  
piece_jackoturnip  
piece_brazierfloor01 - (New with Frost Caves)

- You should be able to add custom items to this mod in the config.  I have not tested it, but see no reason why it wouldnt work.

### Other

How to find the perfect timer settings for your needs  

The default values are set to work for out base that doesn't get really early sun and not the last rays of the sunset. However, if your base is in a different location you might want to tweak the on and off times.
This is how you go about finding a timing that's right for you!  

Enable the console following the instructions here.﻿  
Create a new world to test on (if you really know what you're doing feel free  
to use it in your existing world, although making a safety copy of it beforehand is always recommended.)  
- When in-game, press f5 to bring up the console.
- Enter devcommands in the console and you should get a message telling you that it worked.
- In the console enter tod followed by a number between 0 and 1, for example, 0.5. This will set the Time Of Day to your given number. 
- Repeat this until you find a number for when you want the timer to turn on and one for when it turns off and apply these to the config file.
- (to reset to the default time enter tod -1)



### Installation (manual)  
Extract DLL from zip file into "<GameDirectory>\Bepinex\plugins"  
Start the game.

### Version Information

0.6.1 - By TastyChickenLegs
 
- Gereral re-release
- Removed Nexus ID
- Added Blue Torch in the config file.
- Added Standing Brazier for Frost Caves in the config file.
- set default  for AllowAddingFuel to false in config file.
- Removed reference to Water Volume
- Updated version with credits back to Gurrlin

0.5.1  -By Gurrlin

- Original version by Gurrlin
