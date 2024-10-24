using System.Collections.Generic;
using Library.Characters;

namespace Ucu.Poo.RoleplayGame;

public class Knight: Hero
{
    public Knight(string name): base(name)
    {
        this.AddItem(new Sword());
        this.AddItem(new Armor());
        this.AddItem(new Shield());
    }
}
