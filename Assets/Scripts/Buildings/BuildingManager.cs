using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BuildingManager : MonoBehaviour
{
    private List<SingleBuilding> buildings = new List<SingleBuilding>();
    private EconomyManager economy => DI.di.economy;
    private int buildingsBought = 0;


    private void Awake()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            var building = transform.GetChild(0).GetComponent<SingleBuilding>();
            if (building)
            {
                var enable = economy.goldValue >= GameConstants.buildingCost[i];
                building.Init(enable, i);
                buildings.Add(building);
            }
        }

        Assert.IsTrue(buildings.Count > 0, "No Buildings Avaliable");

        Debug.Log($"Number of Buildings :: {buildings.Count}");

        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        EventsModel.GOLD_VALUE_CHANGED += OnGoldValueUpdated;
        EventsModel.BUILDING_BOUGHT += OnBuildingBought;
    }

    private void UnsubscribeEvents()
    {
        EventsModel.GOLD_VALUE_CHANGED -= OnGoldValueUpdated;
        EventsModel.BUILDING_BOUGHT -= OnBuildingBought;
    }


    private void Start()
    {
        Debug.Log($"BuildingManager :: Start");
        EventsModel.BUILDING_COUNT_CHANGED?.Invoke(buildingsBought);
    }

    private void OnGoldValueUpdated()
    {
        for (int i = 0; i < GameConstants.buildingCost.Count; ++i)
        {
            if (economy.goldValue >= GameConstants.buildingCost[i])
            {
                buildings[i].UnlockBuilding();
            }
        }
    }

    private void OnBuildingBought(int Id)
    {
        Debug.Log($"Building_{Id} :: Bought");
        DI.di.economy.AddGold(-GameConstants.buildingCost[Id]);
        ++buildingsBought;
        EventsModel.BUILDING_COUNT_CHANGED?.Invoke(buildingsBought);
    }

    private void OnDestroy() => UnsubscribeEvents();
}
