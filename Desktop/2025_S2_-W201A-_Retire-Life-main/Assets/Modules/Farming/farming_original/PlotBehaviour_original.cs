using UnityEngine;

public class PlotBehaviour : MonoBehaviour
{
    public enum CropState { Empty, Planted, Grown }
    public CropState currentState = CropState.Empty;

    public SpriteRenderer sr;          
    public Sprite emptySprite;         
    public Sprite plantedSprite;        
    public Sprite grownSprite;         

    void Start()
    {
        if (sr == null)
            sr = GetComponent<SpriteRenderer>();

        UpdateSprite();
    }

    public void PlantCrop()
    {
        currentState = CropState.Planted;
        UpdateSprite();
        Debug.Log("Crop planted!");
    }

    public void GrowCrop()
    {
        currentState = CropState.Grown;
        UpdateSprite();
        Debug.Log("Crop grown!");
    }

    public void HarvestCrop()
    {
        currentState = CropState.Empty;
        UpdateSprite();
        Debug.Log("Crop harvested!");
    }

    private void UpdateSprite()
    {
        switch (currentState)
        {
            case CropState.Empty:
                sr.sprite = emptySprite;
                break;
            case CropState.Planted:
                sr.sprite = plantedSprite;
                break;
            case CropState.Grown:
                sr.sprite = grownSprite;
                break;
        }
    }
}
