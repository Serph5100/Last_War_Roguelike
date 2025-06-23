using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// GameEventListener is a component that listens to a GameEvent and invokes a response when the event is raised.
/// 
/// How To Use :
/// 1. Create a GameEvent ScriptableObject
/// 2. Put Game Event as one of the variable in the Class that has event to be raised.
/// 3. Raise the event using `Event.Raise(this, data)
///    - data can be any object, or null if not needed. (You can simple use Event.Raise(this) if no data is needed)
/// 4. Create a GameEventListener component in a game object, and assign the GameEvent and the response method.
/// 5. The response method should have the signature `void ResponseMethod(Component sender, object data)`
///    - `sender` is the component that raised the event, and `data` is the data passed with the event.
///    - Example of response method : ResponseMethod(Component sender, object data)
/// 6. The response method will be invoked when the event is raised.
/// </summary>

namespace EventListener
{
    [System.Serializable]
    public class CustomGameEvent : UnityEvent<Component, object> { }

    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public CustomGameEvent Response;

        private void OnEnable()
        {
            Event.RegisterListeners(this);
        }

        private void OnDisable()
        {
            Event.UnRegisterListeners(this);
        }

        public void OnEventRaised(Component sender, object data)
        {
            Response.Invoke(sender, data);
        }
    }

}

