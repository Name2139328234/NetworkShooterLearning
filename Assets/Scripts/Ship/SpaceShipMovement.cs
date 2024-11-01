using Mirror;
using UnityEngine;



public class SpaceShipMovement : NetworkBehaviour
{
    /// <summary>
    /// Is fixed between -1 and 1
    /// </summary>
    public float SpeedControl { get => _speedControl; set => _speedControl = Mathf.Clamp(value, -1f, 1f); }
    /// <summary>
    /// Is fixed between -1 and 1
    /// </summary>
    public float TorqueControl { get => _torqueControl; set => _torqueControl = Mathf.Clamp(value, -1f, 1f); }

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    [SerializeField] private float _torque;

    private float _speedControl;
    private float _torqueControl;



    void FixedUpdate()
    {

        _rigidbody2D.velocity = transform.right * _speedControl * _speed;
        _rigidbody2D.angularVelocity = _torqueControl * _torque;
    }



    /*
    [Command]
    public void SetSpeedControl(float speed)
    {
        _speedControl = Mathf.Clamp(speed, -1f, 1f);
    }
    [Command]
    public void SetTorqueControl(float torque)
    {
        _speedControl = Mathf.Clamp(torque, -1f, 1f);
    }//*/
}
