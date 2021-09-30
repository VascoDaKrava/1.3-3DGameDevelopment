using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// For publisher
[System.Serializable]
public class PickupEvent : UnityEvent<int> { }

[CreateAssetMenu]
public class ScriptablePlace : ScriptableObject
{
    public PickupEvent _pickupEvent;

    public void InvokePickupEvent()
    {
        _pickupEvent.Invoke(1);
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
