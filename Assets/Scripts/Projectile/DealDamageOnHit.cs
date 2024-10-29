using UnityEngine;



public class DealDamageOnHit : MonoBehaviour
{
    [SerializeField] private RegisterHit _hitRegistry;
    [SerializeField] private float _damage;



    void Start()
    {
        _hitRegistry.OnHit += TryDealDamage;
    }

    private void TryDealDamage(GameObject arg0)
    {
        Health health = arg0.GetComponent<Health>();

        if (health == null)
            health = arg0.transform.root.GetComponent<Health>();

        if (health != null)
            health.Damage(_damage);
    }
}
