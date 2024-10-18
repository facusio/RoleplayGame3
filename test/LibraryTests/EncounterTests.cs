using NUnit.Framework;
using System.Collections.Generic;
using Ucu.Poo.RoleplayGame;
using Library;

namespace LibraryTests;

public class EncounterTests
{
    [Test]
    public void HeroesAreAlive_ReturnsTrue_WhenAnyHeroIsAlive()
    {
        // Arrange
        var heroes = new List<IHero>
        {
            new Hero { Health = 10 },
            new Hero { Health = 0 }
        };
        var enemies = new List<Enemy>
        {
            new Enemy { Health = 10 }
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
        var heroes = new List<IHero>
        {
            new Hero { Health = 0 },
            new Hero { Health = 0 }
        };
        var enemies = new List<Enemy>
        {
            new Enemy { Health = 10 }
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
        var heroes = new List<IHero>
        {
            new Hero { Health = 10 }
        };
        var enemies = new List<Enemy>
        {
            new Enemy { Health = 10 },
            new Enemy { Health = 0 }
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
        var heroes = new List<IHero>
        {
            new Hero { Health = 10 }
        };
        var enemies = new List<Enemy>
        {
            new Enemy { Health = 0 },
            new Enemy { Health = 0 }
        };
        var encounter = new Encounter(heroes, enemies);

        // Act
        bool result = encounter.EnemiesAreAlive();

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void DoEncounter_HeroesGainVictoryPoints_WhenEnemyIsDefeated()
    {
        // Arrange
        var hero = new Hero { Health = 10, AttackValue = 5 };
        var enemy = new Enemy { Health = 5 };
        var heroes = new List<IHero> { hero };
        var enemies = new List<Enemy> { enemy };
        var encounter = new Encounter(heroes, enemies);

        // Act
        encounter.DoEncounter();

        // Assert
        Assert.That(hero.VictoryPoints, Is.EqualTo(1));
    }

    [Test]
    public void DoEncounter_HeroesHeal_WhenTheyReachFiveVictoryPoints()
    {
        // Arrange
        var hero = new Hero { Health = 10, AttackValue = 10, VictoryPoints = 5 };
        var enemy = new Enemy { Health = 10 };
        var heroes = new List<IHero> { hero };
        var enemies = new List<Enemy> { enemy };
        var encounter = new Encounter(heroes, enemies);

        // Act
        encounter.DoEncounter();

        // Assert
        Assert.That(hero.Health, Is.EqualTo(10)); // Suponiendo que Cure() restablece la salud completa
    }
}
