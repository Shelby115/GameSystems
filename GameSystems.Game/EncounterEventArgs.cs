namespace GameSystems.Game
{
    public class EncounterEventArgs : EventArgs
    {
        public bool HasWon { get; }
        public bool HasLost { get; }

        public EncounterEventArgs(bool hasWon, bool hasLost)
        {
            HasWon = hasWon;
            HasLost = hasLost;
        }
    }
}