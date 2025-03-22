# Custom Events with State Manager

This package builds off of the custom events package to add in the State Management System.

## The Project

This flexible Unity package uses Scriptable Objects to manage Game Events and Game States in Unity. I love using this package because creating and managing new events easy. It can be imported into virtually any Unity project. 

### Why Game Events?

**Example:** 
We want to update the UI health bar when the player takes damage. There are a couple of ways we could handle this:
- **Option 1** - Check every frame to see if the health has changed and update the UI when it does. 
	- Very slow. Wasting lots of unnecessary bandwidth making these checks.
- **Option 2** - Write a specific UI update function into each damage function
	- This could work. However, if there are many different ways to damage the player, we will be rewriting a lot of redundant code that will be hard to manage down the line.
- **Option 3** - Send a `take_damage` **game event**. This acts as a signal for any function "listening" to this event.
	- This is our best option. We can write an update UI function that will listen for the `take_damage` event. This setup makes our lives easier because we can have other functions listen to this event, such as playing animations or voice lines.

### Taking It Further with Game States

Building off the Game Event structure, I also designed this package to manage Game States. For instance, if I as the developer wanted to track what "state" the game is in such as MainMenu, Combat, Paused, etc. Since I built the package using ScriptableObjects, it's easy to scale as many or as few game states as need.
## How it Works

### Game Events

`../Events/Scripts/Game Events/GameEvent.cs` creates the GameEvent class as a ScriptableObjects and the functions for raising the event and registering listeners.  

`../Events/Scripts/Game Events/GameEventListener.cs` is a MonoBehaviour that registers itself as a listener, can raise the event, and pass data when the event is raised.

### Game States

`../Events/Scripts/Game State/GameStateManager.cs` is a MonoBehaviour static instance that tracks the current game state and raises an event when the game state changes.

`../Events/Scripts/Game State/GameStateObject.cs` creates the GameStateObject class as a ScriptableObjects and the `OnStateEnter()` and `OnStateExit()` functions.
## Installation

To install, follow Unity's guide to <a href="https://docs.unity3d.com/Manual/upm-ui-giturl.html" target="blank">Install a UPM package from a Git URL</a> and use the URL from the project's <a href="https://github.com/acarv468/events-state-manager" target="blank">GitHub</a>.

![[unity_game_event_screenshot.png]]
## Credits

Here are some great guides that I've consulted to build this package:

- <a href="https://youtu.be/WLDgtRNK2VE?si=RAIX3jAPE6dqMudI" target="blank">Game architecture with ScriptableObjects</a>
- <a href="https://youtu.be/raQ3iHhE_Kk?si=8ndMhWV7gFz1Dbki" target="blank">Unite Austin 2017 - Game Architecture with Scriptable Objects</a>
