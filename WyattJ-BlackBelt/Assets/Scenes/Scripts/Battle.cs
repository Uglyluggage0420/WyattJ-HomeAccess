using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Battle : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public Health PlayerHealth;
    public bool turn;
    public string moveName;
    public Health health;
    private float damage;
    public GameObject slash;
    public GameObject fireball;
    public GameObject failedfireball;
    public SpriteShapeRenderer SpriteShapeRenderer;
    public float speed =  5f;
    public GameObject Enemy;
    public PlayerMovement Scene;
    public Image fireballBar;
    public GameObject emptyfireballBar;
    public FireballMinigame fireballMinigame;
    public SlashMinigame slashMinigame;
    public GameObject emptySlashBar;
    public Image slashBar;
    public Image slashHitBar;
    public bool burn;
   // public TextMeshProUGUI EnemyMissed;
    public TextMeshProUGUI GodText;

    // Start is called before the first frame update
    void Start()
    {
     //   EnemyMissed.enabled = false;
        slashMinigame.slashMinigame = false;
        slashBar.enabled = false;
        emptySlashBar.GetComponent<Image>().enabled = false;
        slashHitBar.GetComponent<Image>().enabled = false;
        fireballMinigame.minigame = false;
        fireballBar.enabled = false;
        emptyfireballBar.GetComponent<Image>().enabled = false;
        Scene.EXPbar.fillAmount = PlayerPrefs.GetFloat("EXPBarFill");
        FireballVisuals();
        SlashVisuals();
        failedfireball.GetComponent<SpriteRenderer>().enabled = false;
        moveName = "nothing";
        turn = true;
        burn = false;
        GodText.enabled = false;

       
    }



    // Update is called once per frame
    void Update()
    {

    }

    void ShowText(string text, float timeShown)
    {
        GodText.enabled = true;
        GodText.text = text;

        Invoke("DestroyText", timeShown);
    }

    void DestroyText()
    {
        GodText.enabled = false;
    }

    void SlashVisuals()
    {
        slash.GetComponent<SpriteShapeRenderer>().enabled = false;
    }

    void FireballVisuals()
    {
        fireball.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void EnemyTurn()
    {
       if (burn == true)
        {
            enemyHealth.EnemyCurrentHealth -= 0.125f;
        }
        Invoke("EnemyMove", 1.5f);
    }

    public void EnemyMove()
    {
        float enemyAccuracy = Random.Range(0, 10);
        if (enemyAccuracy >= 9f - PlayerHealth.dodge)
        {
            Debug.Log("Enemy Missed");
            ShowText("You Dodged!", 1f);

        }
        else
        {
            float enemyCrit = Random.Range(0, 10);
            if (enemyCrit >= 9f)
            {
                PlayerHealth.TakeDamage(enemyHealth.damage + 0.25f);
                Debug.Log("You were hit with crit!");
                ShowText("Brutal!", 1f);
            }
            else
            {
                PlayerHealth.TakeDamage(enemyHealth.damage);
            }
                
        }

        PlayerTurn();
        turn = true;
    }

     public void MoveSelected()
    {
        if (moveName == "slash")
        {
            Invoke("SlashMinigameSetup", 0.5f);
        }
        else if (moveName == "fireball")
        {

            Invoke("FireballMinigameSetup", 0.5f);

       
        }
        else if (moveName == "unique")
        {
            EnemyTurn();
        }
        else if (moveName == "run")
        {
            int Run = Random.Range(0, 2);
            if (Run >= 1)
            {
                ShowText("You Ran Away!", 1f);
                Debug.Log("You got away");
                Invoke("RanAwayVisuals", 1);
       
                
            }
            else
            {
                ShowText("You Failed To Run Away", 1f);
                Debug.Log("You failed to run away");
                PlayerHealth.TakeDamage(0.25f);
            }
            EnemyTurn();
        }

    }



    public void PlayerTurn()
    {
        Debug.Log("Your Turn");
    }

    public void SlashMove()
    {
        if (turn == true)
        {
            Debug.Log("slash");
            moveName = "slash";
            MoveSelected();
            turn = false;
        }
        else
        {
            Debug.Log("Not Your Turn!");
        }
        
        
        
    }

    public void FireballMove()
    {
        if (turn == true)
        {
            Debug.Log("fireball");
            moveName = "fireball";
            MoveSelected();
            turn = false;
          
            
        }
        else
        {
            Debug.Log("Not Your Turn!");
        }

        
    }

    public void UniqueMove()
    {
        if (turn == true)
        {
            Debug.Log("unique");
            moveName = "unique";
            MoveSelected();
            turn = false;
        }
        else
        {
            Debug.Log("Not Your Turn!");
        }
    }

    public void RunMove(int Run)
    {
        if (turn == true)
        {
            Debug.Log("run");
            moveName = "run";
            MoveSelected();
            turn = false;
            
        }
        else
        {
            Debug.Log("Not Your Turn!");
        }

    


        
 



    }

    public void FailedFireballVisuals()
    {
        failedfireball.GetComponent<SpriteRenderer>().enabled = false;
    }

    IEnumerator DoDamage(int hitAmount)
    {
        for (int i = 0; i < hitAmount; i++)
        {
            enemyHealth.EnemyCurrentHealth -= 0.05f;
            yield return new WaitForSeconds(0.0075f);
        }
    }

 


    void RanAwayVisuals()
    {
        SceneManager.LoadScene(Scene.currentScene);
    }

    void FireballMinigameSetup()
    {
        ShowText("Click Space to Fill the Bar to use Fireball", 2f);
    
        Invoke("FireballMinigameStart", 2f);
        
        



    }

    void SlashMinigameSetup()
    {
        ShowText("Hold Space until the bar fills up to the green box", 2f);
        Invoke("SlashMinigameStart", 2f);
    }

    void SlashMinigameStart()
    {
        slashBar.enabled = true;
        slashBar.fillAmount = 0f;
        slashHitBar.GetComponent<Image>().enabled = true;
        emptySlashBar.GetComponent<Image>().enabled = true;
        slashMinigame.slashMinigame = true;
    }

    public void SlashMinigameWin()
    {
        int critChance = Random.Range(0, 10);
 
        slash.transform.position = new Vector3 (3.88f, -0.88f, 0f);
        slash.GetComponent<SpriteShapeRenderer>().enabled = true;
        Invoke("SlashVisuals", 1);
        if (critChance == 9)
        {
            ShowText("CRITICAL HIT!", 1f);
            StartCoroutine("DoDamage", 15);
        }
        else
        {
            StartCoroutine("DoDamage", 10);

        }
        //enemyHealth.EnemyCurrentHealth -= 0.25f;
        //enemyHealth.EnemyCurrentHealth -= 0.25f;
        EnemyTurn();
    }

    public void SlashMinigameLost()
    {
        ShowText("You Missed!", 1f);
        slash.transform.position = new Vector3(-3.5f, -2f, 0f);
        slash.GetComponent<SpriteShapeRenderer>().enabled = true;
        Invoke("SlashVisuals", 1);
        EnemyTurn();
    }

    void FireballMinigameStart()
    {
        fireballBar.enabled = true;
        fireballBar.fillAmount = 0.3f;
        emptyfireballBar.GetComponent<Image>().enabled = true;
        fireballMinigame.minigame = true;
        
    }

    public void ActivateEnemyTurn()
    {
        EnemyTurn();
    }

    public void FireballMinigameDone()
    {
        int accuracy = Random.Range(0, 13);
        if (accuracy <= 9)
        {
            int burnChance = Random.Range(0, 10);
            if (burnChance <= 1)
            {
                ShowText("You Burned The Enemy!", 1f);
                burn = true;
            }
            fireball.GetComponent<SpriteRenderer>().enabled = true;
            Invoke("FireballVisuals", 1);
            StartCoroutine("DoDamage", 20);
        }
        else
        {
            ShowText("You Missed!", 1f);
            failedfireball.GetComponent<SpriteRenderer>().enabled = true;
            Invoke("FailedFireballVisuals", 1);
            PlayerHealth.TakeDamage(0.25f);
        }
        EnemyTurn();
    }


}
