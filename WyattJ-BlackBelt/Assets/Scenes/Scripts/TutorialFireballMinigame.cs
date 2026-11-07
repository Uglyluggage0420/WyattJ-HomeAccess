using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialFireballMinigame : MonoBehaviour
{
    public TutorialBattle Battle;
    public Image fireballBar;
    public Image emptyFireballBar;
    public Health health;
    public bool minigame;
    // Start is called before the first frame update
    void Start()
    {
        fireballBar.fillAmount = 0.25f;
    }

    private void OnEnable()
    {
        fireballBar.fillAmount = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        if (minigame == true)
        {
            fireballBar.fillAmount -= 0.4f * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                fireballBar.fillAmount += 0.095f;
            }

            if (fireballBar.fillAmount <= 0)
            {
                Battle.ShowText("You missed. Try again!", 2f);
                minigame = false;
                fireballBar.fillAmount = 0.25f;
                minigame = true;
                //Battle.ActivateEnemyTurn();
                //Battle.FailedFireballVisuals();
                //health.TakeDamage(0.25f);
                //minigame = false;
                //emptyFireballBar.GetComponent<Image>().enabled = false;
                //fireballBar.enabled = false;
            }
            else if (fireballBar.fillAmount >= 1)
            {
                Battle.FireballMinigameDone();
                minigame = false;
                emptyFireballBar.GetComponent<Image>().enabled = false;
                fireballBar.enabled = false;
            }
        }

    }
}
