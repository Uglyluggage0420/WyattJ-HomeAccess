using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class KingAliveCheck : MonoBehaviour
{
    public TextMeshProUGUI KingDead;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("KingAlive") == 0) 
        {
            Destroy(gameObject);
            KingDead.enabled = true;
        }
        else
        {
            KingDead.enabled = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
