using UnityEngine;

public class PickUpAID : MonoBehaviour
{
    [SerializeField] private EventsSO _events;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Storage.PlayerTag))
        {
            _events.InvokeAIDCatch(50);
            Destroy(gameObject);
        }
    }
}
