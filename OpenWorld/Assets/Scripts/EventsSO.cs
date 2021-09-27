using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickupEvent : UnityEvent<int> { }

[CreateAssetMenu][System.Serializable]
public class EventsSO : ScriptableObject
{
    public PickupEvent _pickupEvent;

    public void InvokeBananaCatch(int asd)
    {
        _pickupEvent.Invoke(1);
        Debug.Log("Check!");
    }

    public void SubscribePickupEvent()
    {
        _pickupEvent.AddListener(Boom);
    }

    public void Boom(int asd)
    {
        _pickupEvent.Invoke(1);
    }
}
