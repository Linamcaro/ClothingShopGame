using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI coinsText;

    private void Start()
    {
        coinsText.text = GameManager.Instance.GetCoinsAmount().ToString();

        GameManager.Instance.OnCoinAmountChanged += OnCoinAmountChanged;
    }

    private void OnCoinAmountChanged(object sender, EventArgs e)
    {
        coinsText.text = GameManager.Instance.GetCoinsAmount().ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    

}
