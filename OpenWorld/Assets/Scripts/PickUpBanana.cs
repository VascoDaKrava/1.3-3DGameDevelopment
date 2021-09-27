using UnityEngine;

public class PickUpBanana : MonoBehaviour
{
    [SerializeField] private EventsSO _events;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(Storage.PlayerTag))
        {
            _events.InvokeBananaCatch(1);
            Destroy(gameObject);
        }
    }
}
