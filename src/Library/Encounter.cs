using System.Runtime.CompilerServices;
using System.Collections.Generic;
using Library.Characters;
using Ucu.Poo.RoleplayGame;

namespace Library;

public class Encounter
{
    private List<Hero> heroes;
    private List<Enemy> enemies;

    public Encounter(List<Hero> heroes, List<Enemy> enemies)
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

    public bool HeroesAreAlive()
    {
        foreach (Hero hero in heroes)
        {
            if (hero.Health > 0)
            {
                return true;
            }
        }

        return false;
    }

    public bool EnemiesAreAlive()
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
        foreach (Enemy enemy in enemies)
        {
            if (enemy.Health > 0)
            {
                foreach (Hero hero in heroes)
                {
                    if (hero.Health > 0)
                    {
                        hero.RecieveAttack(enemy.AttackValue);
                        return; // Con este return lo que hago es salir del bucle, ya que el enemigo ya ataco una vez.
                    }
                }
            }
        }
    }

    private void HeroesAttack()
    {
        foreach (Hero hero in heroes)
        {
            if (hero.Health > 0)
            {
                foreach (Enemy enemy in enemies)
                {
                    if (enemy.Health > 0)
                    {
                        enemy.RecieveAttack(hero.AttackValue);

                        if (enemy.Health < 0)
                        {
                            if (hero is Hero specificHero) // Esto es para asegurarme de que es un Heroe
                            {
                                specificHero.AddtVP(1);

                                if (specificHero.VictoryPoints >= 5)
                                {
                                    specificHero.Cure();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}