using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coinCount, _livesText;



    private void Start()
    {
        _coinCount.text = "Coins: 0";
    }
    public void UpdateCoinDisplay(int coins)
    {
        _coinCount.text = "Coins: " + coins;
    }

    public void UpdateLivesDisplay(int lives)
    {
        _livesText.text = "Lives: " + lives;
    }
}
