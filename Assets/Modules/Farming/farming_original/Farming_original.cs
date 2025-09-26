
using UnityEngine;

public class Farming
{
    public Plot[] plots;

    // Constructor: create some plots
    public Farming(int numberOfPlots)
    {
        plots = new Plot[numberOfPlots];
        for (int i = 0; i < numberOfPlots; i++)
        {
            plots[i] = new Plot();
        }
    }

    // Plant in a specific plot
    public void Plant(int plotIndex, Crop crop)
    {
        if (plotIndex >= 0 && plotIndex < plots.Length)
        {
            plots[plotIndex].PlantCrop(crop);
        }
    }

    // Grow all plots
    public void GrowAll()
    {
        foreach (Plot plot in plots)
        {
            plot.GrowCrop();
        }
    }

    // Harvest a specific plot
    public void Harvest(int plotIndex)
    {
        if (plotIndex >= 0 && plotIndex < plots.Length)
        {
            plots[plotIndex].HarvestCrop();
        }
    }
}
