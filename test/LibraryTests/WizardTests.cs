using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace LibraryTests;

public class WizardTests
{
    [Test]
    public void TestWizard()
    {
        // Arrange
        Staff staff = new Staff();
        SpellOne fireSpell = new SpellOne();
        SpellOne iceSpell = new SpellOne();
        SpellsBook spellBook1 = new SpellsBook();
        SpellsBook spellBook2 = new SpellsBook();
        spellBook1.AddSpell(fireSpell);
        spellBook2.AddSpell(iceSpell);

        Wizard wizard1 = new Wizard("Gandalf");
        Wizard wizard2 = new Wizard("Saruman");

        // Magical Items equipped
        wizard1.AddItem(spellBook1);
        wizard2.AddItem(spellBook2);

        // Act
        wizard1.RecieveAttack(wizard2.AttackValue);
        wizard2.RecieveAttack(wizard1.AttackValue);

        // Assert - Ninguno deberría recibir daño, ya que AttackValue es igual a DefenseValue
        Assert.That(wizard1.Health, Is.EqualTo(100));
        Assert.That(wizard2.Health, Is.EqualTo(100));
    }
}



