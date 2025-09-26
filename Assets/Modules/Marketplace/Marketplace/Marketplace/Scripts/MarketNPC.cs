using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarketNPC : MonoBehaviour
{
    public GameObject shopUI; // assign the shop UI panel in Inspector

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopUI.SetActive(true); // open shop when player walks up
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopUI.SetActive(false); // close shop when leaving
        }
    }
}
