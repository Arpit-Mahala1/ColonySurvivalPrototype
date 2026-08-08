using Newtonsoft.Json;

public static class ConfigLoader
{
    public static PopulationConfig ParsePopulation(string json) =>
        JsonConvert.DeserializeObject<PopulationConfig>(json);

    public static ConsumptionConfig ParseConsumption(string json) =>
        JsonConvert.DeserializeObject<ConsumptionConfig>(json);
}