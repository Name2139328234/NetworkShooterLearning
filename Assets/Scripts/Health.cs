using Mirror;
using UnityEngine;
using UnityEngine.Events;



public class Health : NetworkBehaviour
{
    public event UnityAction Died;
    public event UnityAction<float> Changed;

    [SerializeField]
    private float _maxValue;

    [SyncVar(hook = nameof(OnChanged))] private float _value;
    [SyncVar(hook = nameof(OnDie))]private bool _isDead;



    public override void OnStartServer()
    {
        base.OnStartServer();

        _value = _maxValue;
    }



    [Server]
    public void SvDamage(float damage)
    {
        if (_isDead)
            return;

        _value -= damage;

        if (_value <= 0)
        {
            _isDead = true;
            _value = 0;
        }
    }
    [Server]
    public void SvHeal(float heal)
    {

        _value += heal;

        if (_value > _maxValue)
            _value = _maxValue;
    }



    private void OnChanged(float previous, float current)
    {
        Changed?.Invoke(current);
    }
    private void OnDie (bool previous, bool current)
    {
        if (previous == false && current == true)
            Died?.Invoke();
    }
}
