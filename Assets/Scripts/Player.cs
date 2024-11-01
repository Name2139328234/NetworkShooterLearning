using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : NetworkBehaviour
{
    public static Player Local
    {
        get
        {
            NetworkIdentity localPlayerIdentitiy = NetworkClient.localPlayer;

            if (localPlayerIdentitiy != null)
                return localPlayerIdentitiy.GetComponent<Player>();

            return null;
        }
    }
    public SpaceShipMovement ActiveShipMovement { get => _activeShipMovement; }

    public static IReadOnlyCollection<Player> ConnectedPlayers => _connectedPlayers;

    private static List<Player> _connectedPlayers;

    [SerializeField] private ShipIdentificator _activeShip;//TODO remove sf after test
    private SpaceShipMovement _activeShipMovement;
    private Color _shipColor;



    void OnEnable()
    {
        if (_connectedPlayers == null)
            _connectedPlayers = new List<Player>();

        _connectedPlayers.Add(this);
    }
    void OnDisable()
    {
        _connectedPlayers.Remove(this);
    }



    [Server]
    public void SvSetActiveShip(ShipIdentificator activeShipIdentificator)
    {
        _activeShip = activeShipIdentificator;
        _activeShipMovement = activeShipIdentificator.GetComponent<SpaceShipMovement>();

        RpcSetActiveShip(activeShipIdentificator.GetComponent<NetworkIdentity>());
    }



    [ClientRpc]
    private void RpcSetActiveShip(NetworkIdentity activeShip)
    {
        _activeShip = activeShip.GetComponent<ShipIdentificator>();
        _activeShipMovement = activeShip.GetComponent<SpaceShipMovement>();
    }
}
