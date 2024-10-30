using Mirror;
using UnityEngine;



public class DealDamageOnHit : MonoBehaviour
{
    [SerializeField] private RegisterHit _hitRegistry;
    [SerializeField] private float _damage;



    void Start()
    {
        if (NetworkManager.singleton.mode == NetworkManagerMode.Host || NetworkManager.singleton.mode == NetworkManagerMode.ServerOnly)
            _hitRegistry.OnHit += TryDealDamage;
    }

    private void TryDealDamage(GameObject arg0)
    {

        Health health = arg0.GetComponent<Health>();

        if (health == null)
            health = arg0.transform.root.GetComponent<Health>();

        if (health != null)
            health.SvDamage(_damage);
    }
}
