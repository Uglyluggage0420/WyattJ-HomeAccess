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

    public GameObject canvas;
    public GameObject tutorialBackground;
    public List<GameObject> tutorialBlocks;
    public int tutorialCounter;
    public TextMeshProUGUI tutorialText;
        

    // Start is called before the first frame update
    void Start()
    {
     //   EnemyMissed.enabled = false;
        slashMinigame.slashMinigame = false;
        fireballMinigame.minigame = false;
        fireballBar.GetComponent<Image>().enabled = false;
        emptyfireballBar.GetComponent<Image>().enabled = false;
        Scene.EXPbar.fillAmount = PlayerPrefs.GetFloat("EXPBarFill");
        failedfireball.GetComponent<SpriteRenderer>().enabled = false;
        moveName = "nothing";
        turn = true;
        burn = false;
        GodText.enabled = false;
        tutorialText.enabled = true;
        tutorialText.transform.localPosition = Vector3.zero;
        tutorialText.transform.SetAsLastSibling();
        

       
    }




    // Update is called once per frame
    void Update()
    {


        //if (Input.GetKeyDown(KeyCode.E) && tutorialCounter == tutorialBlocks.Count)
        //{
        //    tutorialBlocks[tutorialCounter - 1].transform.SetParent(canvas.transform, true);
        //    tutorialBlocks[tutorialCounter - 2].transform.SetParent(null);
        //}
        //else if (Input.GetKeyDown(KeyCode.E) && tutorialCounter < tutorialBlocks.Count)
        //{
        //    if (tutorialCounter - 1 >= 1)
        //    {
        //        tutorialBlocks[tutorialCounter - 1].transform.SetParent(canvas.transform, true);
        //        tutorialBlocks[tutorialCounter - 2].transform.SetParent(null);
        //    }
        //    else
        //    {
        //        tutorialBlocks[tutorialCounter - 1].transform.SetParent(tutorialBackground.transform, true);
        //    }

           
        //}

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (tutorialCounter == 0)
            {
                tutorialText.text = "This is you, the player";
                tutorialText.transform.localPosition = new Vector3(-245, -10, 0);
                tutorialBlocks[0].transform.SetParent(tutorialBackground.transform, true);
                tutorialBackground.transform.SetAsLastSibling();
                tutorialText.transform.SetAsLastSibling();
            }
            else if (tutorialCounter == 1)
            {
                tutorialText.text = "This is your health bar";
                tutorialText.transform.localPosition = new Vector3(-30, 190, 0);
                tutorialBlocks[0].transform.SetParent(canvas.transform, true);
                tutorialBlocks[1].transform.SetParent(tutorialBackground.transform, true);
                tutorialBackground.transform.SetAsLastSibling();
                tutorialText.transform.SetAsLastSibling();
            }
            else if (tutorialCounter == 2)
            {
                tutorialText.text = "This is the enemy you are fighting";
                tutorialText.transform.localPosition = new Vector3(245, 136, 0);
                tutorialBlocks[1].transform.SetParent(canvas.transform, true);
                tutorialBlocks[2].transform.SetParent(tutorialBackground.transform, true);
                tutorialBackground.transform.SetAsLastSibling();
                tutorialText.transform.SetAsLastSibling();
            }
            else if (tutorialCounter == 3)
            {
                tutorialText.text = "And this is the enemy's health";
                tutorialText.transform.localPosition = new Vector3(180, 194, 0);
                tutorialBlocks[2].transform.SetParent(canvas.transform, true);
                tutorialBlocks[3].transform.SetParent(tutorialBackground.transform, true);
                tutorialBackground.transform.SetAsLastSibling();
                tutorialText.transform.SetAsLastSibling();
            }
            else if (tutorialCounter == 4)
            {
                tutorialText.text = "This is your slashing move";
                tutorialText.transform.localPosition = new Vector3(100, -50, 0);
                tutorialBlocks[3].transform.SetParent(canvas.transform, true);
                tutorialBlocks[4].transform.SetParent(tutorialBackground.transform, true);
                tutorialBackground.transform.SetAsLastSibling();
                tutorialText.transform.SetAsLastSibling();
            }
            else if (tutorialCounter == 5)
            {
                tutorialText.text = "This is fireball, but can be changed";
                tutorialText.transform.localPosition = new Vector3(280, -175, 0);
                tutorialBlocks[4].transform.SetParent(canvas.transform, true);
                tutorialBlocks[5].transform.SetParent(tutorialBackground.transform, true);
                tutorialBackground.transform.SetAsLastSibling();
                tutorialText.transform.SetAsLastSibling();

            }
            else if (tutorialCounter == 6)
            {
                tutorialText.text = "This is your run move";
                tutorialText.transform.localPosition = new Vector3(320, 25, 0);
                tutorialBlocks[5].transform.SetParent(canvas.transform, true);
                tutorialBlocks[6].transform.SetParent(tutorialBackground.transform, true);
                tutorialBackground.transform.SetAsLastSibling();
                tutorialText.transform.SetAsLastSibling();

            }
            else if (tutorialCounter == 7)
            {
                tutorialText.text = "This is your action bar, where you power up moves";
                tutorialText.transform.localPosition = new Vector3(0, 60, 0);
                tutorialBlocks[6].transform.SetParent(canvas.transform, true);
                tutorialBlocks[7].transform.SetParent(tutorialBackground.transform, true);
                tutorialBackground.transform.SetAsLastSibling();
                tutorialText.transform.SetAsLastSibling();

            }
            else if (tutorialCounter == 8)
            {
                tutorialText.text = "Finally, this is your EXP bar, which isn't important in battle";
                tutorialText.transform.localPosition = new Vector3(0, 110, 0);
                tutorialBlocks[7].transform.SetParent(canvas.transform, true);
                tutorialBlocks[8].transform.SetParent(tutorialBackground.transform, true);
                tutorialBackground.transform.SetAsLastSibling();
                tutorialText.transform.SetAsLastSibling();

            }
            tutorialCounter++;
        }

       
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


    public void EnemyTurn()
    {

       if (burn == true)
        {
            enemyHealth.EnemyCurrentHealth -= 0.125f;
        }
        Invoke("EnemyMove", 3f);
    }

    public void EnemyMove()
    {
        
            PlayerHealth.TakeDamage(enemyHealth.damage);
        PlayerTurn();
        turn = true;
    }
    public void FirstEnemyMove()
    {
            Debug.Log("Enemy Missed");



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
