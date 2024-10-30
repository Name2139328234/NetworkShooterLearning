using Mirror;
using UnityEngine;



public class Turret : NetworkBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Timer _reloader;

    private bool _isReloaded;



    void Start()
    {
        _reloader.OnTimeEnd.AddListener(Reload);
    }



    [Command]
    public void CmdShoot()
    {
        SvShoot();
    }
    [Server]
    private void SvShoot()
    {
        if (!_isReloaded)
            return;
        Instantiate(_projectile, _shootPoint.position, _shootPoint.rotation);
        _isReloaded = false;
        _reloader.IsPaused = false;
        RpcShoot();
    }
    [ClientRpc]
    private void RpcShoot()
    {
        Instantiate(_projectile, _shootPoint.position, _shootPoint.rotation);
    }



    private void Reload()
    {
        _isReloaded = true;
        _reloader.IsPaused = true;
    }
}
