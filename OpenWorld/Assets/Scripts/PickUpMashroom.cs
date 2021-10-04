using UnityEngine;

public class PickUpMashroom : MonoBehaviour
{
    [SerializeField] private EventsSO _events;
    private int _damage = -10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Storage.PlayerTag))
        {
            _events.InvokeMashroomCatch(_damage);
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
