using UnityEngine;

public class FarmingTest : MonoBehaviour
{
    private Farming farming;

    void Start()
    {
        // Create a farming system with 3 plots
        farming = new Farming(3);

        // Make a new crop (takes 2 growth cycles to mature)
        Crop wheat = new Crop("Wheat", 2);

        // Plant in plot 0
        farming.Plant(0, wheat);

        // Simulate growth
        Debug.Log("Day 1: Growing crops...");
        farming.GrowAll();

        Debug.Log("Day 2: Growing crops...");
        farming.GrowAll();

        // Try harvesting
        Debug.Log("Day 3: Harvesting...");
        farming.Harvest(0);
    }
}
