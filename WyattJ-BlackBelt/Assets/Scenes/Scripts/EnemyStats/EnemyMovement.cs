using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public float EnemyMoveSpeed;
    public float MoveTimer;
    public float MoveDelay;
    private Vector2 targetPos;
    public float range;
    public int EnemyHealth;
    public string EnemyType;
    public string EnemyScene;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
       
    }




    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, targetPos, EnemyMoveSpeed * Time.deltaTime);

        if (Time.time - MoveDelay >= MoveTimer)
        {
            GetNewTarget();
            MoveTimer = Time.time;
        }

        if (Vector3.Distance(Player.transform.position, transform.position) < 5f)
        {
            targetPos = Player.transform.position;
            EnemyMoveSpeed = EnemyMoveSpeed * 1.0001f;
        }
        
        

    }

    public void GetNewTarget()
    {
        targetPos = new Vector2(Random.Range(-range, range), Random.Range(-range, range));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(EnemyScene);
            if (EnemyType == "Chef")
            {
                //cutscene
            }
            if (EnemyType == "Alchemist")
            {
                //cutscene
            }
            if (EnemyType == "King")
            {
                //cutscene
            }
            if (EnemyType == "Wizard")
            {
                //cutscene
            }

        }
       
    }

}
