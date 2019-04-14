<p align="center">
<img src="https://i.imgur.com/MtWcb7b.png" width=50%>
</p>

<center> <h1>GestureBasedUIProject</h1> </center>

# Overview

This repository contains a project completed for GMIT's Gesture Based URI Development. The project stated that we must _Develop and application with a natural user interface_.
The contents contains the source code and documentation for our voice-controlled implementation of "Who Wants To Be A Millionaire". This document aims to give the reader an insight into the design and development process under the following categories.

1. Purpose of the application
2. Gestures identified
3. Hardware used in creating the application
4. Architecture for the solution
5. Conclusions & Recommendations


As stated above, the project is essentially a voice-controlled implementation of the classic quiz game "Who Wants To Be A Millionaire". 

The original goal of the project was to develop a game/application using <b>Gesture-Based</b> controls. We choice Voice/Speech recognition as our "<i>gesture</i>".

# Table of Contents

- [Overview](#overview)
- [Table of Contents](#table-of-contents)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Purpose of the application–](#purpose-of-the-application-)
  * [How to play](#how-to-play)
- [Research](#research)
    + [Initial Research on Gesture Consideration](#initial-research-on-gesture-consideration)
    + [Games of this type](#games-of-this-type)
- [Gestures identified](#gestures-identified)
- [Hardware used in creating the application](#hardware-used-in-creating-the-application)
- [Software used in creating the application](#software-used-in-creating-the-application)
- [Architecture for the solution–](#architecture-for-the-solution-)
  * [Game Screens](#game-screens)
  * [Sound system](#sound-system)
  * [File Reading Questions](#file-reading-questions)
- [Testing](#testing)
    + [Main Menu](#main-menu)
    + [In Game Scene](#in-game-scene)
    + [In Game Scene (Final Answer mode)](#in-game-scene--final-answer-mode-)
- [Presentation](#presentation)
  * [Conclusions & Recommendations–](#conclusions---recommendations-)
  * [References](#references)

# Prerequisites

* Windows 10
* Windows Language Packs
* A microphone <b>OR</b> a mouse

****
# Installation

* Please ensure you have either downloaded/configured the appropriate language packs inside Windows before attempting to play the game. If you're having trouble with this, please follow this [tutorial on configuring Windows Speech Recognition](https://www.windowscentral.com/how-set-speech-recognition-windows-10).

* To actually run the game, clone/download this repository. Create an empty directory and navigate to it in CMD. The following command will clone the project to your local machine.
```bash
> git clone https://github.com/gesture-based-ui-development/voice-controlled-unity-game.git
```

* The latest/stable build of the game can be found in the <b>Builds</b> folder in the root directory of the project.

****

# Purpose of the application– 
The purpose of the application was to design and develop a game  for users who traditionally wouldn't be able to play classic mouse/keyboard games.

In order to complete the project we set out 4 core objectives.
1. Research voice-recognition gesture technologies.
2. Design a solution.
3. Implement game logic compatible to showcase technologies.
4. Present the final product.

When we were first thinking of ideas for a project, we thought it would be interesting to see if we could develop an application that doesn't use a traditional control method (hands). We discussed and researched the viability of a couple of ideas but eventually decided on <b> Windows Speech Recognition</b> as it was something we had never used before as well as being something that wouldn't require any additional expensive hardware or complicated setup.

We wanted the game to be <b> accessible</b>, <b>easy to use</b> and most of all <b>FUN!</b>.

Our original idea for a voice controlled game was a puzzle game. We though this idea was interesting but upon doing some testing, when you made a mistake and attempted speech to correct this was very frustrating. Therefore, we wanted a game that was not overly complicated gameplay wise but where there was also a compelling and interesting reason to use voice.

We envisioned a group of people being able to sit back and relax and play the game on a large or small screen together and being able to enjoy the handsfree, minimal setup our game requires.

## How to play
If you haven't played _Who Wants To Be A Millionaire_ before and don't know how to play, don't worry as the game is simple.

The player is presented with <b>One</b> question and <b>Four</b> answers labelled A,B,C and D.

The player must attempt to answer the question correctly. After selecting an answer a final answer screen will appear prompting the user to confirm their choice. The correct choice will advance the user to the next question and increase their position on the scoreboard. There are 15 questions in total and the questions will incrementally get harder as the game progresses.

A breakdown of the prizes to be won from answering a certain amount of questions can be found below.

<center><img src="https://user-images.githubusercontent.com/22448079/55954459-a499da80-5c56-11e9-8d7b-63e0808a3de9.png" alt="drawing" width="200"/></center>

****

# Research
### Initial Research on Gesture Consideration
Once we initially received the project brief we started looking into our options on what gesture technology to use. We decided it would be best to build an application that showcases the technology rather than developing an over complicated game that would just uses the technology for the sake of it.
After investigating the powers and functionality of the available technologies we came to the conclusion that a quiz style game contains all the features needed to explore these technologies and their implementations.

We looked into the pros and cons of many gesture devices available to us, such as the Myo Armband, the Xbox Kinect and the Leap motion. After experimenting with some of these devices we felt the frequency of inaccuracy of the readings of the gestures was too high to produce a solid working solution. Another discovery is that a game built on these technologies would be un-useable to anyone with mobility issues thus lowering the market that can enjoy the game.

Further to this we turned our research towards Speech technologies. 
> For those with mobility restrictions or the visually impaired, speech recognition has always been a big help, extending the accessibility of computer-based technologies to a much wider audience.

The above quote by _William Goddard_ taken from the article _The Pros and Cons of Speech Recognition and Virtual Assistants_ shaped our ideas on the route the project would take. This finding led to the decision  to design and develop a game  for users who traditionally wouldn't be able to play classic mouse/keyboard games.

### Games of this type
To get a further understanding of how this technology could be incorporated into a game we conducted research to see how other developers incorporated speech into games. [itch.io](https;// insert link here) published a list of the top voice controlled games available on the windows platform:
1. OneHand Clapping (User humms). 
2. Resonance (howl into glass).
3. ScreamTrain (Just scream).
4. BooGreedykid (user says boo).

After testing and playing these games we discovered none of them actually use a proper speech/word recognition sound and work off general patterns. This finding showed us a wide gap in the market for a fun, challenging **voice** controlled game.

Our solution to this issue? A unique voice controlled implementation of the classic **Who Wants To Be A Millionaire**.

****

# Gestures identified
The game has been configured to be fully functional with just a users voice. Although we did also implement the solution to be fully compatible with mouse input aswel as touch controls so at any time under every circumstance the game is playable.
Some of commands  identified are as follows:

**Main Menu :**
- New Game : Starts a new game.
- Play : Starts a new game.
- Quit : Closes the application.

**In Question State**
- a : Selects answer option A as initial choice.
- b : Selects answer option B as initial choice.
- c : Selects answer option C as initial choice.
- d : Selects answer option D as initial choice.

**In Final Answer State**
- yes : Progress with initial choice.
- ya : Progress with initial choice.
- final answer : Progress with initial choice.
- no : Deselect initial choice.

**In Any Game State**
- pause : Pauses the game.
- main menu : Return to main menu.
- score : show current score board.
- show scoreboard : show current score board.
- scoreboard : show current score board.
***

Depending on which scene you are in, Settings, Menu, Main Game etc. the user has a list of available voice commands available to them. The user cannot use voice commands found in the Main Menu in the Main Game and vice-versa. We setup the Speech Recognition this way as we did not want the user to experience unexpected behaviour when playing the game.

We understand that the range of _voice-gestures_ available is not huge but we wanted to focus on the actual implementation of these gestures in a gameplay sense rather than simply expanding the list of gestures for the sake of it.

To identify the _voice-gestures_ recognised by the user, we used Unity's implementation of Windows 10's Speech Recognition API.  This lead to minimal setup for the user (which can be extremely appealing to a lot of people) and a generally streamlined, lightweight application.

To further progress towards our overall goal of <b>accessibility</b>, we ensured the game was <b>lightweight</b> in it's resource use and that the UI was <b>simple</b> and <b>intuitive</b> to navigate.

****

# Hardware used in creating the application
The only hardware necessary in the application is 

* Mouse

    <b>OR</b>

* Microphone

Attempting to deliver on our original goal of the game being <b>accessible</b> to almost anyone, we wanted to ensure that the required hardware to play the game was not expensive or hard to come by. 

A <b>mouse</b> is a standard piece of hardware for a desktop computer and a <b>microphone</b> is a standard piece of hardware for a laptop (webcam+microphone). 

We had some issues with the Speech Recognition having issues detecting certain phrases but we were able to remedy this by adjusting the [Confidence Level](https://docs.unity3d.com/ScriptReference/Windows.Speech.ConfidenceLevel.html) of the Speech Recognition API in Unity.

By setting the confidence level of the API to <b>Low</b>, it meant that the application would reject very little phrases and would at least acknowledge and respond with the user's input even if it didn't not recognize what the user was trying to say 100% of the time.

` ConfidenceLevel confidence = ConfidenceLevel.Low`

****

# Software used in creating the application
To create the application we had to use a variety of different software's available to us to complete numerous tasks
- **Unity 2018** Game Engine to build the game.
- **Visual Studio 2017** Code editor to write c# scripts.
- **Paint.net** Image editing software for designing sprites
- **Audacity** Audio editor to edit sound clips.
- **GitHub** Version control.

# Architecture for the solution–
the full architecture for the solution, including the class diagrams, any data models, communications and distributed elements that you are creating.The architecture must make sense when the gestures and the hardware are combined. Justification is necessary in the documentation for this.You need to include a list of relevant libraries that you used in the project.
- using UnityEngine.Windows.Speech;
## Game Screens
Main Menu          |  Scoreboard
:-------------------------:|:-------------------------:
<img src="https://i.imgur.com/2iVItuUl.png">|<img src="https://i.imgur.com/ztPcZFel.png">

Game Screen          |  Final Answer
:-------------------------:|:-------------------------:
<img src="https://i.imgur.com/ppg35msl.png">|<img src="https://i.imgur.com/PautO2Ml.png">

Correct Answer          |  Incorrect Answer
:-------------------------:|:-------------------------:
<img src="https://i.imgur.com/abt6UfDl.png">|<img src="https://i.imgur.com/D0B2MsPl.png">

## Sound system
One major element to any game is the sound effects. The sounds used in a game work hand-in-hand in creating drama and increasing tension. After researching the sounds used in the original **Who Wants To Be a Millionaire** TV show  we discovered the musical score was composed professionally by a father and son duo [Keith](https://en.wikipedia.org/wiki/Keith_Strachan) And [Mathew Strachan](https://en.wikipedia.org/wiki/Matthew_Strachan). The _Millionaire_ soundtrack was honoured by the [American Society of Composers, Authors and Publishers](https://www.ascap.com/) and received multiple awards.

For this reason to perfect the game play and the drama portrayed to the user we decided to replicate these sounds to truly add the real feel of playing the game. To achieve this we implemented a Sound Controller into the game. 

At first we created a [Sound Manager](https://github.com/gesture-based-ui-development/voice-controlled-unity-game/blob/master/SpeechRecognitionUnity/Assets/Scripts/SoundManager.cs) singleton class to carry an array of sound clips that would be loaded throughout the game. Initially this worked but as the game expanded in complexity this was causing issues when running alongside the speech recognition and syncing the delay of playing the sounds in co-routines.

To solve this issue we decided to create a static [Sound Controller](https://github.com/gesture-based-ui-development/voice-controlled-unity-game/blob/master/SpeechRecognitionUnity/Assets/Scripts/SoundController.cs) that worked differently. By loading all the sound files on awake we were able to decrease memory usage while also eliminating lag waiting for a sound clip to be loaded before played.
```c
void Awake()
    {
        letsPlayAudio = GameObject.Find("LetsPlay").GetComponent<AudioSource>();

        rightAnswerAudio = GameObject.Find("CorrectAnswer").GetComponent<AudioSource>();
        wrongAnswerAudio = GameObject.Find("WrongAnswer").GetComponent<AudioSource>();

        // Background sounds for different level questions.
        easyBackgroundMusic = GameObject.Find("easyBackgroundMusic").GetComponent<AudioSource>();
        sound_32000 = GameObject.Find("32000_sound").GetComponent<AudioSource>();
        sound_64000 = GameObject.Find("64000_sound").GetComponent<AudioSource>();
        sound_250000 = GameObject.Find("250000_sound").GetComponent<AudioSource>();
        sound_500000 = GameObject.Find("500000_sound").GetComponent<AudioSource>();
        hardBackgroundMusic = GameObject.Find("hardBackgroundMusic").GetComponent<AudioSource>();

        // Sound effects for final answer
        sound_final = GameObject.Find("finalAnswer_sound").GetComponent<AudioSource>();
    }
```
The game sound system has been developed to avoid any silence or pause that may take away from the tension of the gamer. That is from the moment the game is started sounds are continuously played and interchanged depending on the play state.

When Sounds are used:
- Main Menu - Theme sound (remix)
- New Game - Intro is played
- Question - Increasing pitch sound effects as progress though levels to mimic  a heart beat as used in original tv show
- Final Answer - A low pitch tone is played while waiting for user to confirm final answer
- Correct Answer - User selects correct answer
- Incorrect Answer - User selects incorrect answer

| Level    | Sound clip    | 
| --------|---------|
| 15  |1000000_sound  | 
| 14  |500000_sound  | 
| 13  |250000_sound  | 
| 12  |250000_sound  | 
| 11  |64000_sound  | 
| 10  |32000_sound  | 
| 9  |32000_sound  | 
| 8  |32000_sound  | 
| 7  |32000_sound  | 
| 6  |32000_sound  | 
| 5  |1000_sound  | 
| 4  |1000_sound  | 
| 3  |1000_sound  | 
| 2  |1000_sound  | 
| 1  |1000_sound  | 


## File Reading Questions
The game is based on answering questions so one requirement was that the game would have a large selection of different questions to keep the user engaged. To achieve this the questions are loaded from a ```questions.json``` file. This also benefits future expansion allowing more questions to be added without any adjustment to the project code. Below is a sample of how that file looks with two questions.
```json
{

  "questions":[
    {
  "question": "A flashing red traffic light signifies that a driver should do what?",
  "A": "stop",
  "B": "speed up",
  "C": "proceed with caution",
  "D": "honk the horn",
  "answer": "A"
}, {
  "question": "A knish is traditionally stuffed with what filling?",
  "A": "potato",
  "B": "creamed corn",
  "C": "lemon custard",
  "D": "raspberry jelly",
  "answer": "A"
}]
} 
```
The file used currently holds 1500 different choices. Subsequently for each new game 15 questions are picked at random and stored in an array. 
```csharp
// Load the questions.
allQuestions = loadQuestions();
int randomNum = Random.Range(1, 500);
questionLevel = 0;

for (int i = 0; i < 15; i++)
{
    fifteenQuestionArray.Add(allQuestions[randomNum]);
    randomNum = Random.Range(1, 500);
}

/*
Loads questions from a json file as a String and parses into Question objects.
Returns an array of Questions
*/
Question[] loadQuestions()
{
    // Read the json and load it into a string
    string filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
    jsonFromFile = File.ReadAllText(filePath);

    // Parse the json into an object
    QuestionList questionList = JsonUtility.FromJson<QuestionList>(jsonFromFile);

    return questionList.questions;
}
```
****

# Testing
### Main Menu
| Test | Expected Result                                                         | Actual Result                                                           | PASS/FAIL |
| ----- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | --------- |
| Saying "new game" should launch a new game   | Game scene loads | Game scene loaded | **PASS**  |
| Saying "play game" should launch a new game   | Game scene loads | Game scene loaded | **PASS**  |
| Saying "play" should launch a new game   | Game scene loads | Game scene loaded | **PASS**  |
| Saying "quit" should terminate the game   | Game shuts down | Game shut down| **PASS**  |
| Saying "exit" should terminate the game   | Game shuts down | Game shut down| **PASS**  |
| Clicking [new game] should launch a new game   | Game scene loads | Game scene loaded | **PASS**  |

### In Game Scene
| Test | Expected Result                                                         | Actual Result                                                           | PASS/FAIL |
| ----- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | --------- |
| Saying "new game" should launch a new game   | Game scene loads | Game scene loaded | **PASS**  |
| Clicking [new game] should launch a new game   | Game scene loads | Game scene loaded | **PASS**  |
| Saying "show scoreboard"  | Scoreboard comes into view | scoreboard came into view | **PASS**  |
| Saying "scoreboard"  | Scoreboard comes into view | scoreboard came into view | **PASS**  |
| Saying "score"  | Scoreboard comes into view | scoreboard came into view | **PASS**  |
| Saying "pause"  | Scoreboard comes into view | scoreboard came into view | **PASS**  |
| Saying ["a","b","c","d"]  | Should select and highlight answer |  answer was selected and highlighted| **PASS**  |
| Saying ["a","b","c","d"]  | Should select an answer and prompt for final answer |  answer was selected and final answer prompted | **PASS**  |

### In Game Scene (Final Answer mode)
| Test | Expected Result                                                         | Actual Result                                                           | PASS/FAIL |
| ----- | ----------------------------------------------------------------------- | ----------------------------------------------------------------------- | --------- |
| Saying "Yes"   | Selects final answer | Final answer selected | **PASS**  |
| Saying "Final Answer"   | Selects final answer | Final answer selected | **PASS**  |
| Saying "No"   | Deselects final answer | Final answer deselected | **PASS**  |
| Select correct answer   | Correct answer highlighted and move to next question | Answer highlighted and new question loaded | **PASS**  |
| Select correct answer to progress game  | Position on scoreboard should increase | Scoreboard position increased by 1| **PASS**  |
| Select wrong answer   | Wrong answer highlighted and game ends | Wrong answer highlighted and game ends | **PASS**  |

****

# Presentation
A presentation style document can be found [here](https://prezi.com/p/_xs2mrmbsdxa/whowantstobeamillionaire/), going into a bit more detail on the actual design philosophy and approach taken to development.

****

## Conclusions & Recommendations–
Conclusions are what you have learned from this project and the associated research.  Recommendations are what you would do differently if you were to undertake the project again.  The Reflective Piece–what I learned and “enjoyed”! This gives scope for a critical evaluation of the project and the objective that you tried to achieve

****

## References
- [Million Pound notes](https://web.archive.org/web/20110612081217/http://www.thestage.co.uk/features/feature.php/6991)
- [Speech Recog Pros and Cons](https://www.itchronicles.com/technology/the-pros-and-cons-of-speech-recognition-and-virtual-assistants/)

