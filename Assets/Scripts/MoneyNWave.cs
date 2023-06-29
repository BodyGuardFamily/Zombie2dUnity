using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyNWave : MonoBehaviour
{
    public int startingMoney = 0;
    public int startingWave = 1;
    [SerializeField] private TextMeshProUGUI moneyScore;
    [SerializeField] private TextMeshProUGUI Wave;
    private string prefixMoney = "$ ";
    private string prefixWave = "WAVE ";
    // Start is called before the first frame update
    void Start()
    {
    }


// Update is called once per frame
    void FixedUpdate() {
        UpdateTextLabel();
    }
    

    private void UpdateTextLabel()
    {
        moneyScore.SetText(prefixMoney + startingMoney);
        Wave.SetText(prefixWave + startingWave);
    }

    public void IncrementScore()
    {
        startingMoney =+ 10;
    }

    public void IncrementWave()
    {
        startingWave =+ 1;
    }
}