using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class AlchemistAliveCheck : MonoBehaviour
{
    public TextMeshProUGUI AlchemistDead;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("AlchemistAlive") == 0) 
        {
            Destroy(gameObject);
            AlchemistDead.enabled = true;
        }
        else
        {
            AlchemistDead.enabled = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
