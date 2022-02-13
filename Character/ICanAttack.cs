namespace GameSystems.Character
{
    public interface ICanAttack
    {
        public int AttackDamage { get; }

        public event EventHandler<AttackArgs>? BeforeAttack;
        public event EventHandler<AttackArgs>? AfterAttack;

        public void Attack(ICanBeAttacked target);
    }
}