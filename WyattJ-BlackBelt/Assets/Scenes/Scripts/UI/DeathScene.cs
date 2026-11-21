using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    public Health healthStats;
    public PlayerMovement Scene;
    public CheckpointSetter Checkpoint;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetFloat("Xpos", -8);
        PlayerPrefs.SetFloat("Ypos", 0);
        PlayerPrefs.SetFloat("CurrentHealth", PlayerPrefs.GetInt("PlayerLevel") + 2);
        Invoke("ToCheckpoint", 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ToCheckpoint()
    {
        Debug.Log(Checkpoint.CurrentScene);
        if (Checkpoint.CurrentScene == "Courtyard" 
            || Checkpoint.CurrentScene == "Front Entrance" 
            || Checkpoint.CurrentScene == "Lower Passage" 
            || Checkpoint.CurrentScene == "Sentinel Room"
            || Checkpoint.CurrentScene == "Cellar"
            || Checkpoint.CurrentScene == "Meat Room"
            || Checkpoint.CurrentScene == "Castle Kitchen")
        {
            SceneManager.LoadScene("Courtyard");
        }
        else if (Checkpoint.CurrentScene == "Pantry"
            || Checkpoint.CurrentScene == "Alchemy Lab"
            || Checkpoint.CurrentScene == "North Hall"
            || Checkpoint.CurrentScene == "West hall"
            || Checkpoint.CurrentScene == "Lavatory")
        {
            SceneManager.LoadScene("Pantry");
        }
        else if (Checkpoint.CurrentScene == "East Hall"
            || Checkpoint.CurrentScene == "West Stairway"
            || Checkpoint.CurrentScene == "Royal Stairway"
            || Checkpoint.CurrentScene == "South Stairway"
            || Checkpoint.CurrentScene == "King's Chamber"
            || Checkpoint.CurrentScene == "Armoury")
        {
            SceneManager.LoadScene("Armoury");
        }
        else if (Checkpoint.CurrentScene == "Dungeon"
            || Checkpoint.CurrentScene == "Wizard's Tower")
        {
            SceneManager.LoadScene("Dungeon");
        }
        //Debug.Log(PlayerPrefs.GetString("CurrentCheckpoint"));
        //SceneManager.LoadScene(PlayerPrefs.GetString("CurrentCheckpoint"));
    }
}
