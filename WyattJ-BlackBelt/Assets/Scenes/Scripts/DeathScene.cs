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
        if (Checkpoint.CurrentScene == "Entrance" 
            || Checkpoint.CurrentScene == "Hall1" 
            || Checkpoint.CurrentScene == "Hall2" 
            || Checkpoint.CurrentScene == "Hall3"
            || Checkpoint.CurrentScene == "Hall4"
            || Checkpoint.CurrentScene == "Freezer"
            || Checkpoint.CurrentScene == "Kitchen")
        {
            SceneManager.LoadScene("Entrance");
        }
        else if (Checkpoint.CurrentScene == "Hall5"
            || Checkpoint.CurrentScene == "Laboratory"
            || Checkpoint.CurrentScene == "Hall6"
            || Checkpoint.CurrentScene == "Hall7"
            || Checkpoint.CurrentScene == "Bathroom")
        {
            SceneManager.LoadScene("Hall5");
        }
        else if (Checkpoint.CurrentScene == "Hall8"
            || Checkpoint.CurrentScene == "Stairway1"
            || Checkpoint.CurrentScene == "Stairway2"
            || Checkpoint.CurrentScene == "Stairway3"
            || Checkpoint.CurrentScene == "KingBedroom"
            || Checkpoint.CurrentScene == "Armoury")
        {
            SceneManager.LoadScene("Armoury");
        }
        else if (Checkpoint.CurrentScene == "Dungeon"
            || Checkpoint.CurrentScene == "WizardTower")
        {
            SceneManager.LoadScene("Dungeon");
        }
        //Debug.Log(PlayerPrefs.GetString("CurrentCheckpoint"));
        //SceneManager.LoadScene(PlayerPrefs.GetString("CurrentCheckpoint"));
    }
}
