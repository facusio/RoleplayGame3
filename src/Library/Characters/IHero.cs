namespace Ucu.Poo.RoleplayGame;

public interface IHero : ICharacter
{
    int VictoryPoints { get; }
    void AddVictoryPoints(int vp);
}