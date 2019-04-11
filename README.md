![](https://vignette.wikia.nocookie.net/millionaire/images/6/62/WWTBAMUK.png/revision/latest?cb=20180516174416)

<p align="center">
  <b>A voice-controlled implementation of the classic quiz game "Who Wants To Be A Millionaire"</b><br>
</p>


# Overview
The following repoistory contains the source code and documentation for our voice-controlled implementation of "Who Wants To Be A Millionaire". The project stated that we must _Develop and application with a natural user intrface_.

As stated above, the project is essentially a voice-controlled implementation of the classic quiz game "Who Wants To Be A Millionaire". 

The original goal of the project was to develop a game/application using <b>Gesture-Based</b> controls. We choise Voice/Speech recognition as our "<i>gesture</i>".

# Table of Contents
1. [Prerequisites](#Prerequisites)
2. [Installation](#Installation)
3. [How to play](#How-to-Play)
4. [Documentation](#Documentation)
5. [Presentation](#Presentation)
6. [Research](#Research)

## Prerequisites

* Windows 10
* Windows Language Packs
* A microphone <b>OR</b> a mouse

## Installation

* Please ensure you have either downloaded/configured the appropriate language packs inside Windows before attempting to play the game. If you're having trouble with this, please follow this [tutorial on configuring Windows Speech Recognition](https://www.windowscentral.com/how-set-speech-recognition-windows-10)

* To actually run the game, clone/download this repository.
* The latest/stable build of the game can be found in the <b>Builds</b> folder in the root directory of the project.

## How to play
If you haven't played <i>"Who Wants To Be A Millionaire Before"</i>and don't know how to play, don't worry as the game is simple.

The player is presented with <b>One</b> question and <b>Four</b> questions labeled A,B,C and D.

The player must attempt to answer the question correctly. There are 15 questions in total and the questions will incremently get harder as the game progresses.

A breakdown of the prizes to be won from answering a certain amount of questions can be found below.


<img src="https://user-images.githubusercontent.com/22448079/55954459-a499da80-5c56-11e9-8d7b-63e0808a3de9.png" alt="drawing" width="200"/>



# Project Overview
1. [Purpose of the application](#Purpose-of-the-application)
2. [Gestures identified](#Gestures-identified)
3. [Hardware used in creating the application](#Hardware-used-in-creating-the-application)
4. [Architecture for the solution](#Architecture-for-the-solution)
5. [Conclusions & Recommendations](#Conclusions-&-Recommendations)

## Purpose of the application
When we were first thinking of ideas for a project, we thought it would be interesting to see if we could develop an applicaton that doesn't use a traditional control method (hands). We discussed and researched the viability of a couple of ideas but eventually decided on <b> Windows Speech Recognition</b> as it was something we had never used before as well as being something that wouldn't require any additional expensive hardware or complicated setup.

We wanted the game to be <b> accessible</b>, <b>easy to use</b> and most of all <b>FUN!</b>.

Our original idea for a voice controlled game was a puzzle game. We though this idea was interesting but upon doing some testing, when you made a mistake and attempted speech to correct this was very frustrating. Therefore, we wanted a game that was not overly complicated gameplay wise but where there was also a compelling and interesting reason to use voice.

We envisioned a group of people being able to sit back and relax and play the game on a large or small screen together and being able to enjoy the handsfree, minimal setup our game requires.


## Gestures identified
The game has been configured to be fully functional with just a users voice. Although we did also implement the solution to be fully compatable with mouse input aswell as touch controls so at any time under every circumstance.

A list of <i>voice-gestures</i> found in the application are as follows

* Play game, Exit Game, Pause
* A, B, C, D
* Final Answer
* Yes/No
* Score/Scoreboard/Show score

Depending on which scene you are in, Settings, Menu, Main Game etc. the user has a list of available voice commands available to them. The user cannot use voice commands found in the Main Menu in the Main Game and vice-versa. We setup the Speech Recognition this way as we did not want the user to experience unexpected behaviour when playing the game.

We understand that the range of <i>voice-gestures</i> available is not huge but we wanted to focus on the actual implementation of these gestures in a gameplay sense rather than simply expanding the list of gestures for the sake of it.

To identify the <i>voice-gestures</i> done by the user, we used Unity's impleentation of Windows 10's Speech Recognition API.  This lead to minimal setup for the user (which can be extremely appealing to a lot of people) and a generally streamlined, lightweight application.

To further progress towards our overall goal of <b>accessibility</b>, we ensured the game was <b>lightweight</b> in it's resource use and that the UI was <b>simple</b> and <b>intuitive</b> to navigate.

## Hardware used in creating the application
The only hardware necessary in the application is 

* Mouse

    <b>OR</b>

* Microphone

Attempting to deliver on our original goal of the game being <b>accessible</b> to almost anyone, we wanted to ensure that the required hardware to play the game was not expensive or hard to come by. 

A <b>mouse</b> is a standard piece of hardware for a desktop computer and a <b>microphone</b> is a standard piece of hardware for a laptop (webcam+microphone). 

We had some issues with the Speech Recognition having issues detecting certain phrases but we were able to rememedy this by adjusting the [Confidence Level](https://docs.unity3d.com/ScriptReference/Windows.Speech.ConfidenceLevel.html) of the Speech Recogntiion API in Unity.

By setting the confidence level of the API to <b>Low</b>, it meant that the application would reject very little phrases and would at least acknowledge and respond with the user's input even if it didn't not recognize what the user was trying to say 100% of the time.

` ConfidenceLevel confidence = ConfidenceLevel.Low`


## Architecture for the solution


## Conclusions & Recommendations




# Presentation
A presentation style document can be found [here]([Presentation](https://prezi.com/p/_xs2mrmbsdxa/whowantstobeamillionaire/)), going into a bit more detail on the actual design philosophy and approach taken to development.


# Research
### Games of this type
To get a further undertanding of how this technology could be incorporated into a game we conducted research to see how other developers incorporated speech into games. [itch.io](https;// insert link here) published a list of the top voice controlled games available on the windows platform:
1. OneHand Clapping (User humms). 
2. Resonance (howl into glass).
3. ScreamTrain (Just scream).
4. BooGreedykif (user says boo).

After testing and playing these games we discovered none of them actually use a proper speech/word recognition sound and work off general patterns. This finding showed us a wide gap in the market for a fun, challanging **voice** controlled game.

Our solution to this issue? A unique voice controlled implementation of the classic **Who Wants To Be A Millionaire**.

### Technology
