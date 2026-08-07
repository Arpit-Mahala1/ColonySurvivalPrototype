public class GameClock
{
    private readonly float _secondsPerGameDay;
    private float _accumulatedSeconds;

    public GameClock(float secondsPerGameDay)
    {
        _secondsPerGameDay = secondsPerGameDay;
    }

    /// Feed real elapsed seconds in; get back how many whole game-days just elapsed (usually 0 or 1).
    public int Tick(float deltaSeconds)
    {
        _accumulatedSeconds += deltaSeconds;
        int daysElapsed = 0;
        while (_accumulatedSeconds >= _secondsPerGameDay)
        {
            _accumulatedSeconds -= _secondsPerGameDay;
            daysElapsed++;
        }
        return daysElapsed;
    }
}