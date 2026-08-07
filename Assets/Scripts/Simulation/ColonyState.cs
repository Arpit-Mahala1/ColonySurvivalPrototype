public readonly struct ColonyState
{
    public readonly int DayCount;
    public readonly float FoodStored;
    public readonly float WaterStored;
    public readonly float FoodDaysRemaining;
    public readonly float WaterDaysRemaining;
    public readonly bool IsStarving;

    public ColonyState(int dayCount, float foodStored, float waterStored,
        float foodDaysRemaining, float waterDaysRemaining, bool isStarving)
    {
        DayCount = dayCount;
        FoodStored = foodStored;
        WaterStored = waterStored;
        FoodDaysRemaining = foodDaysRemaining;
        WaterDaysRemaining = waterDaysRemaining;
        IsStarving = isStarving;
    }
}