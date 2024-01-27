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

    int timer = 5;

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
            StartCoroutine(StartRound1());
        }
    }
    
    IEnumerator StartTutorial()
    {
        yield return new WaitForSeconds(1f);
        IcecreamStickIn();
        yield return new WaitForSeconds(1f);
        player1TutorialObj.SetActive(true);
        yield return new WaitUntil(() => icecreamStickController.numOfTap > 1);
        player1TutorialObj.SetActive(false);
        yield return new WaitForSeconds(5f);
        IcecreamStickOut();


        yield return new WaitForSeconds(0.5f);
        player2TutorialObj.SetActive(true);
        handObj.SetActive(true);
        yield return new WaitUntil(() => handHandler.numOfTap > 0);
        player2TutorialObj.SetActive(false);
        yield return new WaitForSeconds(5f);
        handObj.SetActive(false);
        yield return new WaitForSeconds(1f);
        yield return StartRound1();
    }

    IEnumerator StartRound1()
    {
        //UIManager.Instance.SetTextAndPlayIn("Round 1");
        //yield return new WaitForSeconds(2.5f);
        //UIManager.Instance.SetTextAndPlayIn("3");
        //yield return new WaitForSeconds(0.5f);
        //UIManager.Instance.SetTextAndPlayIn("2");
        //yield return new WaitForSeconds(0.5f);
        //UIManager.Instance.SetTextAndPlayIn("1");
        //yield return new WaitForSeconds(0.5f);
        //UIManager.Instance.SetTimer(timer);
        IcecreamStickIn();
        handObj.SetActive(true);
        yield return new WaitForSeconds(timer);
        //yield return new WaitForSeconds(1f);
        //yield return StartRound2();
    }

    IEnumerator StartRound2()
    {
        //UIManager.Instance.SetTextAndPlayIn("Round 2");
        //yield return new WaitForSeconds(2.5f);
        //UIManager.Instance.SetTextAndPlayIn("3");
        //yield return new WaitForSeconds(0.5f);
        //UIManager.Instance.SetTextAndPlayIn("2");
        //yield return new WaitForSeconds(0.5f);
        //UIManager.Instance.SetTextAndPlayIn("1");
        //yield return new WaitForSeconds(0.5f);
        //UIManager.Instance.SetTimer(timer + 30);
        IcecreamStickIn();
        handObj.SetActive(true);
        yield return new WaitForSeconds(timer);
    }

    IEnumerator StartRound3()
    {
        //UIManager.Instance.SetTextAndPlayIn("Round 1");
        //yield return new WaitForSeconds(2.5f);
        //UIManager.Instance.SetTextAndPlayIn("3");
        //yield return new WaitForSeconds(0.5f);
        //UIManager.Instance.SetTextAndPlayIn("2");
        //yield return new WaitForSeconds(0.5f);
        //UIManager.Instance.SetTextAndPlayIn("1");
        //yield return new WaitForSeconds(0.5f);
        //UIManager.Instance.SetTimer(timer + 60);
        IcecreamStickIn();
        handObj.SetActive(true);
        yield return new WaitForSeconds(timer);
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
