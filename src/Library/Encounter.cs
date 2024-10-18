using System.Runtime.CompilerServices;
using Ucu.Poo.RoleplayGame;

namespace Library;

public class Encounter
{
    private List<IHero> heroes;
    private List<Enemy> enemies;

    public Encounter(List<IHero> heroes, List<Enemy> enemies)
    {
        this.heroes = heroes;
        this.enemies = enemies;
    }

    public void DoEncounter()
    {
        while (HeroesAreAlive() && EnemiesAreAlive())
        {
            EnemiesAttack();
            HeroesAttack();
        }
    }

    private bool HeroesAreAlive()
    {
        foreach (IHero hero in heroes)
        {
            if (hero.Health > 0)
            {
                return true;
            }
        }

        return false;
    }

    private bool EnemiesAreAlive()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.Health > 0)
            {
                return true;
            } 
        }
        return false;
    }

    private void EnemiesAttack()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            Enemy enemy = enemies[i];
            IHero hero = heroes[i % heroes.Count];
            if (enemy.Health > 0 && hero.Health > 0)
            {
                hero.ReceiveAttack(enemy.AttackValue);
            }
        }
    }

    private void HeroesAttack()
    {
        for (int i = 0; i < heroes.Count; i++)
        {
            IHero hero = heroes[i];
            if (hero.Health > 0)
            {
                for (int j = 0; j < enemies.Count; j++)
                {
                    Enemy enemy = enemies[j];
                    if (enemy.Health > 0)
                    {
                        enemy.ReceiveAttack(hero.AttackValue);

                        if (enemy.Health <= 0)
                        {
                            hero.AddVictoryPoints(1);

                            if (hero.VictoryPoints >= 5)
                            {
                                hero.Cure();
                            }
                        }
                    }
                }
            }
        }
    }
}