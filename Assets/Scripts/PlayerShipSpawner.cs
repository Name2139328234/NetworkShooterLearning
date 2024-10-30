using Mirror;
using UnityEngine;



public class PlayerShipSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject _ship;
    [SerializeField] private SpaceshipInput _playerInputControl;



    public override void OnStartClient()
    {
        base.OnStartClient();

        if (!isOwned)
            return;

        CmdSpawnShip();
    }




    [Command]
    private void CmdSpawnShip()
    {
        SvSpawnShip();
    }
    [Server]
    private void SvSpawnShip()
    {

        GameObject ship = Instantiate(_ship, transform.position, transform.rotation);
        NetworkServer.Spawn(ship, netIdentity.connectionToClient);

        RpcSetShip(ship.GetComponent<NetworkIdentity>());
    }
    [ClientRpc]
    private void RpcSetShip(NetworkIdentity ship)
    {
        _playerInputControl.SetShip(ship.GetComponent<SpaceShipMovement>());
    }
}
