using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SingleBuilding : MonoBehaviour
{
    private Button button;
    private int Id;

    private void Awake()
    {
        Debug.Log($"SingleBuilding :: Awake");
        button = GetComponent<Button>();
        button.onClick.AddListener(OnBuildingClicked);
        button.interactable = false;
    }

    public void Init(bool enable, int id)
    {
        button.interactable = enable;
        Id = id;
        Debug.Log($"building_{Id} :: isUnlocked :: {button.interactable}");
    }

    public void UnlockBuilding()
    {
        Debug.Log($"building_{Id} :: Unlocked :: {button.interactable}");
        button.interactable = true;
    }

    private void OnBuildingClicked()
    {
        EventsModel.BUILDING_BOUGHT?.Invoke(Id);
    }
}
