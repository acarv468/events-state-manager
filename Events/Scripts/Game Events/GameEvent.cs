using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "Game Event", menuName = "Game Events/New Game Event")]
public class GameEvent : ScriptableObject
{
    [SerializeField]
    private bool debug;


    public List<GameEventListener> eventListeners =
            new List<GameEventListener>();

    public void Raise(Component sender, object data)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(sender, data);
            if (debug)
            {
                Debug.Log("Sender: " + sender.gameObject.name, sender);
                Debug.Log("Listener: " + eventListeners[i].gameObject.name, eventListeners[i].gameObject);
            }
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(GameEvent), editorForChildClasses: true)]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        GUI.enabled = Application.isPlaying;

        GameEvent e = target as GameEvent;
        if (GUILayout.Button("Raise"))
        {

            //e.Raise(FindAnyObjectByType<GameObject>());
            e.Raise(FindAnyObjectByType<Component>(), this.name);
        }
    }
}
#endif