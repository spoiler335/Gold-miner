using TMPro;
using UnityEngine;

public class GamePlayUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldtext;
    [SerializeField] private TextMeshProUGUI buildingCountText;

    private void Awake()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventsModel.GOLD_VALUE_CHANGED += UpdateGoldValue;
        EventsModel.BUILDING_COUNT_CHANGED += UpdateBuildingCount;
    }

    private void UnsubscribeEvents()
    {
        EventsModel.GOLD_VALUE_CHANGED -= UpdateGoldValue;
        EventsModel.BUILDING_COUNT_CHANGED -= UpdateBuildingCount;
    }

    private void Start()
    {
        UpdateGoldValue();
    }

    private void UpdateGoldValue()
    {
        goldtext.text = $"{DI.di.economy.goldValue}";
    }

    private void UpdateBuildingCount(int value)
    {
        buildingCountText.text = $"{value}";
    }

    private void OnDestroy() => UnsubscribeEvents();
}