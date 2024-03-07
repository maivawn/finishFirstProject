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
            savecoins();
            coinsText.text = "Coins :" + coins;
        }

    }
    public void savecoins()
    {
        PlayerPrefs.SetInt("CoinsScene1", coins);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("CoinsScene1"));
    }
    private void Awake()
    {
        savecoins();
    }
}
