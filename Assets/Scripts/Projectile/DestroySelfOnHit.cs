using Mirror;
using UnityEngine;



public class DestroySelfOnHit : MonoBehaviour
{
    [SerializeField] private RegisterHit _hitRegistry;



    void Start()
    {
        _hitRegistry.OnAfterHit += DestroySelf;
    }

    private void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }
}
