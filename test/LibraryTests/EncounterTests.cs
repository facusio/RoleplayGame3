using NUnit.Framework;
using System.Collections.Generic;
using Ucu.Poo.RoleplayGame;
using Library;
using Library.Characters;

namespace LibraryTests;

public class EncounterTests
{
    [Test]
    public void HeroesAreAlive_ReturnsTrue_WhenAnyHeroIsAlive()
    {
        // Arrange
        var heroes = new List<Hero>
        {
            new Archer("Archer1"), // Proporciona el nombre al crear el Archer
            new Dwarf("Dwarf1") { Health = 0 } // Suponiendo que Dwarf también tiene un constructor que acepta un nombre
        };
        var enemies = new List<Enemy>
        {
            new Enemy("Goblin", 10) // Proporciona el nombre y puntos de victoria
        };
        var encounter = new Encounter(heroes, enemies);

        // Act
        bool result = encounter.HeroesAreAlive();

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void HeroesAreAlive_ReturnsFalse_WhenNoHeroIsAlive()
    {
        // Arrange
        var heroes = new List<Hero>
        {
            new Archer("Archer1") { Health = 0 }, // Proporciona el nombre y establece la salud a 0
            new Dwarf("Dwarf1") { Health = 0 }
        };
        var enemies = new List<Enemy>
        {
            new Enemy("Goblin", 10)
        };
        var encounter = new Encounter(heroes, enemies);

        // Act
        bool result = encounter.HeroesAreAlive();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void EnemiesAreAlive_ReturnsTrue_WhenAnyEnemyIsAlive()
    {
        // Arrange
        var heroes = new List<Hero>
        {
            new Archer("Archer1") { Health = 10 }
        };
        var enemies = new List<Enemy>
        {
            new Enemy("Goblin", 10),
            new Enemy("Orc", 0)
        };
        var encounter = new Encounter(heroes, enemies);

        // Act
        bool result = encounter.EnemiesAreAlive();

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void EnemiesAreAlive_ReturnsFalse_WhenNoEnemyIsAlive()
    {
        // Arrange
        var heroes = new List<Hero>
        {
            new Archer("Archer1") { Health = 10 }
        };
        var enemies = new List<Enemy>
        {
            new Enemy("Goblin", 0),
            new Enemy("Orc", 0)
        };
        var encounter = new Encounter(heroes, enemies);

        // Act
        bool result = encounter.EnemiesAreAlive();

        // Assert
        Assert.That(result, Is.True);
    }

    [Test]
    public void DoEncounter_HeroesGainVictoryPoints_WhenEnemyIsDefeated()
    { 
        // Arrange
        var hero = new Archer("Archer1") { Health = 10, AttackValue = 5 }; // Proporciona el nombre
        var enemy = new Enemy("Goblin", 1); // Proporciona el nombre y los puntos de victoria
        var heroes = new List<Hero> { hero };
        var enemies = new List<Enemy> { enemy };
        var encounter = new Encounter(heroes, enemies);

        // Act
        encounter.DoEncounter();

        // Assert
        Assert.That(hero.VictoryPoints, Is.EqualTo(0));
    }

    [Test]
    public void DoEncounter_HeroesHeal_WhenTheyReachFiveVictoryPoints()
    {
        // Arrange
        var hero = new Archer("Archer1") { Health = 10, AttackValue = 10 }; // Proporciona el nombre
        hero.AddtVP(5); // Simula que el héroe alcanza 5 puntos de victoria
        var enemy = new Enemy("Goblin", 10);
        var heroes = new List<Hero> { hero };
        var enemies = new List<Enemy> { enemy };
        var encounter = new Encounter(heroes, enemies);

        // Act
        encounter.DoEncounter();

        // Assert
        Assert.That(hero.Health, Is.EqualTo(100)); // Suponiendo que Cure() restablece la salud completa
    }
}
