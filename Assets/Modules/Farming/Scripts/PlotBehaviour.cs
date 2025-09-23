using UnityEngine;

public class PlotBehaviour : MonoBehaviour
{
    private Plot plot;
    private SpriteRenderer sr;

    public Color emptyColor = new Color(0.6f, 0.3f, 0.1f); // custom brown
    public Color growingColor = Color.green;
    public Color readyColor = Color.yellow;

    void Start()
    {
        plot = new Plot(); // each plot has its own Plot object
        sr = GetComponent<SpriteRenderer>();
        UpdateVisual();
    }

    void Update()
    {
        UpdateVisual();
    }

    public void PlantCrop()
    {
        if (plot.IsEmpty())
        {
            plot.PlantCrop(new Crop("Wheat", 2));
        }
    }

    public void GrowCrop()
    {
        plot.GrowCrop();
    }

    public void HarvestCrop()
    {
        plot.HarvestCrop();
    }

    void UpdateVisual()
    {
        if (plot.IsEmpty())
        {
            sr.color = emptyColor;
        }
        else if (plot.plantedCrop.state == CropState.Growing)
        {
            sr.color = growingColor;
        }
        else if (plot.plantedCrop.state == CropState.ReadyToHarvest)
        {
            sr.color = readyColor;
        }
    }
}
