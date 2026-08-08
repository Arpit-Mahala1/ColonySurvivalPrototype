using NUnit.Framework;

public class ConfigLoaderTests
{
    [Test]
    public void ParsePopulation_ValidJson_ReturnsCorrectValues()
    {
        string json = "{\"villagerCount\": 12, \"startingFood\": 150.0, \"startingWater\": 120.0}";

        PopulationConfig config = ConfigLoader.ParsePopulation(json);

        Assert.AreEqual(12, config.VillagerCount);
        Assert.AreEqual(150.0f, config.StartingFood, 0.001f);
        Assert.AreEqual(120.0f, config.StartingWater, 0.001f);
    }

    [Test]
    public void ParseConsumption_ValidJson_ReturnsCorrectValues()
    {
        string json = "{\"foodPerVillagerPerGameDay\": 2.0, \"waterPerVillagerPerGameDay\": 3.0}";

        ConsumptionConfig config = ConfigLoader.ParseConsumption(json);

        Assert.AreEqual(2.0f, config.FoodPerVillagerPerGameDay, 0.001f);
        Assert.AreEqual(3.0f, config.WaterPerVillagerPerGameDay, 0.001f);
    }

    [Test]
    public void ParsePopulation_PascalCaseJsonKeys_StillParsesCorrectly()
    {
        // Proves Newtonsoft's case-insensitive key matching actually works here,
        // not just assumed — see the note in Section 5.4.
        string json = "{\"VillagerCount\": 5, \"StartingFood\": 50.0, \"StartingWater\": 40.0}";

        PopulationConfig config = ConfigLoader.ParsePopulation(json);

        Assert.AreEqual(5, config.VillagerCount);
        Assert.AreEqual(50.0f, config.StartingFood, 0.001f);
    }
}