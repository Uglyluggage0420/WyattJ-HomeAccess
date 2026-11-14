using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChefSlashMinigame : MonoBehaviour
{
    public ChefBattle battle;
    public bool slashMinigame;
    public Image SlashBar;
    public Image emptySlashBar;
    public Image SlashHitBar;
    public float randomX;
    public RectTransform targetZone;
    // Start is called before the first frame update
    void Start()
    {
   
    }

    private void OnEnable()
    {
        randomX = Random.Range(-360, -163f);
        SlashBar.fillAmount = 0f;
        SlashHitBar.GetComponent<Image>().enabled = true;
        SlashHitBar.transform.localPosition = new Vector3(randomX, SlashHitBar.transform.localPosition.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (slashMinigame ==  true)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SlashBar.fillAmount += 0.5f * Time.deltaTime;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                OnTargetZone();
                if (OnTargetZone())
                {
                    battle.SlashMinigameWin();
                    slashMinigame = false;
                    emptySlashBar.GetComponent<Image>().enabled = false;
                    SlashHitBar.GetComponent<Image>().enabled = false;
                    SlashBar.enabled = false;
                    
                }
                else if (!OnTargetZone())
                {
                    battle.SlashMinigameLost();
                    slashMinigame = false;
                    emptySlashBar.GetComponent<Image>().enabled = false;
                    SlashHitBar.GetComponent<Image>().enabled = false;
                    SlashBar.enabled = false;
                }
            }

        }
    }

    bool OnTargetZone()
    {
        if (SlashBar == null || targetZone == null) return false;

        Vector3[] barCorners = new Vector3[4];
        SlashBar.rectTransform.GetWorldCorners(barCorners);

        float barLeftX = barCorners[0].x;
        float barRightX = barCorners[2].x;
        float barWidth = barRightX - barLeftX;

        float currentEdgeX = barLeftX + (barWidth * SlashBar.fillAmount);

        Vector3[] targetCorners = new Vector3[4];
        targetZone.GetWorldCorners(targetCorners);

        float targetMinX = targetCorners[0].x;
        float targetMaxX = targetCorners[2].x;
        float targetMinY = targetCorners[0].y;
        float targetMaxY = targetCorners[2].y;

        bool insideX = currentEdgeX >= targetMinX && currentEdgeX <= targetMaxX;
        bool insideY = barCorners[0].y <= targetMaxY && barCorners[2].y >= targetMinY;

        return insideX && insideY;
    }
}
