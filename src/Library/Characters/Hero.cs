using System.ComponentModel.Design;
using Ucu.Poo.RoleplayGame;

namespace Library.Characters;

public class Hero : Character
{
    public int VictoryPoints { get; set; }
    
    public Hero(string name) : base(name)
    {
        this.VictoryPoints = 0;
        this.Damage = 10;
    }

    public void AddtVP(int points)
    {
        this.VictoryPoints += points;
    }

    public void Attack(Enemy enemy)
    {
        if (enemy.Health > 0)
        {
            enemy.RecieveAttack(this.Damage);
            if (enemy.Health <= 0)
            {
                this.AddtVP(enemy.VictoryPoints);
            }
        }
    }
}