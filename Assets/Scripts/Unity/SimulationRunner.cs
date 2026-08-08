using System;
using UnityEngine;

public class SimulationRunner : MonoBehaviour
{
    public event Action<ColonyState> OnStateChanged;

    /// Cached so late subscribers can pull the current state instead of relying on
    /// event timing — see ColonyUIController.OnEnable for why this matters.
    public ColonyState? CurrentState { get; private set; }

    private ColonySimulation _simulation;
    private GameClock _clock;

    public void Initialize(ColonySimulation simulation, float secondsPerGameDay)
    {
        _simulation = simulation;
        _clock = new GameClock(secondsPerGameDay);
        CurrentState = _simulation.GetState();
        OnStateChanged?.Invoke(CurrentState.Value);
    }

    private void Update()
    {
        if (_simulation == null) return;

        int daysElapsed = _clock.Tick(Time.deltaTime);
        for (int i = 0; i < daysElapsed; i++)
        {
            _simulation.AdvanceDay();
        }
        if (daysElapsed > 0)
        {
            CurrentState = _simulation.GetState();
            OnStateChanged?.Invoke(CurrentState.Value);
        }
    }
}