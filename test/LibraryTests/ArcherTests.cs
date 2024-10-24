using Library.Characters;
using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

public class ArcherTests
{
    [Test]
    public void TestArcher()
    {
        // Arrange
        Bow bow = new Bow();
        Armor lighArmor = new Armor();

        // Crear personaje Archer
        Archer arqueromagico = new Archer("Arquero Magico");
        
        arqueromagico.AddItem(bow);
        arqueromagico.AddItem(lighArmor);

        // Crear otro personaje del mismo tipo (Archer) para simular una pelea
        Bow crossbow = new Bow();
        Armor heavyArmor = new Armor();
        Archer megaarquero = new Archer("Mega Arquero");
        
        megaarquero.AddItem(crossbow);
        megaarquero.AddItem(heavyArmor);

        // Act
        // Arquero Mágico ataca a Mega Arquero
        megaarquero.RecieveAttack(arqueromagico.AttackValue);

        // Assert
        Assert.That(megaarquero.Health, Is.EqualTo(100));
    }
}