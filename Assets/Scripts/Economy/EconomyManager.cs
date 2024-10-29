using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomyManager
{
    private EconomyModel model;
    public EconomyManager()
    {
        model = new EconomyModel();
    }

    public void AddGold(int value)
    {
        model.gold += value;
        EventsModel.GOLD_VALUE_CHANGED?.Invoke();
    }

    public int goldValue => model.gold;
}

public class EconomyModel
{
    public int gold;
}
