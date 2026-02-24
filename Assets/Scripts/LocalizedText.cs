using System;
using UnityEngine;

[Serializable]
public class LocalizedText
{
    public string ru;
    public string en;

    public string Get()
    {
        return YG.YG2.lang == "ru" ? ru : en;
    }
}
