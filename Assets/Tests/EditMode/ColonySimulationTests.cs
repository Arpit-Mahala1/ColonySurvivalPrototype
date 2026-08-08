using NUnit.Framework;

public class ColonySimulationTests
{
    [Test]
    public void AdvanceDay_DeductsCorrectFood_MatchesBriefExample()
    {
        // 10 villagers eating 1 food/day, 100 food stored -> 70 after 3 days
        var population = new PopulationConfig { VillagerCount = 10, StartingFood = 100f, StartingWater = 1000f };
        var consumption = new ConsumptionConfig { FoodPerVillagerPerGameDay = 1f, WaterPerVillagerPerGameDay = 0f };
        var sim = new ColonySimulation(population, consumption);

        sim.AdvanceDay();
        sim.AdvanceDay();
        sim.AdvanceDay();

        Assert.AreEqual(70f, sim.GetState().FoodStored, 0.001f);
    }

    [Test]
    public void Reserves_NeverGoNegative()
    {
        var population = new PopulationConfig { VillagerCount = 10, StartingFood = 5f, StartingWater = 5f };
        var consumption = new ConsumptionConfig { FoodPerVillagerPerGameDay = 1f, WaterPerVillagerPerGameDay = 1f };
        var sim = new ColonySimulation(population, consumption);

        sim.AdvanceDay(); // would be -5 without clamping

        Assert.GreaterOrEqual(sim.GetState().FoodStored, 0f);
    }

    [Test]
    public void IsStarving_TrueOnlyWhenAResourceHitsZero()
    {
        var population = new PopulationConfig { VillagerCount = 1, StartingFood = 1f, StartingWater = 100f };
        var consumption = new ConsumptionConfig { FoodPerVillagerPerGameDay = 1f, WaterPerVillagerPerGameDay = 1f };
        var sim = new ColonySimulation(population, consumption);

        Assert.IsFalse(sim.GetState().IsStarving);
        sim.AdvanceDay();
        Assert.IsTrue(sim.GetState().IsStarving); // food hit 0, water didn't
    }
}