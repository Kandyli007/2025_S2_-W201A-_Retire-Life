using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private PlotBehaviour nearbyPlot;

    void Update()
    {
        if (nearbyPlot != null)
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                nearbyPlot.PlantCrop();
                Debug.Log("Plant key pressed!");
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                nearbyPlot.GrowCrop();
                Debug.Log("Grow key pressed!");
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                nearbyPlot.HarvestCrop();
                Debug.Log("Harvest key pressed!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plot"))
        {
            nearbyPlot = other.GetComponent<PlotBehaviour>();
            if (nearbyPlot != null)
            {
                Debug.Log("Player is near a plot!");
            }
            else
            {
                Debug.LogWarning("PlotBehaviour not found on this Plot!");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Plot") && other.GetComponent<PlotBehaviour>() == nearbyPlot)
        {
            nearbyPlot = null;
            Debug.Log("Player left the plot area!");
        }
    }
}
