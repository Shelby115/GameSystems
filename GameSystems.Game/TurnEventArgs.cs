using GameSystems.Entity;

namespace GameSystems.Game
{
    public class TurnEventArgs : EventArgs
    {
        public ITakeTurn TurnTaker { get; }
        public int RoundCount { get; }

        public TurnEventArgs(ITakeTurn turnTaker, int roundCount)
        {
            TurnTaker = turnTaker;
            RoundCount = roundCount;    
        }
    }
}