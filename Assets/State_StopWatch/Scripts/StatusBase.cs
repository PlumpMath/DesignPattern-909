using UnityEngine;
using System.Collections;

public class StatusBase
{
    protected StopWatch _stopWatch;
    protected StopWatchView _stopWatchView;

    public StatusBase(StopWatch stopWatch, StopWatchView stopWatchView)
    {
        _stopWatch = stopWatch;
        _stopWatchView = stopWatchView;
    }

    public virtual void OnBeforeChangeStatus()
    {
    }

    public virtual void ClickedMainButton()
    {
    }

    public virtual void ClickedSubButton()
    {
    }

}