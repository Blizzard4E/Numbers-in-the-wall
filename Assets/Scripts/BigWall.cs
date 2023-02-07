using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BigWall : MonoBehaviour
{
    [SerializeField]
    public GameObject[] walls;
    [SerializeField]
    public TMP_Text[] numbers;
    public int correctNumber;
    public float speed = 3f;
    public float wallSpeedUpSpeed = 0.05f;
    public PlayerMovement player;

    private void Start()
    {
        int rand = Random.Range(0, walls.Length);
        walls[rand].GetComponent<BoxCollider>().isTrigger = true;
        walls[rand].GetComponent<SmallWallLogic>().isCorrect = true;
        numbers[rand].text = correctNumber.ToString();

        for(int i = 0; i < walls.Length; i++)
        {
            if(i != rand)
            {
                int randomAdd = 0;
                while(randomAdd == 0)
                {
                    randomAdd = Random.Range(-5, 5);
                }
                numbers[i].text = (correctNumber + randomAdd).ToString();
            }
        }
    }

    private void Update()
    {
        if(!player.hasLost)
        {
            transform.Translate(0, 0, -speed * Time.deltaTime);
            if(speed < 6)
            {
                speed += wallSpeedUpSpeed * Time.deltaTime;
            }
        }
    }
}
