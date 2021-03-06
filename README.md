# Unity-Game_Mechanics

Welcome to Unity-Game_Mechanics, a repository containning various exercices for improving game development, mechanics and features using Unity and CSharp.
Useful scripts are located in Assets/Scripts/..

## Getting Started

👾 Fun Repository

```
NOTE : This project is broken down into multiples folders, each representing a step in the development of my programming journey.
```

## Content

* [Assets/Scripts/FlockingAI](https://github.com/guyllaumedemers/Unity-Game_Mechanics/tree/master/Unity-AI/Unity-FlockingAI/Assets/Scripts) : Flocking AI Scripts
* [Assets/Scripts/ComboSystem](https://github.com/guyllaumedemers/Unity-Game_Mechanics/tree/master/Unity-Gameplay/Unity-Fighting_Mechanics/Assets/Scripts) : Combo System Scripts
* [Assets/Scripts/InteractiveWorld](https://github.com/guyllaumedemers/Unity-Game_Mechanics/tree/master/Unity-Gameplay/Unity-Interactable_World/Assets/Scripts) : Interactive World - Triggering Behaviour using Decorator Pattern
* [Assets/Scripts/IterativeMazeGeneration](https://github.com/guyllaumedemers/Unity-Game_Mechanics/tree/master/Unity-Algorithm/Unity-IterativeBacktracker_Maze/Assets/Scripts) : Iterative Backtracker Scripts
* [Assets/ResultingUI/...](https://github.com/guyllaumedemers/Unity-Game_Mechanics/tree/master/Unity-UI/Unity-UI_Hitman_ContentSizeFitter_Testing/ResultingUI_WithAspectRatio) : UI Content Size Fitter / Layout Element Components Testing - Screenshots

### Game Mechanics and Features

*  Combo System (*WIP*)

#####  EXPLAINATION
##

This project has for objective of setting up in place a combo system that register input keys from a players, compare those inputs 
       to a list of posssible combos and toss the last register key inputs if no match are found inside the hashset of unique combos OR perform
       last valid combo if the last input register time is greater than the maxTime allowed to register the next input.
       
* Interactive World (*Trigger System*)

##### EXPLAINATION
##

This project has for objective of setting up in place a System that easily manage behaviour for world object interactions
       using the **Decorator Pattern**.
       
Objects will be trigger via the Collision System and see their behaviour updated according to the collider that interact with them
       using OnTriggerEnter.
       
WHY?   NPC do not interact with world object the same way a player does. NPC do not trigger traps but instead trigger alternative behaviours
       of objects like opening a door that close and block the progression of our hero.
       This system has for objective of implementing such behaviours.

* UI (*testing how to properly implmeent a UI that fit every ratio with content size fitter and Layout Element component*)

### AI Mechanics

*  Flocking AI (*using the Composite Pattern*)

### Algorithms

*  Iterative Backtracker Maze Generation

### Design Pattern and Memory Optimization

*  Composite Pattern
*  Decorator Pattern

```
NOTE : Resources used to develop these features can be found here.
```

## Resources

💬 References for patterns are given from : [Design Patterns: Elements of Reusable Object‑Oriented Software](https://www.amazon.ca/-/fr/Gamma-Erich-ebook/dp/B000SEIBB8)
</br>
💬 Flocking AI Youtube Tutorial can be found here : [Board To Bits Games](https://www.youtube.com/playlist?list=PL5KbKbJ6Gf99UlyIqzV1UpOzseyRn5H1d) </br>
💬 Flocking AI Craig Reynolds : [Craig Reynolds Boids Paper](https://www.red3d.com/cwr/boids/)
</br>
💬 Iterative Backtracker : [Maze Generation](https://en.wikipedia.org/wiki/Maze_generation_algorithm)
