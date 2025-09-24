using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlotBehaviour nearbyPlot;

    void Update()
    {
        if (nearbyPlot != null)
        {
            if (Input.GetKeyDown(KeyCode.P)) // Plant
            {
                nearbyPlot.PlantCrop();
            }
            if (Input.GetKeyDown(KeyCode.Space)) // Grow
            {
                nearbyPlot.GrowCrop();
            }
            if (Input.GetKeyDown(KeyCode.H)) // Harvest
            {
                nearbyPlot.HarvestCrop();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plot"))
        {
            nearbyPlot = other.GetComponent<PlotBehaviour>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Plot"))
        {
            if (other.GetComponent<PlotBehaviour>() == nearbyPlot)
            {
                nearbyPlot = null;
            }
        }
    }
}