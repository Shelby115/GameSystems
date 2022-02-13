namespace GameSystems.Character
{
    public class Character : ICharacter, ICanAttack, ICanBeAttacked, ICanMove, ITakeTurns
    {
        #region ICharacter

        public Guid Id { get; }
        public string Name { get; }

        #endregion ICharacter

        #region ICanAttack

        public int AttackDamage { get; private set; }

        public event EventHandler<AttackArgs>? BeforeAttack;
        public event EventHandler<AttackArgs>? AfterAttack;

        public void Attack(ICanBeAttacked target)
        {
            if (target == null) { return; }
            if (AttackDamage <= 0) { return; }

            var preAmplifiedDamage = AttackDamage;
            // TODO: Create and implement a system for applying damage bonuses.
            var postAmplifiedDamage = preAmplifiedDamage;
            var attackArgs = new AttackArgs(this, target, postAmplifiedDamage);
            BeforeAttack?.Invoke(this, attackArgs);
            target.TakeDamage(this, postAmplifiedDamage);
            AfterAttack?.Invoke(this, attackArgs);
        }

        #endregion ICanAttack

        #region ICanBeAttacked

        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; }

        public event EventHandler<AttackArgs>? BeforeAttacked;
        public event EventHandler<AttackArgs>? AfterAttacked;
        public event EventHandler<AttackArgs>? BeforeDeath;
        public event EventHandler<AttackArgs>? AfterDeath;

        public void TakeDamage(ICanAttack attacker, int preMitigationDamage)
        {
            if (attacker == null) { return; }
            if (preMitigationDamage <= 0) { return; }
            if (CurrentHealth <= 0) { return; }

            // TODO: Create and implement a system for apply damage mitigation bonuses.

            var postMitigationDamage = preMitigationDamage;
            var attackArgs = new AttackArgs(attacker, this, postMitigationDamage);
            BeforeAttacked?.Invoke(this, attackArgs);
            if (CurrentHealth <= postMitigationDamage) { BeforeDeath?.Invoke(this, attackArgs); }
            CurrentHealth = Math.Min(0, CurrentHealth - postMitigationDamage);
            AfterAttacked?.Invoke(this, attackArgs);
            if (CurrentHealth <= 0) { AfterDeath?.Invoke(this, attackArgs); }
        }

        #endregion ICanBeAttacked

        #region ICanMove

        public int MaxMoveDistance { get; protected set; }


        #endregion ICanMove

        #region ITakeTurn

        public string Faction { get; }
        public bool IsDead { get; }
        public int Speed { get; }

        public event EventHandler? TurnEnded;


        #endregion ITakeTurn

        public Character(Guid id, string name, string faction)
        {
            Id = id;
            Name = name;
            Faction = faction;
        }
    }
}