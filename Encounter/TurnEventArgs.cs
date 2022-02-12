using GameSystems.Entity;

namespace GameSystems.Game
{
    public class TurnEventArgs : EventArgs
    {
        public ITakeTurns TurnTaker { get; }
        public int RoundCount { get; }

        public TurnEventArgs(ITakeTurns turnTaker, int roundCount)
        {
            TurnTaker = turnTaker;
            RoundCount = roundCount;    
        }
    }
}