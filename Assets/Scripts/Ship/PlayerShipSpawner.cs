using Mirror;
using UnityEngine;



public class PlayerShipSpawner : NetworkBehaviour
{
    [SerializeField] private ShipIdentificator _ship;



    [Server]
    public ShipIdentificator SvSpawnShip()
    {

        ShipIdentificator ship = Instantiate(_ship, Player.Local.transform.position, Player.Local.transform.rotation);
        NetworkServer.Spawn(ship.gameObject, netIdentity.connectionToClient);

        //ship.GetComponent<ShipColour>().SvSetPaint(Random.Range(0, ColourIDStorage.Instance.ColourIDs.Count));

        return ship;
    }
}
