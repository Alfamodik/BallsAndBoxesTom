using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using YG;

public class MoneyManager : MonoBehaviour
{
    [SerializeField]
    private Stats _mouseClick;

    [SerializeField]
    private int _money;

    [SerializeField]
    private MoneyDisplay _moneyDisplay;

    public static MoneyManager Instance;

    [SerializeField]
    private MMF_Player _moneyChangeFeedback;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void OnEnable() => YG2.onGetSDKData += Load;
    void OnDisable() => YG2.onGetSDKData -= Load;

    void Load()
    {
        LoadProgress();
        _moneyDisplay.UpdateMoneyText(_money);
    }

    public void Start()
    {
        _moneyDisplay.UpdateMoneyText(_money);
    }

    public Stats GetMouseClickStats()
    {
        return _mouseClick;
    }
    public void IncreaseMoneyBy(int amount)
    {
        _money += amount;
        _moneyChangeFeedback.PlayFeedbacks();
        _moneyDisplay.UpdateMoneyText(_money);
        SaveProgress();
    }

    public void DecreaseMoneyBy(int amount)
    {
        _money -= amount;
        _moneyChangeFeedback.PlayFeedbacks();
        _moneyDisplay.UpdateMoneyText(_money);
        SaveProgress();
    }

    public int GetMoney()
    {
        return _money;
    }

    public bool TryToBuyBall(Ball ball)
    {
        var price = ball.GetStats().TryToGetStat(Stat.PRICE);

        if (_money >= price)
        {
            DecreaseMoneyBy((int)price);
            BallSpawnManager.Instance.SpawnBall(ball);
            ball.GetStats().SetStat(Stat.PRICE, price * 2);
            SaveLoadManager.Instance.SaveBallPrices();
            SaveLoadManager.Instance.SaveBallCounts();
            return true;
        }
        return false;
    }

    private void LoadProgress()
    {
        _money = YG2.saves.money;
    }

    private void SaveProgress()
    {
        YG2.saves.money = _money;
        YG2.SaveProgress();
    }
}