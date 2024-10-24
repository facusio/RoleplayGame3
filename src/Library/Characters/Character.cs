using Ucu.Poo.RoleplayGame;
namespace Library.Characters;

public abstract class Character : ICharacter
{
    private int health = 100;
    public string Name { get; set; }
    public int Damage { get; set; }
    protected readonly List<IItem> Items = new List<IItem>();
    

    public Character(string name)
    {
        this.Name = name;
    }

    public virtual int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.Items)
            {
                if (item is IDefenseItem)
                {
                    value += (item as IDefenseItem).DefenseValue;
                }
            }

            return value;
        }
    }

    public virtual int AttackValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.Items)
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
            //Lo preciso para EncounterTests.
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

    public void AddItem(IItem item)
    {
        this.Items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        this.Items.Remove(item);
    }

    public void Cure()
    {
        this.Health = 100;
    }

    public void RecieveAttack(int power)
    {
        int damage = power - this.DefenseValue;
        if (damage > 0)
        {
            this.Health -= damage;
        }
        else
        {
            this.Health -= 1;
        }

        if (this.Health < 0)
        {
            this.Health = 0;
        }
    }

    public void Attack(Character objective)
    {
        if (objective.Health > 0)
        {
            int damage = this.AttackValue;
            objective.RecieveAttack(damage);
        }
        else
        {
            Console.WriteLine($"{objective.Name} ya esta muerto");
        }
    }
}