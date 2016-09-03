
public class StopStatus : StatusBase
{
    public StopStatus(StopWatch stopWatch, StopWatchView stopWatchView) : base(stopWatch, stopWatchView)
    {
    }

    public override void OnBeforeChangeStatus()
    {
        _stopWatchView.UpdateDisplay();
        _stopWatchView.DecorateRunButton("MainButton");
        _stopWatchView.DecorateDisabledLapButton("SubButton");
    }

    public override void ClickedMainButton()
    {
        _stopWatch.Run();
    }

    public override void ClickedSubButton()
    {
    }
}