using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsWindow : MonoBehaviour
{
    public static bool IsOpen { get; private set; }

    [SerializeField]
    private GameObject _statisticsPanel;

    [SerializeField]
    private MMF_Player _openPanelFeedback;

    [SerializeField]
    private MMF_Player _closePanelFeedback;

    void Start()
    {
        _statisticsPanel.SetActive(false);
    }

    public void TogglePanel()
    {
        if (_statisticsPanel.activeSelf)
        {
            HidePanel();
        }
        else
        {
            ShowPanel();
        }
    }

    public void ShowPanel()
    {
        IsOpen = true;
        _openPanelFeedback.PlayFeedbacks();
    }

    public void HidePanel()
    {
        IsOpen = false;
        _closePanelFeedback.PlayFeedbacks();
    }
}
