using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    [SerializeField] private GameStateObject newState;

    // Start is called before the first frame update
    void Start()
    {
        GameStateManager.Instance.ChangeCurrentState(newState);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
