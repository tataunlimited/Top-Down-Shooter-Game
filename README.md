# Top-Down Shooter Game

## Overview

This top-down shooter game built with Unity features player movement, shooting mechanics, basic enemy AI, a simple UI system, and a game over view with restart functionality. The systems are modular and expandable.

## Features

- **Player Movement and Shooting:** Move with WASD keys and shoot with the left mouse button.
- **Enemy AI:** One enemy follows and attacks the player. Controlled by a simple FSM (Finite State Machine).
- **Health System:** Both player and enemy have health components.
- **Game Over and Restart:** A game over screen appears when the player dies, with an option to restart.
- **Scriptable Objects:** Used for player and gun data customization.

## Getting Started

### Prerequisites

- Unity 2020.3 or later
- Git (for cloning the repository)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/tataunlimited/Top-Down-Shooter-Game.git
    ```
2. Open the project in Unity:
    - Launch Unity Hub.
    - Click on "Add" and navigate to the cloned project folder.
    - Select the project and open it.

### Playing the Game

- Use `WASD` keys to move the player.
- Use the left mouse button to shoot.
- Defeat the enemy to win the game.
- If the player/the Enemy dies, a game over screen will appear with an option to restart.

## Project Structure

- **Assets/Scripts**: C# scripts for the project.
  - **Components**: Health, Movement, and Attack components.
  - **Entities**: Base `Entity` class and derived `Player` and `Enemy` classes.
  - **FSM**: FSM implementation with `Run`, `Idle`, and `Death` states.
  - **Systems**: Input and AI system scripts.
  - **ScriptableObjects**: Player and gun data definitions.
  - **UI**: Scripts for UI management.
- **Assets/Prefabs**: Prefabs for player, enemy, bullets, and other objects.
- **Assets/Scenes**: Main game scene.

## Systems Overview

### Entity System

The `Entity` class serves as a base class for all entities, including common properties and methods like health management.

### Finite State Machine (FSM)

Manages entity states, such as `Run`, `Idle`, and `Death`, controlling entity behavior.

### Input System

Handles player inputs and AI inputs for enemy actions.

### AI System

Uses a simple AIController to manage enemy behavior, including chasing and attacking the player.

### Components

- **HealthComponent**: Manages health, damage, and death.
- **MovementComponent**: Handles movement for player and enemy.
- **AttackComponent**: Manages attacking and shooting mechanics.

### Scriptable Objects

Store player and gun data for easy customization without hardcoding.

## Expanding the Project

Ideas for future improvements:

- Add different enemies with unique behaviors.
- Implement power-ups and various weapons.
- Introduce new FSM states for complex behaviors.
- Enhance the UI with additional features.

## Contributing

Fork this repository and submit pull requests. Contributions are welcome!

## Acknowledgments

- Unity Documentation and Tutorials
- [Taher Samadi](https://github.com/tataunlimited)
