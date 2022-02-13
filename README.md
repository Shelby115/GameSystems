# GameSystems
A collection of coded game systems abstract from any game engines. Generally this has been designed with a turn-based strategy game in mind.


## Projects & Systems
Generally, I will use these two terms interchangably because I'm thinking there should be one project per system, but we'll see how that goes as I add more to this solution.

1. GameSystems.Map contains all the logic for the map, grid system, and movement. It depends on the ICanMove interface for determining basics like a character's max move distance.
2. GameSystems.Encounter contains all the logic for encounters (i.e. battles). It depends on the ITakeTurns interface for determining basics like death status, their faction, and the speed of a character.


## Dependencies and Interfaces
Where possible, the systems should make use of interfaces (typically defined in the GameSystems.Character project) for interactions between systems and sub-systems. This means that nothing should be interacting with the Character class directly. This also means that the GameSystems.Character project should not depend on the other projects, but the other projects like Game and Map should depend on the Character project.

Examples:
1. The GameSystems.Map project depends on the GameSystems.Character project for its ICanMove interface. The move logic is entirely contained inside the GameSystems.Map project.
2. The GameSystems.Encounter project depends on the GameSystems.Character project for its ITakeTurn interface. The turn logic is entirely contained inside the GameSystems.Encounter project.
3. The ICanAttack and ICanBeAttack interfaces never mention the Character class. They purely interact among themselves. Even when implementing their functions and events on the Character class, they only mention those two interfaces and the Character class is not referenced.
