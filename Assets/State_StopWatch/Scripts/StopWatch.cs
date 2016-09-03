using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StopWatch : MonoBehaviour
{
    [SerializeField] private StopWatchView _stopWatchView;

    private StatusBase _status;
    private Dictionary<string, StatusBase> _statuses;

    public int _counter { get; private set; }
    private int _lastLap;
    private bool _isRunning;

    void Start()
    {
        _stopWatchView.Init(this);

        _statuses = new Dictionary<string, StatusBase>
        {
            {"stop", new StopStatus(this, _stopWatchView)},
            {"pause", new PauseStatus(this, _stopWatchView)},
            {"running", new RunningStatus(this, _stopWatchView)}
        };

        Reset();
    }

    public void ClickedMainButton()
    {
        _status.ClickedMainButton();
    }

    public void ClickedSubButton()
    {
        _status.ClickedSubButton();
    }

    public void Run()
    {
        ChangeStatus(_statuses["running"]);
        _isRunning = true;
        StartCoroutine(Tick());
    }

    private IEnumerator Tick()
    {
        while (_isRunning)
        {
            yield return new WaitForSeconds(0.1f);
            _counter++;
            _stopWatchView.UpdateDisplay();
        }
    }

    public void Pause()
    {
        _isRunning = false;
        ChangeStatus(_statuses["pause"]);
    }

    public void Reset()
    {
        _counter = 0;
        _lastLap = 0;
        _stopWatchView.Reset();
        ChangeStatus(_statuses["stop"]);
    }

    public void Lap()
    {
        int lap = _counter - _lastLap;
        _lastLap = _counter;
        _stopWatchView.AddLap(lap);
    }

    private void ChangeStatus(StatusBase next)
    {
        _status = next;
        _status.OnBeforeChangeStatus();
    }
}