using UnityEngine;
using UnityEngine.Events;



public class RegisterHit : MonoBehaviour
{
    public event UnityAction<GameObject> OnHit;
    public event UnityAction OnAfterHit;

    [SerializeField] private MoveForward _moveForward;



    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, _moveForward.Speed * Time.deltaTime);

        if (hit == true)
        {
            OnHit?.Invoke(hit.collider.gameObject);

            OnAfterHit?.Invoke();
        }
    }
}
