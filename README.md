# Valheim-TimedTorches_Fix
Original Mod by Gurrlin and found here [TimedTorches Original](https://www.nexusmods.com/valheim/mods/962)
I received Permission from Gurrlin to fix, modify and repost this mod

## Fixed for Valheim Frost Cave Update
This has been fixed for the Valheim Frost Cave Update  
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

<b>If you leave the settings alone, torches will turn off at 6:30am and turn on at 4:30pm and require NO fuel.</b>

As always "feature creep" has come calling and I thought it best to reorganize the configuration

The config file is located in "<GameDirectory>\Bepinex\config" (You need to start the game at least once, with the mod installed to create the config file).

<b>To view or add items this mod affects:  </b>

- AffectedFireplaceSources - List of objects to be affected by the mod (see below for list of supported objects). By default vanilla torches are added.

<b>To keep torches on the all the time (not use the timer) and never require any fuel (this overrides all other settings)</b>

- NeverNeedFuelNeverTurnOff - never turns off and never needs fuel - by default this is blank. Example would be "piece_groundtorch" with multiple items seperated by a comma

<b>To configure the timer:</b>
 
- OnTime - Time of day when torches should turn ON. (The default is set to 4.30pm in-game time)
- OffTime - Time of day when torches should turn OFF. (The default is set to 6.30am in-game time)

- AlwaysOnInDarkBiomes - (Default True) If true, objects listed in AffectedFireplaceSources will always burn in areas that Valheim considers 'always dark'. E.g Mistlands or any biome during a storm.

<b>To configure the ability to add fuel and the duration it burns, use the settings below.</b>

- AllowAddingFuelUseTimer - (Default False) If true, fuel can be added and sources will use the timer settings.  If false no fuel is needed to burn torches
- AllowAddingFuelNoTimer - (Default False) If true, fuel can be added but not use timers. (Basically vanilla torches) but with the ability to use fuelDurationMultiplier to extend the fuel burning time.

- FuelDurationMultiplier - Multiplies the duration of each fuel added to objects listed in the FuelDurationSources.
- FuelDurationSources - Items configured to use the FuelDurationMultiplier settings.
 

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

- Custom modded items can be added as well.  Example rk_campfire for the smokeless campfire in the Bon Appetit mod.

### Other

How to find the perfect timer settings for your needs  

The default values are set to work for my base that doesn't get really early sun and not the last rays of the sunset. However, if your base is in a different location you might want to tweak the on and off times.
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

0.6.3

- Add ability to burn configured torches (campfires, hearth..etc) all the time with no need for fuel.  Some torches can use the timers and others can stay on all the time yet require no fuel. This overrides the timer settings.

0.6.2

- Added the ability for timed sources to require fuel usage.  Enabled in config as AllowAddingFuelUseTimer
- Chaged the AllowAddingFuel setting to AllowAddingFuelNoTimer for clarity.

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
