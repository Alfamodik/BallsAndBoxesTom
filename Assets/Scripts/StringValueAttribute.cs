using System;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
sealed class StringValueAttribute : Attribute
{
    public string Ru { get; }
    public string En { get; }

    public StringValueAttribute(string ru, string en)
    {
        Ru = ru;
        En = en;
    }

    public string Get()
    {
        return YG.YG2.lang == "ru" ? Ru : En;
    }
}
