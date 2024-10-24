using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization.Metadata;
using Library.Characters;

namespace Ucu.Poo.RoleplayGame;

public class Wizard : Hero, IMagicCharacter
{
    private List<IMagicalItem> magicalItems = new List<IMagicalItem>();

    public Wizard(string name) : base(name)
    {
        this.AddItem(new Staff());
    }

    public override int AttackValue
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

            foreach (IMagicalItem item in this.magicalItems)
            {
                if (item is IMagicalAttackItem)
                {
                    value += (item as IMagicalAttackItem).AttackValue;
                }
            }

            return value;
        }
    }

    public override int DefenseValue
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

            foreach (IMagicalItem item in this.magicalItems)
            {
                if (item is IMagicalDefenseItem)
                {
                    value += (item as IMagicalDefenseItem).DefenseValue;
                }
            }

            return value;
        }
    }

    public void AddItem(IMagicalItem item)
    {
        this.magicalItems.Add(item);
    }

    public void RemoveItem(IMagicalItem item)
    {
        this.magicalItems.Remove(item);
    }
}