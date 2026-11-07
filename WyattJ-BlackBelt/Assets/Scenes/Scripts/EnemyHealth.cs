using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Image[] EnemyHearts;
    public Image EnemyCurrentHeart;
    public float EnemyMaxHealth = 1;
    public float EnemyCurrentHealth;
    public int EnemyLives;
    public int numberOfHearts;
    public float damage;
    public Health health;
    public float EXPgiven;
    public int minGold;
    public int maxGold;
    public PlayerMovement EXP;
    public bool enemyIsChef;
    // Start is called before the first frame update
    void Start()
    {
        EXP.currentScene = PlayerPrefs.GetString("CurrentScene");
        //EXP.EXPbar.fillAmount = PlayerPrefs.GetFloat("EXPBarFill");
        EnemyCurrentHealth = 1;
        EnemyLives = numberOfHearts;
        EnemyCurrentHeart = EnemyHearts[EnemyHearts.Length -1];
    }

    // Update is called once per frame
    void Update()
    {
        EnemyCurrentHeart.fillAmount = EnemyCurrentHealth / 
            EnemyMaxHealth;

        if (EnemyCurrentHealth <= 0 && EnemyLives == 6)
        {
            EnemyCurrentHeart = EnemyHearts[4];
            EnemyCurrentHealth = 1;
            EnemyLives = 5;
        }
        else if (EnemyCurrentHealth <= 0 && EnemyLives == 5)
        {
            EnemyCurrentHeart = EnemyHearts[3];
            EnemyCurrentHealth = 1;
            EnemyLives = 4;
        }
        else if (EnemyCurrentHealth <= 0 && EnemyLives == 4)
        {
            EnemyCurrentHeart = EnemyHearts[2];
            EnemyCurrentHealth = 1;
            EnemyLives = 3;
        }
        else if (EnemyCurrentHealth <= 0 && EnemyLives == 3)
        {
            EnemyCurrentHeart = EnemyHearts[1];
            EnemyCurrentHealth = 1;
            EnemyLives = 2;
        }
        else if (EnemyCurrentHealth <= 0 && EnemyLives == 2)
        {
            EnemyCurrentHeart = EnemyHearts[0];
            EnemyCurrentHealth = 1;
            EnemyLives = 1;
        }
        if (EnemyLives <= 1 && EnemyCurrentHealth <= 0)
        {
            if (enemyIsChef == true)
            {
                PlayerPrefs.SetInt("ChefAlive", 0);
                health.Heal(100f);
            }
            health.Heal(0.25f);
            Debug.Log("You beat the Enemy!");
            EXP.EXPbar.fillAmount += EXPgiven;
            PlayerPrefs.SetFloat("EXPBarFill", EXP.EXPbar.fillAmount);
            SceneManager.LoadScene(EXP.currentScene);

        }
    

    }

    //public void TakeEnemyDamage()
    //{
   //     EnemyCurrentHealth -= damage;
    //}

    
}
