
namespace GameSystems.Game
{
    public interface ITurnQueue
    {
        int RoundCount { get; }

        event EventHandler<TurnEventArgs>? RoundEnd;
        event EventHandler<TurnEventArgs>? RoundStart;
        event EventHandler<TurnEventArgs>? TurnEnd;
        event EventHandler<TurnEventArgs>? TurnStart;

        void StartNextTurn();
    }
}