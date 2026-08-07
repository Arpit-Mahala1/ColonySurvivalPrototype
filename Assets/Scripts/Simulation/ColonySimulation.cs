public class ColonySimulation
{
    private readonly PopulationConfig _population;
    private readonly ConsumptionConfig _consumption;

    private float _foodStored;
    private float _waterStored;
    private int _dayCount;

    public ColonySimulation(PopulationConfig population, ConsumptionConfig consumption)
    {
        _population = population;
        _consumption = consumption;
        _foodStored = population.StartingFood;
        _waterStored = population.StartingWater;
        _dayCount = 0;
    }

    public float DailyFoodConsumption => _population.VillagerCount * _consumption.FoodPerVillagerPerGameDay;
    public float DailyWaterConsumption => _population.VillagerCount * _consumption.WaterPerVillagerPerGameDay;

    /// Advances the simulation by exactly one game day. Deducts consumption, never goes below zero.
    public void AdvanceDay()
    {
        _dayCount++;
        _foodStored = System.Math.Max(0f, _foodStored - DailyFoodConsumption);
        _waterStored = System.Math.Max(0f, _waterStored - DailyWaterConsumption);
    }

    public float GetFoodDaysRemaining() =>
        DailyFoodConsumption <= 0f ? float.PositiveInfinity : _foodStored / DailyFoodConsumption;

    public float GetWaterDaysRemaining() =>
        DailyWaterConsumption <= 0f ? float.PositiveInfinity : _waterStored / DailyWaterConsumption;

    public bool IsStarving => _foodStored <= 0f || _waterStored <= 0f;

    public ColonyState GetState() => new ColonyState(
        _dayCount, _foodStored, _waterStored,
        GetFoodDaysRemaining(), GetWaterDaysRemaining(), IsStarving);
}