using Mirror;
using UnityEngine;



public class DestroySelfOnDie : MonoBehaviour
{
    [SerializeField] private Health _health;



    void Start()
    {
        _health.Died += DestroySelf;
    }



    private void DestroySelf()
    {
        NetworkServer.Destroy(gameObject);
    }
}
