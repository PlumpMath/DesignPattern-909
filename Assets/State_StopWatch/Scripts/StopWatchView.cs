using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StopWatchView : MonoBehaviour
{
    [SerializeField] private Text _display;
    [SerializeField] private VerticalLayoutGroup _lapsContainer;
    [SerializeField] private LayoutElement _lapNodePrefab;

    private StopWatch _stopWatch;

    public void Init(StopWatch stopWatch)
    {
        _stopWatch = stopWatch;
    }

    public void OnClickMainButton()
    {
        _stopWatch.ClickedMainButton();
    }

    public void OnClickSubButton()
    {
        _stopWatch.ClickedSubButton();
    }

    private Button GetButton(string name)
    {
        return GameObject.Find(name).GetComponent<Button>();
    }

    public void UpdateDisplay()
    {
        _display.text = formatCounter(_stopWatch._counter);
    }

    private string formatCounter(int counter)
    {
        return ((float) counter / 10f).ToString("0.0");
    }

    public void DecorateRunButton(string name)
    {
        Button button = GetButton(name);
        button.GetComponentInChildren<Text>().text = "Run";
        button.interactable = true;
    }

    public void DecorateStopButton(string name)
    {
        Button button = GetButton(name);
        button.GetComponentInChildren<Text>().text = "Stop";
        button.interactable = true;
    }

    public void DecorateResetButton(string name)
    {
        Button button = GetButton(name);
        button.GetComponentInChildren<Text>().text = "Reset";
        button.interactable = true;
    }

    public void DecorateLapButton(string name)
    {
        Button button = GetButton(name);
        button.GetComponentInChildren<Text>().text = "Lap";
        button.interactable = true;
    }

    public void DecorateDisabledLapButton(string name)
    {
        Button button = GetButton(name);
        button.GetComponentInChildren<Text>().text = "Lap";
        button.interactable = false;
    }

    public void AddLap(int lap)
    {
        LayoutElement lapNode = Instantiate(_lapNodePrefab);
        lapNode.transform.SetParent(_lapsContainer.transform);
        lapNode.transform.SetSiblingIndex(0);

        Text lapText = lapNode.GetComponentInChildren<Text>();
        lapText.text = formatCounter(lap);
    }

    private void ClearLaps()
    {
        foreach (Transform child in _lapsContainer.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void Reset()
    {
        UpdateDisplay();
        ClearLaps();
    }
}