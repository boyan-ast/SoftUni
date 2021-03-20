using NUnit.Framework;

[TestFixture]
public class DummyTests
{
    private int health = 5;
    private int deadDummyHealth = -5;
    private int experience = 10;
    private Dummy dummy;
    private Dummy deadDummy;
    private int attackPoints = 2;

    [SetUp]
    public void SetUp()
    {
        this.dummy = new Dummy(this.health, this.experience);
        this.deadDummy = new Dummy(deadDummyHealth, this.experience);
    }

    [Test]
    public void HealthGetterShouldReturnCorrectValue()
    {
        Assert.That(this.dummy.Health, Is.EqualTo(this.health),
            "The Helath property should correspond to the inpud value.");
    }

    [Test]
    public void WhenAttackedHealthShouldDecreaseWithTheGivenPoints()
    {
        this.dummy.TakeAttack(this.attackPoints);

        Assert.That(this.dummy.Health, 
            Is.EqualTo(this.health - this.attackPoints));
    }

    [Test]
    public void WhenDeadIsAttackedShouldBeThrown()
    {
        Assert.That(() => { this.deadDummy.TakeAttack(this.attackPoints); }, 
            Throws.InvalidOperationException
            .With.Message.EqualTo("Dummy is dead."));
    }

    [Test]
    public void WhenIsNotDeadGiveExperienceShouldThrow()
    {
        Assert.That(() => { int experience = this.dummy.GiveExperience(); }, 
            Throws.InvalidOperationException
            .With.Message.EqualTo("Target is not dead."));
    }

    [Test]
    public void WhenIsDeadGiveExperienceShouldReturnTheExperience()
    {
        Assert.That(this.deadDummy.GiveExperience(), Is.EqualTo(this.experience));
    }

    [Test]
    public void WhenHealthIsNegativeOrZeroShouldBeDead()
    {
        Assert.That(this.deadDummy.IsDead(), Is.EqualTo(true));
    }

    [Test]
    public void WhenHealthIsPositiveShouldNotBeDead()
    {
        Assert.That(this.dummy.IsDead(), Is.EqualTo(false));
    }
}
