using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlotBehaviour currentPlot;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (currentPlot != null)
            {
                currentPlot.PlantCrop();
                Debug.Log("Plant key pressed!");
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (currentPlot != null)
            {
                currentPlot.GrowCrop();
                Debug.Log("Grow key pressed!");
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (currentPlot != null)
            {
                currentPlot.HarvestCrop();
                Debug.Log("Harvest key pressed!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlotBehaviour plot = other.GetComponent<PlotBehaviour>();
        if (plot != null)
        {
            currentPlot = plot;
            Debug.Log("Player is near a plot!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        PlotBehaviour plot = other.GetComponent<PlotBehaviour>();
        if (plot != null && plot == currentPlot)
        {
            currentPlot = null;
            Debug.Log("Player left the plot area!");
        }
    }
}
