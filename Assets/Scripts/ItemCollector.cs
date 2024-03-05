using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;
    [SerializeField] Text coinsText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
            coins++;
            coinsText.text = "Coins :" + coins;
        }
        
    }
}
