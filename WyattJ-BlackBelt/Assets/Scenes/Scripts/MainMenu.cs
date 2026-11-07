using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Health healthStats;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("ChefAlive", 1);
        PlayerPrefs.SetFloat("Xpos", -8);
        PlayerPrefs.SetFloat("Ypos", 0);
        PlayerPrefs.SetFloat("CurrentHealth", PlayerPrefs.GetInt("PlayerLevel") + 2);
        PlayerPrefs.SetInt("PlayerLevel", 1);
        PlayerPrefs.SetFloat("EXPBarFill", 0f);
        PlayerPrefs.SetString("CurrentScene", "Entrance");

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void ToCurrentScene()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrentScene"));
    }
}
