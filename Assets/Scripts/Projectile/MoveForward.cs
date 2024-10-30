using UnityEngine;



public class MoveForward : MonoBehaviour
{
    public float Speed { get => _speed; }

    [SerializeField] private float _speed;



    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime); 
    }
}
