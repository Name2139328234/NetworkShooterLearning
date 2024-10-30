using Mirror;
using UnityEngine;



public class SpaceshipInput:NetworkBehaviour
{
    public SpaceShipMovement ControlledShip { get => _controlledShip; }

    [SerializeField]
    private KeyCode _shootKey;

    private SpaceShipMovement _controlledShip;
    private Turret[] _controlledTurrets;



    void Update()
    {
        if (!isOwned || _controlledShip == null)
            return;
        _controlledShip.SpeedControl = Input.GetAxis("Vertical");
        _controlledShip.TorqueControl = -Input.GetAxis("Horizontal");

        if (Input.GetKey(_shootKey))
            foreach (Turret turret in _controlledTurrets)
                turret.CmdShoot();
    }



    public void SetShip(SpaceShipMovement ship)
    {
        _controlledShip = ship;
        _controlledTurrets = ship.GetComponentsInChildren<Turret>();
    }
}