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
    [SerializeField] GameObject scoreObj;
    [SerializeField] GameObject winnerObj;


    int timer = 50;

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
        player1TutorialObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        IcecreamStickIn();
        yield return new WaitUntil(() => icecreamStickController.numOfTap > 1);
        player1TutorialObj.SetActive(false);
        yield return new WaitForSeconds(3f);
        IcecreamStickOut();


        yield return new WaitForSeconds(0.5f);
        player2TutorialObj.SetActive(true);
        handObj.SetActive(true);
        yield return new WaitUntil(() => handHandler.numOfTap > 0);
        player2TutorialObj.SetActive(false);
        yield return new WaitForSeconds(3f);
        SetActiveHand(false);
        yield return new WaitForSeconds(1f);
        yield return StartRound1();
    }

    IEnumerator StartRound1()
    {
        scoreObj.SetActive(true);
        UIManager.Instance.SetTextAndPlayIn("Round 1");
        yield return new WaitForSeconds(2.5f);
        UIManager.Instance.SetTextAndPlayIn("3");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayIn("2");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayIn("1");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayIn(timer.ToString());
        UIManager.Instance.SetTimer(timer);
        yield return new WaitForSeconds(1f);
        IcecreamStickIn();
        SetActiveHand(true);
        yield return new WaitForSeconds(timer - 1);
        UIManager.Instance.StopTimer();
        IcecreamStickOut();
        SetActiveHand(false);
        UIManager.Instance.SetTextAndPlayIn("Time Up.!!");
        UIManager.Instance.ResetSliderAndSetScore();
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayOut();
        yield return new WaitForSeconds(1f);
        yield return StartRound2();
    }

    IEnumerator StartRound2()
    {
        UIManager.Instance.SetTextAndPlayIn("Round 2");
        yield return new WaitForSeconds(2.5f);
        UIManager.Instance.SetTextAndPlayIn("3");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayIn("2");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayIn("1");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayIn((timer).ToString());
        UIManager.Instance.SetTimer(timer);
        yield return new WaitForSeconds(1f);
        IcecreamStickIn();
        SetActiveHand(true);
        yield return new WaitForSeconds(timer - 1);
        UIManager.Instance.StopTimer();
        IcecreamStickOut();
        SetActiveHand(false);
        UIManager.Instance.SetTextAndPlayIn("Time Up.!!");
        UIManager.Instance.ResetSliderAndSetScore();
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayOut();
        yield return new WaitForSeconds(1f);
        yield return StartRound3();
    }

    IEnumerator StartRound3()
    {
        UIManager.Instance.SetTextAndPlayIn("Final Round");
        yield return new WaitForSeconds(2.5f);
        UIManager.Instance.SetTextAndPlayIn("3");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayIn("2");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayIn("1");
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayIn((timer).ToString());
        UIManager.Instance.SetTimer(timer);
        yield return new WaitForSeconds(1f);
        IcecreamStickIn();
        SetActiveHand(true);
        yield return new WaitForSeconds(timer - 1);
        UIManager.Instance.StopTimer();
        IcecreamStickOut();
        SetActiveHand(false);
        UIManager.Instance.SetTextAndPlayIn("Time Up.!!");
        UIManager.Instance.ResetSliderAndSetScore();
        yield return new WaitForSeconds(1f);
        UIManager.Instance.SetTextAndPlayOut();
        yield return new WaitForSeconds(1f);
        winnerObj.SetActive(true);
    }

    void IcecreamStickIn()
    {
        icecreamStickObj.SetActive(true);
        icecreamStickController.enabled = true;
        icecreamStickObj.transform.DOMove(new Vector2(2f, 1.24f), 0.5f).SetEase(Ease.InOutSine);
    }

    void IcecreamStickOut()
    {
        icecreamStickController.enabled = false;
        icecreamStickObj.transform.DOMoveX(-20f, 0.5f).SetEase(Ease.InOutSine).OnComplete(() => icecreamStickObj.SetActive(true));
    }

    void SetActiveHand(bool value)
    {
        if(value)
            handObj.SetActive(true);
        handHandler.HandInOut(value);
    }
}
