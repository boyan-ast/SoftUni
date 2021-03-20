using NUnit.Framework;

[TestFixture]
public class AxeTests
{
    private int attackPoints = 1;
    private int durabilityPoints = 10;
    private Axe axe;
    private Dummy dummy;

    [SetUp]
    public void SetUp()
    {
        this.axe = new Axe(this.attackPoints, this.durabilityPoints);
        this.dummy = new Dummy(5, 20);
    }

    [Test]
    public void AttackPointsShouldBeSetCorrectly()
    {
        Assert.That(this.axe.AttackPoints, Is.EqualTo(this.attackPoints), 
            $"The attack points should be equal to {attackPoints}");
    }

    [Test]
    public void DurabilityPointsShouldBeSetCorrectly()
    {
        Assert.That(this.axe.DurabilityPoints, Is.EqualTo(this.durabilityPoints));
    }

    [Test]
    public void WhenAttackDummyDurabilityShouldDecreaseWithOne()
    {
        this.axe.Attack(dummy);

        Assert.That(this.axe.DurabilityPoints, Is.EqualTo(this.durabilityPoints - 1));
    }

    [Test]
    public void WhenAttackWithDurabilityPointsEqualToZeroShouldThrow()
    {
        axe = new Axe(2, 0);

        Assert.That(() => { axe.Attack(dummy); }, 
            Throws.InvalidOperationException
            .With.Message.EqualTo("Axe is broken."));
    }

    [Test]
    public void WhenAttackWithNegativeDurabilityPointsShoudThrow()
    {
        axe = new Axe(1, -10);

        Assert.That(() => { axe.Attack(dummy); },
            Throws.InvalidOperationException
            .With.Message.EqualTo("Axe is broken."));
    }
}