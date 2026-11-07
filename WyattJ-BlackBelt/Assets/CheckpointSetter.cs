using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSetter : MonoBehaviour
{
    public string CurrentScene;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScene = PlayerPrefs.GetString("CurrentScene", "Entrance");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
