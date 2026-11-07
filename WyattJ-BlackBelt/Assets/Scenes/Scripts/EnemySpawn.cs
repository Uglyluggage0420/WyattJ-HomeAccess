using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public int maxSpawn;
    public GameObject Enemy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Spawn"); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        for (int i = 0; i < maxSpawn; i++)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
            Instantiate(Enemy, transform.position, Quaternion.identity);
        }
       
           
    }
}
