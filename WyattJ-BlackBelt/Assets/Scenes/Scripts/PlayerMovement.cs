using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Inventory inventory;
    public Health healing;
    public Image EXPbar;
    public string currentScene;
    // Start is called before the first frame update
    void Start()
    {
        if (currentScene == "Entrance")
        {
            PlayerPrefs.SetString("CurrentCheckpoint", "Entrance");
        }
        else if (currentScene == "Hall5")
        {
            PlayerPrefs.SetString("CurrentCheckpoint", "Hall5");
        }
        else if (currentScene == "Armoury")
        {
            PlayerPrefs.SetString("CurrentCheckpoint", "Armoury");
        }
        else if (currentScene == "Dungeon")
        {
            PlayerPrefs.SetString("CurrentCheckpoint", "Dungeon");
        }
        else
        {
            PlayerPrefs.SetString("CurrentCheckpoint", PlayerPrefs.GetString("CurrentCheckpoint"));
        }
            EXPbar.fillAmount = PlayerPrefs.GetFloat("EXPBarFill");
        PlayerPrefs.SetString("CurrentScene", SceneManager.GetActiveScene().name);
        transform.position = new Vector3(PlayerPrefs.GetFloat("Xpos"), PlayerPrefs.GetFloat("Ypos"), 0);
    }

    // Update is called once per frame
    void Update()
    {

        PlayerPrefs.SetFloat("Xpos", transform.position.x);
        PlayerPrefs.SetFloat("Ypos", transform.position.y);
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector2(moveX, moveY).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            Debug.Log("NextScene");
            currentScene = collision.gameObject.GetComponent<NextRoom>().nextRoomName;
            transform.position = collision.gameObject.GetComponent<NextRoom>().SpawnFromRoom.transform.position;
            SceneManager.LoadScene(currentScene);
        }
        else if (collision.gameObject.tag == "item")
        {
            inventory.AddItem(collision.gameObject.GetComponent<ItemInfo>().itemData);
            Destroy(collision.gameObject);
            Debug.Log("Pick up");
        }
        else if (collision.gameObject.tag == "HealingStation")
        {
            healing.Heal(184467440737095516152075802702759999999.9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999f);
        }
        
    }
}

