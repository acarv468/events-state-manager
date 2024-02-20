using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Profiling;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    public GameStateObject currentState;
    public GameStateObject previousState;

    [SerializeField]
    private GameEvent changeStateEvent;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeCurrentStateListener(Component sender, object newStateSent)
    {
        GameStateObject newState = (GameStateObject)newStateSent;
        ChangeCurrentState(newState);
    }

    public void ChangeCurrentState(GameStateObject newState)
    {
        if (newState != currentState)
        {
            currentState.OnStateExit(newState);
            previousState = currentState;
            currentState = newState;
            currentState.OnStateEnter(previousState);
        }
        else
        {
            Debug.Log("You're trying to change the current state to itself", this);
        }

        changeStateEvent.Raise(this, null);
    }
}
