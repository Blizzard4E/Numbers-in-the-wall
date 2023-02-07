using System.Collections;
using UnityEngine;

public class CinematicScript : MonoBehaviour
{
    [SerializeField]
    GameObject topDown, fullScene, playerWatch, MainCam;
    IEnumerator setMainCam(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        MainCam.SetActive(true);
        playerWatch.SetActive(false);
        topDown.SetActive(false);
        fullScene.SetActive(false);
    }
    IEnumerator setPlayerWatch(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        MainCam.SetActive(true);
        topDown.SetActive(false);
        fullScene.SetActive(false);
        playerWatch.SetActive(true);
    }

    IEnumerator setFullCam(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        fullScene.SetActive(true);
        topDown.SetActive(false);
        MainCam.SetActive(false);
        playerWatch.SetActive(false);
    } 

    void Start()
    {
        topDown.SetActive(true);
        fullScene.SetActive(false);
        MainCam.SetActive(false);
        playerWatch.SetActive(false);
        StartCoroutine(setFullCam(1f));
        StartCoroutine(setPlayerWatch(2f));
        StartCoroutine(setMainCam(3f));
    }

}
