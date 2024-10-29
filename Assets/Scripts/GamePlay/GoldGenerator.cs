using UnityEngine;

public class GoldGenerator : MonoBehaviour
{
    private float timeSinceLastChecked = 0;
    public EconomyManager economy => DI.di.economy;

    private void Start()
    {
        Debug.Log($"Curent Gold :: {economy.goldValue}");
    }

    private void Update()
    {
        timeSinceLastChecked += Time.deltaTime;
        if (timeSinceLastChecked >= GameConstants.GOLD_GNERATION_INTERVAL)
        {
            economy.AddGold(GameConstants.GOLD_GENERATE_PER_MIN);
            Debug.Log($"Curent Gold :: {economy.goldValue}");
            timeSinceLastChecked = 0;
        }
    }
}