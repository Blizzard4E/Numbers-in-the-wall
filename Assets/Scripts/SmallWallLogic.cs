using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
using UnityEngine;

public class SmallWallLogic : MonoBehaviour
{
    public bool isCorrect = false;
    public int number;
    [SerializeField]
    public GameObject original;
    [SerializeField]
    public GameObject[] breakables;
    private BoxCollider collder;
    [SerializeField]
    GameObject numText;
    bool hasHit = false;

    private void Start()
    {
        collder = transform.GetComponent<BoxCollider>();
        if(isCorrect) collder.isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            int rand = Random.Range(0, breakables.Length);
            GameObject newWall = Instantiate(breakables[rand], transform.position, Quaternion.identity, transform);
            newWall.transform.parent = null;
            Destroy(original);
            Destroy(numText);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player" && !hasHit)
        {
            hasHit = true;
            GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameManager>().nCount++;
        }
    }
}
