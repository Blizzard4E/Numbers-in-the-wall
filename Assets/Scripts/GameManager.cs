using System.Collections;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int map = 0;
    public int wallsAmount = 10;
    public GameObject bigWalls;
    int[] answers;
    float startingDistance = 40f; 
    float distanceBetween = 10f;
    bool playerLose = false;
    [SerializeField]
    PlayerMovement player;
    [SerializeField]
    LoseBarrier barrier;
    [SerializeField]
    TMP_Text countdownText;
    float timePassed = 0f;
    int countdownNum = 0;
    [SerializeField]
    Transform cloudLeft;
    [SerializeField]
    Transform cloudRight;
    float cloudSpeed = 1.5f;
    [SerializeField]
    TMP_Text nText, numText, fText, formulaText;
    public int nCount = 0;
    [SerializeField]
    GameObject winText, loseText, menuBtn, blackBg;
    AudioSource audio;
    [SerializeField]
    AudioSource fallWater;
    [SerializeField]
    AudioSource crowdCheerLoop;
    [SerializeField]
    AudioClip countDown, crowdCheer1;
    
    IEnumerator playCrowdCheer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        audio.PlayOneShot(crowdCheer1);
    }
    IEnumerator playCountDown(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        audio.PlayOneShot(countDown);
    }
    IEnumerator showFormula(float waitTime, string formula)
    {
        yield return new WaitForSeconds(waitTime);
        fText.text = "Formula:";
        nText.text = "n:";
        formulaText.text = formula;
        numText.gameObject.SetActive(true);
    }

    IEnumerator spawnWalls(float waitTime)
    {
        map = Random.Range(0, 10);
        yield return new WaitForSeconds(waitTime);
        answers = new int[wallsAmount];
        switch(map)
        {
            case 0:
                StartCoroutine(showFormula(3f, "2n + 1"));
                for(int i = 0; i < wallsAmount; i++)
                {
                    int currentAnswer = (2 * i) + 1;
                    answers[i] = currentAnswer;
                    GameObject bigWall = Instantiate(bigWalls, new Vector3(0, 2.75f, startingDistance + (i * 20f)), Quaternion.identity);
                    bigWall.transform.GetComponent<BigWall>().correctNumber = currentAnswer;
                    bigWall.transform.GetComponent<BigWall>().player = player;
                }
                break;
            case 1:
                StartCoroutine(showFormula(3f, "3n - 4"));
                for(int i = 0; i < wallsAmount; i++)
                {
                    int currentAnswer = (3 * i) - 4;
                    answers[i] = currentAnswer;
                    GameObject bigWall = Instantiate(bigWalls, new Vector3(0, 2.75f, startingDistance + (i * 20f)), Quaternion.identity);
                    bigWall.transform.GetComponent<BigWall>().correctNumber = currentAnswer;
                    bigWall.transform.GetComponent<BigWall>().player = player;
                }
                break;
            case 2:
                StartCoroutine(showFormula(3f, "2n + 3"));
                for(int i = 0; i < wallsAmount; i++)
                {
                    int currentAnswer = (2 * i) + 3;
                    answers[i] = currentAnswer;
                    GameObject bigWall = Instantiate(bigWalls, new Vector3(0, 2.75f, startingDistance + (i * 20f)), Quaternion.identity);
                    bigWall.transform.GetComponent<BigWall>().correctNumber = currentAnswer;
                    bigWall.transform.GetComponent<BigWall>().player = player;
                }
                break;
            case 3:
                StartCoroutine(showFormula(3f, "7n + n"));
                for(int i = 0; i < wallsAmount; i++)
                {
                    int currentAnswer = (7 * i) + i;
                    answers[i] = currentAnswer;
                    GameObject bigWall = Instantiate(bigWalls, new Vector3(0, 2.75f, startingDistance + (i * 20f)), Quaternion.identity);
                    bigWall.transform.GetComponent<BigWall>().correctNumber = currentAnswer;
                    bigWall.transform.GetComponent<BigWall>().player = player;
                }
                break;
            case 4:
                StartCoroutine(showFormula(3f, "n^2 + n + 2"));
                for(int i = 0; i < wallsAmount; i++)
                {
                    int currentAnswer = (i * i) + i + 2;
                    answers[i] = currentAnswer;
                    GameObject bigWall = Instantiate(bigWalls, new Vector3(0, 2.75f, startingDistance + (i * 20f)), Quaternion.identity);
                    bigWall.transform.GetComponent<BigWall>().correctNumber = currentAnswer;
                    bigWall.transform.GetComponent<BigWall>().player = player;
                }
                break;
            case 5:
                StartCoroutine(showFormula(3f, "n^2"));
                for(int i = 0; i < wallsAmount; i++)
                {
                    int currentAnswer = (i * i);
                    answers[i] = currentAnswer;
                    GameObject bigWall = Instantiate(bigWalls, new Vector3(0, 2.75f, startingDistance + (i * 20f)), Quaternion.identity);
                    bigWall.transform.GetComponent<BigWall>().correctNumber = currentAnswer;
                    bigWall.transform.GetComponent<BigWall>().player = player;
                }
                break;
            case 6:
                StartCoroutine(showFormula(3f, "n^2 - 3n"));
                for(int i = 0; i < wallsAmount; i++)
                {
                    int currentAnswer = (i * i) - (3 * i);
                    answers[i] = currentAnswer;
                    GameObject bigWall = Instantiate(bigWalls, new Vector3(0, 2.75f, startingDistance + (i * 20f)), Quaternion.identity);
                    bigWall.transform.GetComponent<BigWall>().correctNumber = currentAnswer;
                    bigWall.transform.GetComponent<BigWall>().player = player;
                }
                break;
            case 7:
                StartCoroutine(showFormula(3f, "n^2 - 1"));
                for(int i = 0; i < wallsAmount; i++)
                {
                    int currentAnswer = (i * i) - 1;
                    answers[i] = currentAnswer;
                    GameObject bigWall = Instantiate(bigWalls, new Vector3(0, 2.75f, startingDistance + (i * 20f)), Quaternion.identity);
                    bigWall.transform.GetComponent<BigWall>().correctNumber = currentAnswer;
                    bigWall.transform.GetComponent<BigWall>().player = player;
                }
                break;
            case 8:
                StartCoroutine(showFormula(3f, "n^2 - n"));
                for(int i = 0; i < wallsAmount; i++)
                {
                    int currentAnswer = (i * i) - i;
                    answers[i] = currentAnswer;
                    GameObject bigWall = Instantiate(bigWalls, new Vector3(0, 2.75f, startingDistance + (i * 20f)), Quaternion.identity);
                    bigWall.transform.GetComponent<BigWall>().correctNumber = currentAnswer;
                    bigWall.transform.GetComponent<BigWall>().player = player;
                }
                break;
            case 9:
                StartCoroutine(showFormula(3f, "2n^2 + 1"));
                for(int i = 0; i < wallsAmount; i++)
                {
                    int currentAnswer = (2 * (i * i)) + 1;
                    answers[i] = currentAnswer;
                    GameObject bigWall = Instantiate(bigWalls, new Vector3(0, 2.75f, startingDistance + (i * 20f)), Quaternion.identity);
                    bigWall.transform.GetComponent<BigWall>().correctNumber = currentAnswer;
                    bigWall.transform.GetComponent<BigWall>().player = player;
                }
                break;
        }
    }

    void Start()
    {
        audio = transform.GetComponent<AudioSource>();
        StartCoroutine(playCrowdCheer(0.5f));
        StartCoroutine(playCountDown(1f));
        StartCoroutine(spawnWalls(2f));
    }
    private void Update()
    {
        if(player.hasLost)
        {
            loseText.SetActive(true);
            menuBtn.SetActive(true);
            blackBg.SetActive(true);
            fText.text = "";
            nText.text = "";
            formulaText.text = "";
            numText.gameObject.SetActive(false);
            crowdCheerLoop.volume -= 0.002f;
        }
        if(nCount == 10)
        {
            winText.SetActive(true);
            menuBtn.SetActive(true);
            blackBg.SetActive(true);
            player.hasWon = true;
            fText.text = "";
            nText.text = "";
            formulaText.text = "";
            numText.gameObject.SetActive(false);
        }
        if(cloudLeft.position.x > -21f)
        {
            cloudLeft.Translate(Vector3.left * cloudSpeed * Time.deltaTime);
        }
        if(cloudRight.position.x < 21f)
        {
            cloudRight.Translate(Vector3.left * cloudSpeed * Time.deltaTime);
        }
        if(barrier.playerTouch)
        {
            playerLose = true;
            player.hasLost = true;
        }
        if(countdownNum < 5)
        {   
            if(timePassed > 1f)
            {
                countdownNum++;
                if(countdownNum >= 5)
                {
                    countdownText.text = "";
                }
                else if(countdownNum == 4)
                {
                    countdownText.text = "The Walls Are Coming!";
                    countdownText.color = Color.red;
                }
                else 
                {
                    countdownText.text = countdownNum.ToString();
                }
                timePassed = 0f;
            }
            timePassed += Time.deltaTime;
        }
        numText.text = nCount.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            fallWater.Play();
            playerLose = true;
            player.hasLost = true;
        }
    }
}
