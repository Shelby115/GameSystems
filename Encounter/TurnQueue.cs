using GameSystems.Entity;

namespace GameSystems.Game
{
    public class TurnQueue : ITurnQueue
    {
        private readonly IEnumerable<ITakeTurns> Members;
        private readonly Queue<ITakeTurns> CurrentQueue;

        public int RoundCount { get; private set; }

        private ITakeTurns? CurrentTurnTaker;

        public event EventHandler<TurnEventArgs>? RoundStart;
        public event EventHandler<TurnEventArgs>? RoundEnd;

        public event EventHandler<TurnEventArgs>? TurnStart;
        public event EventHandler<TurnEventArgs>? TurnEnd;

        public TurnQueue(IEnumerable<ITakeTurns> members)
        {
            Members = members;
            CurrentQueue = new Queue<ITakeTurns>();
        }

        /// <summary>
        /// Listens for the entity to tell the turn queue that its turn is over.
        /// </summary>
        /// <param name="sender">The entity whose turn just ended.</param>
        private void ListenForEntityTurnEnded(object? sender, EventArgs e)
        {
            var turnTaker = sender as ITakeTurns;
            if (turnTaker == CurrentTurnTaker)
            {
                StartNextTurn();
            }
        }

        /// <summary>
        /// Factions are ordered by their members' aggregate speed stat, then each faction member is ordered within the faction by their speed stat for overall turn order.
        /// </summary>
        /// <returns>The turn queue for the next round given current entity status (i.e. IsDead, Speed, and Faction).</returns>
        private IEnumerable<ITakeTurns> GetMemberTurnOrderForNextRound()
        {
            return Members
                .Where(x => x.IsDead == false)
                .OrderBy(x => x.Speed)
                .GroupBy(x => x.Faction)
                .OrderBy(g => g.Sum(x => x.Speed))
                .SelectMany(x => x);
        }

        /// <summary>
        /// Starts the next round if the current round is over.
        /// </summary>
        private void StartNextRound()
        {
            if (CurrentQueue.Count != 0) { return; }

            if (RoundCount > 0)
            {
                RoundEnd?.Invoke(this, CreateTurnEventArgs());
            }

            var nextRound = GetMemberTurnOrderForNextRound();
            foreach (var member in nextRound)
            {
                CurrentQueue.Enqueue(member);
            }
            RoundCount += 1;

            RoundStart?.Invoke(this, CreateTurnEventArgs());
        }

        /// <summary>
        /// Triggers the next turn to start in the turn queue. If the queue is empty, the round will reset filling the queue again.
        /// Subscribes and unsubscribes from entity's <see cref="ICharacter.TurnEnded"/> event as current turn changes.
        /// </summary>
        public void StartNextTurn() // Ex. Character tells us it is done with its turn by either using its last action or choosing "wait".
        {
            if (CurrentTurnTaker != null)
            {
                CurrentTurnTaker.TurnEnded -= ListenForEntityTurnEnded;
                TurnEnd?.Invoke(this, CreateTurnEventArgs()); // Ex. Turn off character control.
            }

            if (CurrentQueue.Count == 0)
            {
                StartNextRound();
            }

            CurrentTurnTaker = CurrentQueue.Dequeue();
            CurrentTurnTaker.TurnEnded += ListenForEntityTurnEnded;
            TurnStart?.Invoke(this, CreateTurnEventArgs()); // Ex. Scroll to character, adjust character card UI, and turn on character control.
        }

        /// <summary>
        /// Instantiates a <see cref="TurnEventArgs"/> with the current turn taker and round count.
        /// </summary>
        private TurnEventArgs CreateTurnEventArgs()
        {
            return new TurnEventArgs(CurrentTurnTaker, RoundCount);
        }
    }
}