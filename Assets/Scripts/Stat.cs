using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public enum Stat
{
    [StringValue("Урон", "Hit Damage")]
    HIT_DAMAGE = 0,
    [StringValue("Скорость", "Speed")]
    SPEED = 1,
    [StringValue("Цена", "Price")]
    PRICE = 2,
    [StringValue("Радиус взрыва", "Expl. Range")]
    EXPLOSION_RANGE = 3,
    [StringValue("Урон взрыва", "Expl. Damage")]
    EXPLOSION_DAMAGE = 4,
    [StringValue("Кол-во мини шаров", "# Mini Balls")]
    NUMBER_OF_MINI_SCATTER_BALLS = 5,
    [StringValue("Деньги за столкновение", "Money on Collision")]
    MONEY_ON_COLLISION = 6,

    [StringValue("Количество", "Count")]
    COUNT = 101,
    [StringValue("Общий урон", "Total Damage")]
    TOTAL_DAMAGE = 102,
}

public static class EnumExtensions
{
    public static string GetStringValue(this Stat value)
    {
        FieldInfo field = value.GetType().GetField(value.ToString());

        if (field.GetCustomAttribute(typeof(StringValueAttribute)) is StringValueAttribute attribute)
        {
            return attribute.Get();
        }

        return value.ToString();
    }
}
