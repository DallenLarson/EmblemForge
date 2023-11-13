# Unity Tactical Strategy Game Scripts

This repository contains a set of Unity scripts designed to recreate a turn-based tactical strategy game, reminiscent of titles like Fire Emblem or Advance Wars.

## Description

These scripts are developed to provide the fundamental mechanics necessary for building a turn-based tactical game within the Unity game engine. The game revolves around strategic movement of units on a grid-based map, turn-based combat, and various game elements inspired by the classic tactical RPGs.

## Game Mechanics

### 1. **GameManager**

- Manages the game flow, including turns, player actions, and victory conditions.
- Initializes the game, handles player switching, and determines game states.

### 2. **Unit**

- Governs individual unit behavior, including movement, attacking, and health management.
- Handles actions such as movement range, attack range, and interactions with the environment.

### 3. **Tile**

- Defines properties of the tiles on the game grid.
- Manages information about terrain, occupancy, and any specific effects or buffs associated with different types of tiles.

### 4. **GridManager**

- Responsible for creating and managing the grid system.
- Provides methods for generating the game map, populating it with different tiles, and arranging units.

## Getting Started

To start, create four empty game objects in your Unity project, and attach the corresponding script to each one:
- Attach the `GameManager` script to one game object.
- Attach the `Unit` script to another game object.
- Attach the `Tile` script to a prefab representing a tile game object.
- Attach the `GridManager` script to a game object.

## Usage

1. **GameManager**:
    - Ensure that the game manager is initialized at the start of the game. It controls turn switching and game state transitions.
2. **Unit**:
    - Define the behavior of individual units, including movement range, attack range, and other abilities.
3. **Tile**:
    - Customize tile properties such as terrain effects or other attributes.
4. **GridManager**:
    - Use this script to generate the game map by setting up the grid system, placing tiles, and arranging units.

## Contributing

Feel free to contribute by forking this repository, making changes, and submitting pull requests. Suggestions, bug fixes, or additional features to enhance the gameplay are welcome.

## License

This project is licensed under the [MIT License](LICENSE) - see the [LICENSE](LICENSE) file for details.
