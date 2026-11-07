using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;



public class Health : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public Image[] hearts;
    public float dodge;

    private void Start()
    {
        maxHealth = PlayerPrefs.GetInt("PlayerLevel") + 2;
        if (PlayerPrefs.GetInt("PlayerLevel") >= 4)
        {
            dodge = (PlayerPrefs.GetInt("PlayerLevel") - 4) * 0.25f;
            if (dodge < 0.1f)
            {
                dodge = 0.1f;
            }
        }
        currentHealth = PlayerPrefs.GetFloat("CurrentHealth", maxHealth);
        UpdateHearts();
    }

    private void Update()
    {
        if (PlayerPrefs.GetFloat("EXPBarFill") >= 1f)
        {
            PlayerPrefs.SetFloat("EXPBarFill", 0f);
            PlayerPrefs.SetInt("PlayerLevel", PlayerPrefs.GetInt("PlayerLevel") + 1);
            maxHealth = PlayerPrefs.GetInt("PlayerLevel") + 2;
            Heal(maxHealth);

        }
        if (currentHealth <= 0)
        {
            Debug.Log("Dead");
            SceneManager.LoadScene("DeathScreen");
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        PlayerPrefs.SetFloat("CurrentHealth", currentHealth);
        UpdateHearts();
        
    }
    
    public void Heal(float healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        PlayerPrefs.SetFloat("CurrentHealth", currentHealth);
        UpdateHearts();
     
    }

    public void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].fillAmount = Mathf.Clamp01(currentHealth - i);
            if (i >= maxHealth)
            {
                hearts[i].transform.parent.gameObject.SetActive(false);
            }
            else
            {
                hearts[i].transform.parent.gameObject.SetActive(true);
            }
        }
    }
}


//Old health script
//public class Health : MonoBehaviour
//{
//    public Image[] hearts;
//    public Image currentHeart;

//    public float currentHealth;
//    public int lives;
//    public PlayerMovement PlayerMovement;

//    private float damage;
//    private float heal;
//    private int maxlives;
//    private float maxHealth = 1;

//    // Start is called before the first frame update
//    void Start()
//    {
//        if (lives == 3)
//        {
//            currentHeart = hearts[2];
//        }
//        else if (lives == 2)
//        {
//            currentHeart = hearts[1];
//        }
//        else if (lives == 1)
//        {
//            currentHeart = hearts[0];
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
  

//        currentHeart.fillAmount = currentHealth / maxHealth;


//        if(currentHealth <= 0 && lives == 3)
//        {
//            currentHeart = hearts[1];
//            currentHealth = 1;
//            lives = 2;
//        }
//        else if (currentHealth <= 0 && lives == 2)
//        {
//            currentHeart = hearts[0];
//            currentHealth = 1;
//            lives = 1;
//        }
//        if (Input.GetKeyUp(KeyCode.Q))
//        {
//            damage = 0.25f;
//            TakeDamage();
//        }
//        if (lives <= 1 && currentHealth <= 0)
//        {
//            Debug.Log("Dead");
//            PlayerPrefs.SetFloat("EXPBarFill", 0f);
//            SceneManager.LoadScene("DeathScreen");

//        }
        
    
//    }

   

//    public void TakeDamage()
//    {
//        currentHealth -= damage;
//    }

   
    
//}
