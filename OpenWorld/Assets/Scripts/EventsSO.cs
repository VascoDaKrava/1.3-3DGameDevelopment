using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PickupEvent : UnityEvent<int> { }

[System.Serializable]
public class PickupFind : UnityEvent<Transform> { }

[CreateAssetMenu]
public class EventsSO : ScriptableObject
{
    public PickupEvent PickupBananaEvent;
    public PickupEvent PickupMashroomEvent;
    public PickupEvent PickupAIDEvent;
    
    public PickupFind PickupFind;
    public PickupFind PickupLost;

    public void InvokeBananaCatch(int quantity)
    {
        PickupBananaEvent.Invoke(quantity);
    }

    public void InvokeMashroomCatch(int damage)
    {
        PickupMashroomEvent.Invoke(damage);
    }

    public void InvokeAIDCatch(int power)
    {
        PickupAIDEvent.Invoke(power);
    }

    public void InvokePickupFind(Transform trans)
    {
        PickupFind.Invoke(trans);
    }
    
    public void InvokePickupLost(Transform trans)
    {
        PickupLost.Invoke(trans);
    }
}
