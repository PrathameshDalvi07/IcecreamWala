using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player1TutorialObj;
    [SerializeField] GameObject player2TutorialObj;

    [SerializeField] GameObject icecreamStickObj;
    IcecreamStickController icecreamStickController;

    [SerializeField] GameObject handObj;
    HandHandler handHandler;

    void Start()
    {
        icecreamStickController = icecreamStickObj.GetComponent<IcecreamStickController>();
        handHandler = handObj.GetComponent<HandHandler>();
        Check();
    }

    void Check()
    {
        int checkInt = PlayerPrefs.GetInt("StartOfGameTutorial", 0);
        if (checkInt == 0)
        {
            PlayerPrefs.SetInt("StartOfGameTutorial", 1);
            StartCoroutine(StartTutorial());
        }
        else
        {
            StartRound1();
        }
    }
    
    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(1f);
        player1TutorialObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        IcecreamStickIn();
        yield return new WaitForSeconds(1f);
        player1TutorialObj.SetActive(false);
        yield return new WaitForSeconds(5f);
        IcecreamStickOut();
        yield return new WaitForSeconds(0.5f);
        player2TutorialObj.SetActive(true);
        handObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        player2TutorialObj.SetActive(false);
        yield return new WaitForSeconds(5f);
        handObj.SetActive(false);
    }

    void StartRound1()
    {
        Debug.Log("Start Round 1");
    }

    void IcecreamStickIn()
    {
        icecreamStickObj.SetActive(true);
        icecreamStickController.enabled = true;
        icecreamStickObj.transform.DOMoveX(0f, 0.5f).SetEase(Ease.InOutSine);
    }

    void IcecreamStickOut()
    {
        icecreamStickController.enabled = false;
        icecreamStickObj.transform.DOMoveX(-20f, 0.5f).SetEase(Ease.InOutSine).OnComplete(() => icecreamStickObj.SetActive(true));
    }
}
