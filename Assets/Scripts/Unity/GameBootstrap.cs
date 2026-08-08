using UnityEngine;

public class GameBootstrap : MonoBehaviour
{
    [SerializeField] private SimulationRunner _simulationRunner;

    private void Awake()
    {
        var populationAsset = Resources.Load<TextAsset>("Config/population");
        var consumptionAsset = Resources.Load<TextAsset>("Config/consumption");

        if (populationAsset == null || consumptionAsset == null)
        {
            Debug.LogError("GameBootstrap: could not load Config/population.json or " +
                "Config/consumption.json from Resources. Check the files exist at " +
                "Assets/Resources/Config/ and the .json extension is present.");
            return;
        }

        var populationConfig = ConfigLoader.ParsePopulation(populationAsset.text);
        var consumptionConfig = ConfigLoader.ParseConsumption(consumptionAsset.text);

        var simulation = new ColonySimulation(populationConfig, consumptionConfig);
        _simulationRunner.Initialize(simulation, secondsPerGameDay: 1f);
    }
}