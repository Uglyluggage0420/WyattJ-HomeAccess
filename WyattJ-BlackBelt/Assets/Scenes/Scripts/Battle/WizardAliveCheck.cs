using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class WizardAliveCheck : MonoBehaviour
{
    public TextMeshProUGUI WizardDead;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("WizardAlive") == 0) 
        {
            Destroy(gameObject);
            WizardDead.enabled = true;
        }
        else
        {
            WizardDead.enabled = false; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
