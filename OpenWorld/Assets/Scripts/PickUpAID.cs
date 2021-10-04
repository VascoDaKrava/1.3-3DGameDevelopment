using UnityEngine;

public class PickUpAID : MonoBehaviour
{
    [SerializeField] private EventsSO _events;
    private int _power = 25;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Storage.PlayerTag))
        {
            _events.InvokeAIDCatch(_power);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Storage.PlayerTag))
        {
            _events.InvokePickupFind(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Storage.PlayerTag))
        {
            _events.InvokePickupLost(transform);
        }
    }
}
