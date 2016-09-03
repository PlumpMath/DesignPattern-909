public class RunningStatus : StatusBase
{
    public RunningStatus(StopWatch stopWatch, StopWatchView stopWatchView) : base(stopWatch, stopWatchView)
    {
    }

    public override void OnBeforeChangeStatus()
    {
        _stopWatchView.DecorateStopButton("MainButton");
        _stopWatchView.DecorateLapButton("SubButton");
    }

    public override void ClickedMainButton()
    {
        _stopWatch.Pause();
    }

    public override void ClickedSubButton()
    {
        _stopWatch.Lap();
    }
}