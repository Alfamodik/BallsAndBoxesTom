using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance;

    [SerializeField] private List<Ball> ballPrefabs;

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

    void Start()
    {
        LoadBallPrices();
        StartCoroutine(LoadBallsDelayed());
    }

    private IEnumerator LoadBallsDelayed()
    {
        yield return new WaitForEndOfFrame();
        LoadBalls();
    }

    private void LoadBallPrices()
    {
        for (int i = 0; i < ballPrefabs.Count && i < YG2.saves.ballPrices.Length; i++)
        {
            if (YG2.saves.ballPrices[i] > 0)
            {
                ballPrefabs[i].GetStats().SetStat(Stat.PRICE, YG2.saves.ballPrices[i]);
            }
        }
    }

    private void LoadBalls()
    {
        for (int i = 0; i < ballPrefabs.Count && i < YG2.saves.ballCounts.Length; i++)
        {
            for (int j = 0; j < YG2.saves.ballCounts[i]; j++)
            {
                BallSpawnManager.Instance.SpawnBall(ballPrefabs[i]);
            }
        }
    }

    public void SaveBallPrices()
    {
        for (int i = 0; i < ballPrefabs.Count && i < YG2.saves.ballPrices.Length; i++)
        {
            YG2.saves.ballPrices[i] = ballPrefabs[i].GetStats().TryToGetStat(Stat.PRICE);
        }
        YG2.SaveProgress();
    }

    public void SaveBallCounts()
    {
        for (int i = 0; i < ballPrefabs.Count && i < YG2.saves.ballCounts.Length; i++)
        {
            YG2.saves.ballCounts[i] = (int)ballPrefabs[i].GetStats().TryToGetStat(Stat.COUNT);
        }
        YG2.SaveProgress();
    }

    [ContextMenu("Reset Progress")]
    public void ResetProgress()
    {
        YG2.saves = new SavesYG();
        YG2.SaveProgress();
    }
}
