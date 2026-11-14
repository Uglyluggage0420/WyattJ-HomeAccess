using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChefAliveCheck : MonoBehaviour
{
    public TextMeshProUGUI ChefDead;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("ChefAlive") == 0) 
        {
            Destroy(gameObject);
            ChefDead.enabled = true;
        }
        else
        {
            ChefDead.enabled = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
