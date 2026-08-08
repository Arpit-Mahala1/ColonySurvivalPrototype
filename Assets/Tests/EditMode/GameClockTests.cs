using NUnit.Framework;

public class GameClockTests
{
    [Test]
    public void Tick_OneSecondAtOneSecondPerDay_ReturnsOneDay()
    {
        var clock = new GameClock(secondsPerGameDay: 1f);
        Assert.AreEqual(1, clock.Tick(1f));
    }

    [Test]
    public void Tick_PartialSecond_ReturnsZeroDaysAndAccumulates()
    {
        var clock = new GameClock(secondsPerGameDay: 1f);
        Assert.AreEqual(0, clock.Tick(0.6f));
        Assert.AreEqual(1, clock.Tick(0.5f)); // 0.6 + 0.5 = 1.1s -> 1 day, 0.1s carried over
    }

    [Test]
    public void Tick_MultipleDaysInOneCall_ReturnsCorrectCount()
    {
        var clock = new GameClock(secondsPerGameDay: 1f);
        Assert.AreEqual(3, clock.Tick(3.2f)); // simulates a long frame / lag spike
    }
}