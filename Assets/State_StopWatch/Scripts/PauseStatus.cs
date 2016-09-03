public class PauseStatus : StatusBase
{
    public PauseStatus(StopWatch stopWatch, StopWatchView stopWatchView) : base(stopWatch, stopWatchView)
    {
    }

    public override void OnBeforeChangeStatus()
    {
        _stopWatchView.DecorateRunButton("MainButton");
        _stopWatchView.DecorateResetButton("SubButton");
    }

    public override void ClickedMainButton()
    {
        _stopWatch.Run();
    }

    public override void ClickedSubButton()
    {
        _stopWatch.Reset();
    }
}