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
        if (!isOwned)
            return;
        if (Player.Local == null)
            return;
        if (Player.Local.ActiveShipMovement == null)
            return;
        Player.Local.ActiveShipMovement.SpeedControl = Input.GetAxis("Vertical");
        Player.Local.ActiveShipMovement.TorqueControl = -Input.GetAxis("Horizontal");

        /*
        if (Input.GetKey(_shootKey))
            foreach (Turret turret in _controlledTurrets)
                turret.CmdShoot();*/
    }
}