using UnityEngine;
using UnityEngine.Events;



public class RegisterHit : MonoBehaviour
{
    public event UnityAction<GameObject> OnHit;
    public event UnityAction OnAfterHit;



    void OnTriggerEnter2D(Collider2D other)
    {
        if (OnHit != null)
            OnHit(other.gameObject);

        if (OnAfterHit != null)
            OnAfterHit();
    }
}
