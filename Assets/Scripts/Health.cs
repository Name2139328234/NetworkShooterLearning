using UnityEngine;
using UnityEngine.Events;



public class Health : MonoBehaviour
{
    public event UnityAction OnDie;
    public event UnityAction<float> OnChangeValue;

    [SerializeField]
    private float _maxValue;

    private float _value;
    private bool _isDead;//exists to prevent multiple calls of OnDie event in multi-thread enviroment. Should probably learn to handle threads instead



    void Start()
    {
        _value = _maxValue;
    }



    public void Damage(float damage)
    {
        if (_isDead)
            return;

        if (OnChangeValue != null)
            OnChangeValue(Mathf.Max(-_value, -damage));

        _value -= damage;

        if (_value <= 0)
        {
            _isDead = true;
            _value = 0;

            if (OnDie != null)
                OnDie();
        }
    }
    public void Heal(float heal)
    {
        if (OnChangeValue != null)
            OnChangeValue(Mathf.Min(_maxValue - _value, heal));

        _value += heal;

        if (_value > _maxValue)
            _value = _maxValue;
    }
}
