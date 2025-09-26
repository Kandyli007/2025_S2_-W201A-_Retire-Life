using UnityEngine;

public class PlotBehaviour : MonoBehaviour
{
    private Plot plot;                 
    private SpriteRenderer sr;        

    [Header("Colors (used if not swapping sprites)")]
    public Color emptyColor = new Color(0.6f, 0.3f, 0.1f);  
    public Color growingColor = Color.green;                
    public Color readyColor = Color.yellow;                

    [Header("Optional Sprites (if you want to swap sprites instead of using colors)")]
    public Sprite emptySprite;
    public Sprite growingSprite;
    public Sprite readySprite;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        if (sr == null)
        {
            Debug.LogError("PlotBehaviour requires a SpriteRenderer!");
        }

        
        plot = new Plot();
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

    private void UpdateVisual()
    {
        if (emptySprite != null && growingSprite != null && readySprite != null)
        {
            if (plot.IsEmpty())
                sr.sprite = emptySprite;
            else if (plot.plantedCrop.state == CropState.Growing)
                sr.sprite = growingSprite;
            else if (plot.plantedCrop.state == CropState.ReadyToHarvest)
                sr.sprite = readySprite;

            sr.color = Color.white;
        }
        else
        {
   
            if (plot.IsEmpty())
                sr.color = emptyColor;
            else if (plot.plantedCrop.state == CropState.Growing)
                sr.color = growingColor;
            else if (plot.plantedCrop.state == CropState.ReadyToHarvest)
                sr.color = readyColor;

            sr.sprite = sr.sprite; 
        }
    }
}
