using UnityEngine;

public class PickUpMashroom : MonoBehaviour
{
    [SerializeField] private EventsSO _events;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Storage.PlayerTag))
        {
            _events.InvokeMashroomCatch(-10);
            Destroy(gameObject);
        }
    }
}
