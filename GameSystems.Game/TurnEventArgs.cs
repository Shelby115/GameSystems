using GameSystems.Entity;

namespace GameSystems.Game
{
    public class TurnEventArgs : EventArgs
    {
        public IEntity Member { get; }
        public int RoundCount { get; }

        public TurnEventArgs(IEntity member, int roundCount)
        {
            Member = member;
            RoundCount = roundCount;    
        }
    }
}