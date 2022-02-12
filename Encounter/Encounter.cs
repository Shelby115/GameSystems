using GameSystems.Entity;

namespace GameSystems.Game
{
    public class Encounter : IEncounter
    {
        public string PlayerFaction { get; }
        public IEnumerable<ITakeTurns> Members { get; }

        public ITurnQueue TurnQueue { get; }
        public event EventHandler<EncounterEventArgs> EncounterStarted;
        public event EventHandler<EncounterEventArgs> EncounterEnded;

        public Encounter(string playerFaction, IEnumerable<ITakeTurns> members)
        {
            PlayerFaction = playerFaction;
            Members = members;

            TurnQueue = new TurnQueue(members);
            TurnQueue.RoundStart += TurnQueue_RoundStart;
            TurnQueue.TurnEnd += TurnQueue_TurnEnd;
        }

        /// <summary>
        /// Starts the encounter if it hasn't started already.
        /// </summary>
        public void StartEncounter()
        {
            if (TurnQueue == null) { return; }
            if (TurnQueue.RoundCount > 0) { return; }
            TurnQueue.StartNextTurn();
        }

        /// <summary>
        /// When the signal is received from the turn queue that a turn has ended, check if the encounter is over.
        /// </summary>
        private void TurnQueue_TurnEnd(object? sender, TurnEventArgs e)
        {
            if (HasWon())
            {
                EncounterEnded?.Invoke(this, new EncounterEventArgs(hasWon: true, hasLost: false));
            }
            else if (HasLost())
            {
                EncounterEnded?.Invoke(this, new EncounterEventArgs(hasWon: false, hasLost: true));
            }
        }

        /// <summary>
        /// When the signal is received from the turn queue that a round has started, check if the encounter has started.
        /// </summary>
        private void TurnQueue_RoundStart(object? sender, TurnEventArgs e)
        {
            if (e.RoundCount == 0)
            {
                EncounterStarted?.Invoke(this, new EncounterEventArgs(hasWon: false, hasLost: false));
            }
        }

        /// <summary>
        /// Standard encounter loss condition is all player faction members are dead.
        /// </summary>
        /// <returns>True if the player has lost.</returns>
        public bool HasLost()
        {
            // Are there any members for the player's faction that aren't dead? If not, you've lost.
            return Members.Where(x => x.IsDead == false).Any(x => x.Faction == PlayerFaction) == false;
        }

        /// <summary>
        /// Standard encounter win condition is only player faction memebers remaining alive.
        /// </summary>
        /// <returns>True if the player has won.</returns>
        public bool HasWon()
        {
            // Are all remaining members of the player's faction? If so, you've won.
            return Members.Where(x => x.IsDead == false).All(x => x.Faction == PlayerFaction);
        }
    }
}