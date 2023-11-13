![Emblem Forge Banner](https://i.ibb.co/z6W4w07/Banner.jpg)


# Emblem Forge: A Highly Customizable Unity C# Framework for Tactical Strategy Games

Welcome to Emblem Forge, a Unity framework designed to build highly customizable turn-based tactical strategy games reminiscent of titles like Fire Emblem and Advance Wars.

## Overview

Emblem Forge provides a robust set of Unity C# scripts that form the foundation for developing turn-based tactical games within the Unity game engine. The framework revolves around strategic unit movement on a grid-based map, turn-based combat, and diverse game elements inspired by classic tactical RPGs.

## Core Components

### 1. **GameManager**

- Manages game flow, including turns, player actions, and win/lose conditions.
- Handles game initialization, player switches, and game state determinations.

### 2. **Unit**

- Governs individual unit behavior such as movement, attacking, and health management.
- Manages actions like movement range, attack range, and interactions with the game environment.

### 3. **Tile**

- Defines properties of grid-based tiles.
- Manages terrain, occupancy, and specific effects or buffs associated with different tile types.

### 4. **GridManager**

- Responsible for creating and managing the grid system.
- Provides methods for generating the game map, populating it with tiles, and placing units.

## Getting Started

1. **Setup**:
   - Create four empty game objects in your Unity project.
2. **Attachment**:
   - Attach scripts accordingly:
      - `GameManager` script to one game object.
      - `Unit` script to another game object.
      - `Tile` script to a prefab representing a tile game object.
      - `GridManager` script to a game object.

## How to Use

1. **GameManager**:
    - Ensure the game manager is initialized at the start to control turns and game state transitions.
2. **Unit**:
    - Define individual unit behavior, movement, attack range, and special abilities.
3. **Tile**:
    - Customize tile properties such as terrain effects or other attributes.
4. **GridManager**:
    - Utilize this script to generate the game map by setting up the grid system, placing tiles, and arranging units.

## Contribution

We encourage contributions! Fork this repository, make changes, and submit pull requests. Suggestions, bug fixes, or new features enhancing gameplay are highly welcome.

## License

This project is licensed under the [MIT License](LICENSE). Refer to the [LICENSE](LICENSE) file for details.
