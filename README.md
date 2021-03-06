# VR Data Library
### Team:

* Dan Scanlan (Dan43rocks@gmail.com)
* Daniel Dusharm (dushar88@students.rowan.edu)
* Peter Kwiatek (kwiate24@students.rowan.edu)
* James Czermanski (czerma88@students.rowan.edu)
* Zachary Maurer (maurer22@students.rowan.edu)
* Kevin Eivich (eivichk6@students.rowan.edu)

## Project Summary
The purpose is to create a library of tools to collect biometric data from users using VR headsets. Data is collected through a series of simple carnival style games that the user can play. These games will test memory, reaction time and hand eye coordination. The data will be pushed to a web server and will be represented in a meaningful way, either on the headset itself or on the web server.

## Project Goals
Main goals of the project:
1. To create and test a system for collecting biometric information using a VR headset. This system will serve as a basis for future VR research.
2. VR game that collects data by making the player go through different mini-games.

## Product Features
1. Use of a VR Headset to collect different types of biometric data from the user such as, Reflexes, Head movement, and Hand movement.
2. Virtual Reality Environment created in the Unity Engine for running tests to collect data
3. Save collected data to a web server
4. Mini games for collecting data such as:
   * Simon says, tests memory
   * Game where you move a metal ring through a wire, test hand precision
   * Whack-a-mole, tests hand-eye coordination and reflexes

## Limitations
1. Scope is limited to those that own a VR headset and have a PC powerful enough to run the game.
2. Data collected may not be precise enough and potentially overly broad.
3. Data accuracy is determined by the hardware and user participation


## Stretch Goals
* Incorporation of non-headset sensor systems such as a heart rate tracker on a smartwatch
* Virtual environment where the user can seamlessly switch between environments such as a virtual carnival
* Eye Tracking Data collected and implemented
* Webapp that displays the data from the database
* Graphical representation of data
* More advanaced mingames
  * Baseball game with the pitch being thrown at variable speeds, tests reflexes and hand-eye coordination
  * Game where multiple balls are being thrown and user has to use both hands to catch balls
  * Skeet shooting, tests hand-eye coordination
  * Punching bag, tests hand speed movement
  
## Running Locally
You may wish to download and try the game out your self, here are the steps how to.
1. Have Unity 2019.3.0f6 installed.
2. Download VRDC_fullscene.unitypackage from the prototypes folder.
3. Download the API folder.
4. Start a new Unity project using versionUnity 2019.3.0f6.
5. In the new project select Assets > import package > custom package, and select the unitypackage you downloaded.
6. In the API folder go to the vr-data sub directory and run `npm install` from the terminal then run `npm start`.
7. In unity find the data collection server script and in it set the ip address to the ip of your npm server.
8. In unity press the play button to start trying out the game.
