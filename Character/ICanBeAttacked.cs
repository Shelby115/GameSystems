namespace GameSystems.Character
{
    public interface ICanBeAttacked
    {
        public int CurrentHealth { get; }
        public int MaxHealth { get; }

        public event EventHandler<AttackArgs>? BeforeAttacked;
        public event EventHandler<AttackArgs>? AfterAttacked;
        public event EventHandler<AttackArgs>? BeforeDeath;
        public event EventHandler<AttackArgs>? AfterDeath;

        public void TakeDamage(ICanAttack attacker, int damage);
    }
}