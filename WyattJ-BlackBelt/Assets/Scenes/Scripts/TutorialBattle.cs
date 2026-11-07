using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;
using TMPro;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class TutorialBattle : MonoBehaviour
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
    public TutorialFireballMinigame fireballMinigame;
    public TutorialSlashMinigame slashMinigame;
    public GameObject emptySlashBar;
    public Image slashBar;
    public Image slashHitBar;
    public bool burn;
    public GameObject Attack1;
    public GameObject Attack2;
    public GameObject Attack4;
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
        Attack1.SetActive(false);
        Attack2.SetActive(false);
        Attack4.SetActive(false);
        GodText.enabled = false;
        ShowText("The battle ends if either you or the enemy runs out of health.", 3f);
        Invoke("ShowSlash", 4f);
        

       
    }

    public void ShowSlash()
    {

        ShowText("To use Slash, click the button, and hold Space until the bar fills up to the green box.", 3f);
        Attack1.SetActive(true);
        turn = true;
    }



    // Update is called once per frame
    void Update()
    {
       
    }

    public void ShowText(string text, float timeShown)
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

    public void FirstEnemyTurn()
    {
        ShowText("The enemy has a 90% to hit you, and has a 10% to miss, but can be upgraded to 20%", 3.5f);
        Invoke("FirstEnemyMove", 3.5f);
    }

    public void EnemyTurn()
    {
        ShowText("There is a 10% chance to apply burn, dealing 0.125 damage each turn.", 3f);

       if (burn == true)
        {
            enemyHealth.EnemyCurrentHealth -= 0.125f;
        }
        Invoke("EnemyMove", 3f);
    }

    public void EnemyMove()
    {
        
            PlayerHealth.TakeDamage(enemyHealth.damage);
      
        ShowText("Now Click Run to run away. You have 50/50 to run or take 0.25 damage.", 3f);
        Attack2.SetActive(false);
        Attack4.SetActive(true);
        PlayerTurn();
        turn = true;
    }
    public void FirstEnemyMove()
    {
            Debug.Log("Enemy Missed");
            ShowText("You Dodged! Now, use fireball.", 3f);
            Attack2.SetActive(true);



        Invoke("PlayerTurn", 3.5f);
        turn = true;
    }

    public void MoveSelected()
    {
        if (moveName == "slash")
        {
            Attack1.SetActive(false);
            Invoke("SlashMinigameSetup", 0.5f);
        }
        else if (moveName == "fireball")
        {
            Attack2.SetActive(false);
            Invoke("FireballMinigameSetup", 0.5f);

       
        }
        else if (moveName == "unique")
        {
            EnemyTurn();
        }
        else if (moveName == "run")
        {
              
                ShowText("You Ran Away!", 1f);
                Debug.Log("You got away");
                Invoke("RanAwayVisuals", 1);
       
                
            

   
        }

    }



    public void PlayerTurn()
    {
        Debug.Log("Your Turn");
    }

    public void SlashMove()
    {
      
            Debug.Log("slash");
            moveName = "slash";
            MoveSelected();
            turn = false;
            Attack1.SetActive(false);
        
        
        
        
    }

    public void FireballMove()
    {
 
            Debug.Log("fireball");
            moveName = "fireball";
            MoveSelected();
            turn = false;
          
            
     


        
    }

    //public void UniqueMove()
    //{
    //    if (turn == true)
    //    {
    //        Debug.Log("unique");
    //        moveName = "unique";
    //        MoveSelected();
    //        turn = false;
    //    }
    //    else
    //    {
    //        Debug.Log("Not Your Turn!");
    //    }
    //}

    public void RunMove(int Run)
    {
 
            Debug.Log("run");
            moveName = "run";
            MoveSelected();
            turn = false;
            

 

    


        
 



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
        SceneManager.LoadScene("MainMenu");
    }

    void FireballMinigameSetup()
    {
        ShowText("Click Space to Fill the Bar to use Fireball", 3f);
    
        Invoke("FireballMinigameStart", 3f);
        
        



    }

    void SlashMinigameSetup()
    {
        ShowText("Hold Space until the bar fills up to the green box", 3f);
        Invoke("SlashMinigameStart", 3f);
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
        StartCoroutine("DoDamage", 10);

      
        ShowText("Slash does a guaranteed 0.5 damage, and has a 10% chance to hit for 0.75 damage.", 4f);
        Invoke("FirstEnemyTurn", 4.5f);
    }

    public void SlashMinigameLost()
    {
        ShowText("You Missed! Try again.", 2f);
        slash.transform.position = new Vector3(-3.5f, -2f, 0f);
        slash.GetComponent<SpriteShapeRenderer>().enabled = true;
        Invoke("SlashVisuals", 1);
        SlashMove();
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

                ShowText("You Burned The Enemy!", 1f);
                burn = true;
           
            fireball.GetComponent<SpriteRenderer>().enabled = true;
            Invoke("FireballVisuals", 1);
            StartCoroutine("DoDamage", 20);
        ShowText("Fireball does 1 damage, but has a small chance to miss and damage you instead.", 4f);



        Invoke("EnemyTurn", 4f);
    }


}
