using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameEvent is a ScriptableObject that can be used to raise events and notify object that has GameEventListener component.
/// 
/// How To Use :
/// 1. Create a GameEvent ScriptableObject
/// 2. Put Game Event as one of the variable in the Class that has event to be raised.
/// 3. Raise the event using `Event.Raise(this, data)
///    - data can be any object, or null if not needed. (You can simple use Event.Raise(this) if no data is needed)
/// 4. Create a GameEventListener component in a game object, and assign the GameEvent and the response method.
/// 5. The response method should have the signature `void ResponseMethod(Component sender, object data)`
///    - `sender` is the component that raised the event, and `data` is the data passed with the event.
///    - Example of response method : ResponseMethod(Component sender, object data), if no data is needed, simply 'ResponseMethod()'.
/// 6. The response method will be invoked when the event is raised.
/// </summary>

namespace EventListener
{
    [CreateAssetMenu(fileName = "GameEvent")]
    [System.Serializable]
    public class GameEvent : ScriptableObject
    {
        // Start is called before the first frame update
        public List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise(Component sender, object data = null)
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(sender, data);
            }
        }

        public void RegisterListeners(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }

        public void UnRegisterListeners(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
        }

        protected void OnReset()
        {
            listeners.Clear();
        }
    }
}
