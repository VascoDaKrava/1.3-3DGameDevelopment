using UnityEngine;

public class PickUpBanana : MonoBehaviour
{
    [SerializeField] private EventsSO _events;
    private int _quantity = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Storage.PlayerTag))
        {
            _events.InvokeBananaCatch(_quantity);
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
