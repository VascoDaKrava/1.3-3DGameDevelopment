using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private EventsSO _eventSO;

    [SerializeField] private int _health = 100;

    private Animator _animator;
    private IKControl _animatorIK;

    private int _bananaQuantity = 0;

    public int Health { get { return _health; } }

    public int Bananas { get { return _bananaQuantity; } }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animatorIK = GetComponent<IKControl>();
        _eventSO.PickupBananaEvent.AddListener(GetBanana);
        _eventSO.PickupMashroomEvent.AddListener(ChangeHealth);
        _eventSO.PickupAIDEvent.AddListener(ChangeHealth);
        _eventSO.PickupFind.AddListener(ActivateIK);
        _eventSO.PickupLost.AddListener(DeactivateIK);
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

    private void ActivateIK(Transform findThis)
    {
        _animatorIK.PickUpTransform = findThis;
        _animatorIK.ActivateIK = true;
    }

    private void DeactivateIK(Transform trans)
    {
        _animatorIK.ActivateIK = false;
    }

    private void Die()
    {
        Storage.ToLog(this, Storage.GetCallerName(), "Death is coming so soon..");
        Destroy(gameObject);
    }
}
