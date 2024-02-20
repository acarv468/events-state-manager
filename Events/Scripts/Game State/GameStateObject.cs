using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "Game State Object")]
public class GameStateObject : ScriptableObject
{
    [SerializeField]
    private GameEvent stateEnterEvent;
    [SerializeField]
    private GameEvent stateExitEvent;

    public virtual void OnStateEnter(GameStateObject previousState)
    {
        stateEnterEvent.Raise(null, this);
    }

    public virtual void OnStateExit(GameStateObject nextState)
    {
        stateExitEvent.Raise(null, this);
    }
}
