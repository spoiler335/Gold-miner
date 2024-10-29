using UnityEngine.Events;

public static class EventsModel
{
    public static UnityAction GOLD_VALUE_CHANGED;
    public static UnityAction<int> BUILDING_COUNT_CHANGED;
    public static UnityAction<int> BUILDING_BOUGHT;
}