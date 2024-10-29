using Mirror;
using UnityEngine;



public class PlayerShipSpawner : NetworkBehaviour
{
    [SerializeField] private GameObject _ship;
    [SerializeField] private SpaceshipInput _playerInputControl;
    // Start is called before the first frame update
    void Start()
    {
        if (!isOwned)
            return;

        SpawnShip();
    }




    [Command]
    private void SpawnShip()
    {
        GameObject ship = Instantiate(_ship, transform.position, transform.rotation);

        _playerInputControl.SetShip(ship.GetComponent<SpaceShipMovement>());

        NetworkServer.Spawn(ship);
    }
}
