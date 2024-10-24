using Library.Characters;
namespace Ucu.Poo.RoleplayGame;

public class Enemy : Character
{
    public int VictoryPoints { get; }
    public Enemy(string name, int victoryPoints) : base(name)
    {
        this.VictoryPoints = victoryPoints;
        this.Damage = 5;
        
        this.AddItem(new Sword());
        this.AddItem(new Sword());
    }

    public void Attack(Hero hero)
    {
        if (hero.Health > 0)
        {
            int damage = this.Damage;
            hero.RecieveAttack(damage);
        }
        else
        {
            Console.WriteLine($"{hero.Name} ya esta muerto.");
        }
    }
}