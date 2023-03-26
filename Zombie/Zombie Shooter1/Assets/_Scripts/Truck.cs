using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Truck : MonoBehaviour
{
    public GameObject gameManager;
    public Text HPText;
    
    private int HP = 10;
    public void TruckHP()
    {
        HPText.text = "HP:" + --HP;

        if (HP <= 0)
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
    }
}
