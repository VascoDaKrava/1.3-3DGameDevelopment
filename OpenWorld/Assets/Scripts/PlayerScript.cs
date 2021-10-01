using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private EventsSO _eventSO;

    [SerializeField] private int _health = 100;

    private Animator _animator;

    private int _bananaQuantity = 0;

    public int Health { get { return _health; } }

    public int Bananas { get { return _bananaQuantity; } }

    private void Start()
    {
        _eventSO.PickupBananaEvent.AddListener(GetBanana);
        _eventSO.PickupMashroomEvent.AddListener(ChangeHealth);
        _eventSO.PickupAIDEvent.AddListener(ChangeHealth);
        _animator = GetComponentInChildren<Animator>();
    }

    /// <summary>
    /// Change Health
    /// </summary>
    /// <param name="newHealth"></param>
    public void ChangeHealth(int newHealth)
    {
        _animator.SetTrigger("DoLifting");
        _health += newHealth;

        if (_health > 100) _health = 100;
        if (_health <= 0) Die();
    }

    private void GetBanana(int quantity)
    {
        _animator.SetTrigger("DoLifting");
        _bananaQuantity += quantity;
    }

    private void Die()
    {
        Storage.ToLog(this, Storage.GetCallerName(), "Death is coming so soon..");
        Destroy(gameObject);
    }
}
