using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MoreMountains.Feedbacks;
using System;
using System.Globalization;
using YG;

public class Upgrade : MonoBehaviour
{
    [Header("Upgrade Changes")]
    public LocalizedText title;
    public LocalizedText description;
    public Stats ballStats;
    public Stat statToUpgrade;
    public UpgradeFunctions upgradeFunctions;
    public int upgradeIndex;

    [Header("Linked Objects")]
    public TextMeshProUGUI titleText;
    public int currentLevel;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI effectText;
    public ProgressBar progressBar;

    [SerializeField]
    private MMF_Player _successfulPurchaseFeedback;

    [SerializeField]
    private MMF_Player _failedPurchaseFeedback;

    void Start()
    {
        LoadProgress();
        UpdateText();
    }

    [ContextMenu("Upgrade")]
    public void TryToUpgradeStat()
    {
        if(upgradeFunctions.CanUpgrade(currentLevel))
        {
            var price = upgradeFunctions.GetPriceAtLevel(currentLevel);
            ballStats.IncreaseStat(statToUpgrade, upgradeFunctions.GetEffectAtLevel(currentLevel));
            MoneyManager.Instance.DecreaseMoneyBy((int)price);
            currentLevel++;
            UpdateText();
            EventManager.Instance.Upgrade();
            _successfulPurchaseFeedback.PlayFeedbacks();
            SaveProgress();
        }
        else
        {
            _failedPurchaseFeedback.PlayFeedbacks();
            Debug.Log("Not enough money");
        }
       
    }

    private void UpdateText()
    {
        titleText.text = title.Get();
        effectText.text = $"+ {FormatNumber(upgradeFunctions.GetEffectAtLevel(currentLevel))}";
        levelText.text = $"{currentLevel} / {upgradeFunctions.GetMaxLevel()}";
        progressBar.SetMaxValue((int)upgradeFunctions.GetPriceAtLevel(currentLevel));
    }

    private string FormatNumber(float number)
    {
        if(number % 1 == 0)
        {
            return $"{number}"; 
        } else
        {
           return number.ToString("N1", CultureInfo.CreateSpecificCulture("en-US"));
        }
    }

    private void LoadProgress()
    {
        currentLevel = YG2.saves.upgradeLevels[upgradeIndex];
        for (int i = 0; i < currentLevel; i++)
        {
            ballStats.IncreaseStat(statToUpgrade, upgradeFunctions.GetEffectAtLevel(i));
        }
    }

    private void SaveProgress()
    {
        YG2.saves.upgradeLevels[upgradeIndex] = currentLevel;
        YG2.SaveProgress();
    }
}
