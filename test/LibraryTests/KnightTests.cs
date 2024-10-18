using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

public class KnightTests
{
    [Test]
    public void TestKnight()
    {
        Sword coppersword = new Sword();
        Shield smallshield = new Shield();
        
        Knight knight1 = new Knight("Penny");
        
        knight1.AddItem(coppersword);
        knight1.AddItem(smallshield);
        
        Sword catana = new Sword();
        Shield bigshield = new Shield();
        
        Knight knight2 = new Knight("Stuart");
        
        knight2.AddItem(catana);
        knight2.AddItem(bigshield);

        knight2.ReceiveAttack(knight1.AttackValue);
        knight1.ReceiveAttack(knight2.AttackValue);
        
        Assert.That(knight1.Health, Is.EqualTo(100));
        Assert.That(knight2.Health, Is.EqualTo(100));
    }
}