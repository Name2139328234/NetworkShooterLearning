using Mirror;
using System.Collections.Generic;
using UnityEngine;



public class NetworkSessionManager : NetworkManager
{
    public bool IsServer => (mode == NetworkManagerMode.Host || mode == NetworkManagerMode.ServerOnly);
    public bool IsClient => (mode == NetworkManagerMode.Host || mode == NetworkManagerMode.ClientOnly);

    [SerializeField]
    private PlayerShipSpawner _playerShipSpawner;
    [SerializeField]
    private KeyCode _matchStartKey;



    public override void Start()
    {
        base.Start();
    }
    public override void Update()
    {
        base.Update();

        if (!IsServer)
            return;

        if (Input.GetKeyUp(_matchStartKey))
            SvStartMatch();
    }



    [Server]
    private void SvStartMatch()
    {
        foreach (Player player in Player.ConnectedPlayers)
        {
            player.SvSetActiveShip(_playerShipSpawner.SvSpawnShip());
        }
    }
}
