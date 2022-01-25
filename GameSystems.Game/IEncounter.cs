using GameSystems.Entity;

namespace GameSystems.Game
{
    public interface IEncounter
    {
        IEnumerable<ITakeTurn> Members { get; }
        string PlayerFaction { get; }
        ITurnQueue TurnQueue { get; }

        event EventHandler<EncounterEventArgs> EncounterEnded;
        event EventHandler<EncounterEventArgs> EncounterStarted;

        bool HasLost();
        bool HasWon();
        void StartEncounter();
    }
}