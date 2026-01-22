using UnityEngine;

public class BikeController : MonoBehaviour
{
    // Configuration
    public float maxSpeed = 2.0f;

    public float turnDistance = 2.0f;

    // Current state data

    public float CurrentSpeed { get; set; }

    public Direction CurrentTurnDirection { get; private set; }

    // State References

    private IBikeState _startState,
        _stopState,
        _turnState;

    private BikeStateContext _bikeStateContext;

    void Start()

    {
        _bikeStateContext = new BikeStateContext(this);

        _startState = gameObject.AddComponent<BikeStartState>();

        _stopState = gameObject.AddComponent<BikeStopState>();

        _turnState = gameObject.AddComponent<BikeTurnState>();

        _bikeStateContext.Transition(_stopState);
    }

    public void StartBike() =>
        _bikeStateContext.Transition(_startState);

    public void StopBike() =>
        _bikeStateContext.Transition(_stopState);

    public void Turn(Direction direction)
    {
        CurrentTurnDirection = direction;
        _bikeStateContext.Transition(_turnState);
    }
}