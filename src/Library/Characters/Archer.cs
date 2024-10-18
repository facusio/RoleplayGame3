using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Archer: IHero
{
    private int health = 100;
    private int victorypoints = 0;
    private List<IItem> items = new List<IItem>();

    public Archer(string name)
    {
        this.Name = name;
        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }

    public string Name { get; set; }

    public int VictoryPoints
    {
        get
        {
            return this.victorypoints;
        }
        set
        {
            
        }
    }

    public void AddVictoryPoints(int vp)
    {
        this.victorypoints += vp;
        if (this.victorypoints >= 5)
        {
            this.Cure();
        }
    }

    public int AttackValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IAttackItem)
                {
                    value += (item as IAttackItem).AttackValue;
                }
            }
            return value;
        }
        set
        {
            
        }
    }

    public int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.items)
            {
                if (item is IDefenseItem)
                {
                    value += (item as IDefenseItem).DefenseValue;
                }
            }
            return value;
        }
    }

    public int Health
    {
        get
        {
            return this.health;
        }
        set
        {
            if (value < 0)
            {
                this.health = 0;
            }
            else
            {
                this.health = value;
            }
        }
    }

    public void ReceiveAttack(int power)
    {
        if (this.DefenseValue < power)
        {
            this.Health -= power - this.DefenseValue;
        }
    }

    public void Cure()
    {
        this.Health = 100;
    }

    public void AddItem(IItem item)
    {
        this.items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        this.items.Remove(item);
    }
}
