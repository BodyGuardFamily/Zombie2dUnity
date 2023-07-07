using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Money : MonoBehaviour
{
    public static int startingMoney = 0;
    [SerializeField] private TextMeshProUGUI moneyScore;
    private string prefixMoney = "$ ";
    
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void FixedUpdate() {
        UpdateTextLabel();
    }
    
    private void UpdateTextLabel()
    {
        moneyScore.SetText(prefixMoney + startingMoney);
    }
    
    public void IncrementScore()
    {
        if (Bullet.enemyKilled == true)
        {
            startingMoney += 10;
            Debug.Log("Score incremented: " + startingMoney);
        }   
    }
}
