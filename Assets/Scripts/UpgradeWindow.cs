using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeWindow : MonoBehaviour
{
    public static bool IsOpen { get; private set; }

    [SerializeField]
    private GameObject _upgradePanel;

    [SerializeField]
    private MMF_Player _openPanelFeedback;

    [SerializeField]
    private MMF_Player _closePanelFeedback;

    void Start()
    {
        _upgradePanel.SetActive(false);
    }

    public void TogglePanel()
    {
        if (_upgradePanel.activeSelf)
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
