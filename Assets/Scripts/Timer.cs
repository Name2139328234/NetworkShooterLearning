using UnityEngine;
using UnityEngine.Events;



public class Timer : MonoBehaviour
{
    public UnityEvent OnTimeEnd;
    public bool IsPaused;

    [SerializeField] private float[] _timeIntervals;
    [SerializeField] private bool _isLoop;

    private int _currentInterval;
    private float _timePassed;



    void Update()
    {
        if (IsPaused)
            return;


        _timePassed += Time.deltaTime;

        if (_timePassed > _timeIntervals[_currentInterval])
        {
            _timePassed = 0;
            OnTimeEnd.Invoke();

            _currentInterval++;

            if (_currentInterval >= _timeIntervals.Length)
            {
                _currentInterval = 0;
                if (!_isLoop)
                    Destroy(this);
            }
        }
    }



    public void Stop(bool isEventTriggered)
    {
        if (OnTimeEnd != null && isEventTriggered)
            OnTimeEnd.Invoke();

        Destroy(this);
    }
}
