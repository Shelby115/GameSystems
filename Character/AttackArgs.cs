namespace GameSystems.Character
{
    public class AttackArgs : EventArgs
    {
        public ICanAttack Attacker { get; }
        public ICanBeAttacked Target { get; }
        public int Damage { get; }

        public AttackArgs(ICanAttack attacker, ICanBeAttacked target, int damage)
        {
            Attacker = attacker;
            Target = target;
            Damage = damage;
        }
    }
}