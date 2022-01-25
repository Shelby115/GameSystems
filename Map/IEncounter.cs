namespace GameSystems.Map
{
    public interface IEncounter
    {
        bool VictoryCondition();
        bool DefeatCondition();
    }
}