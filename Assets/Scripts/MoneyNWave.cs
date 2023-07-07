using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoneyNWave : MonoBehaviour
{
    public int startingWave = 1;
    [SerializeField] private TextMeshProUGUI Wave;
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
        Wave.SetText(prefixWave + startingWave);
    }

    public void IncrementWave()
    {
        startingWave =+ 1;
    }
}