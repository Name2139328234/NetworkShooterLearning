using Mirror;
using UnityEngine;



public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _projectile;
    [SerializeField] private Timer _reloader;

    private bool _isReloaded;



    void Start()
    {
        _reloader.OnTimeEnd.AddListener(Reload);
    }



    public bool TryShoot()
    {
        if (!_isReloaded)
            return false;

        NetworkServer.Spawn(Instantiate(_projectile, _shootPoint.position, _shootPoint.rotation));
        _isReloaded = false;
        _reloader.IsPaused = false;

        return true;
    }



    private void Reload()
    {
        _isReloaded = true;
        _reloader.IsPaused = true;
    }
}
