using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

public class DwarfTests
{
    [Test]
    public void TestDwarf()
    {
        // Arrange
        Axe salamalecons = new Axe();
        Helmet helmetlvl1 = new Helmet();

        Dwarf brokk = new Dwarf("Brokk");
        
        brokk.AddItem(salamalecons);
        brokk.AddItem(helmetlvl1);

        Axe karambit = new Axe();
        Helmet helmetlvl2 = new Helmet();

        Dwarf minidwarf = new Dwarf("Kokemon");
        
        minidwarf.AddItem(karambit);
        minidwarf.AddItem(helmetlvl2);
        
        // Act
        minidwarf.ReceiveAttack(brokk.AttackValue);
        
        // Assert
        Assert.That(minidwarf.Health, Is.EqualTo(86));
        Assert.That(brokk.Health, Is.EqualTo(100));
    }
}