using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Storage.PlayerTag))
        {
            _animator.enabled = false;
        }
    }
}
