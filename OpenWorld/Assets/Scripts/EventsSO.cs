using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PickupEvent : UnityEvent<int> { }

[CreateAssetMenu]
public class EventsSO : ScriptableObject
{
    public PickupEvent PickupBananaEvent;
    public PickupEvent PickupMashroomEvent;
    public PickupEvent PickupAIDEvent;

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
        PickupMashroomEvent.Invoke(power);
    }
}
