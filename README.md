# GameSystems
A collection of coded game systems abstract from any game engines. Generally this has been designed with a turn-based strategy game in mind.

## GameSystems.Map

The map is designed to be a coordinate grid with integer coordinates, but acknowledges the fact that game engine coordinates are going to be float and provides the ability to convert between the two coordinate systems.
All logic internal to this project/solution will use the map's integer coordinate system and the conversion functions will exist for visuals and other effects (e.g. Unity game object positions within scenes).

## GameSystems.Game 

Contains the logic for the game's flow (e.g. encounters and turn queue).
Specific interfaces are used for interacting with specific systems, for example:
1. ITakeTurn is used for interacting with the Encounter and TurnQueue system.
2. ICanMove is used for interacting with the map system.
