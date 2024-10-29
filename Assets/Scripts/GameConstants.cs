using System.Collections.Generic;
using UnityEngine;

public static class GameConstants
{
    public const float GOLD_GNERATION_INTERVAL = 5f;
    public const int GOLD_GENERATE_PER_MIN = 100;
    public static List<int> buildingCost = new List<int>() { 100, 150, 230 };
}