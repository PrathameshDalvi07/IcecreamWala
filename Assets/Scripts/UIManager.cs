using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] RectTransform roundRectTransform;
    [SerializeField] float offset = 5f;
    [SerializeField] float speed = 0.5f;
    float inOutOfHolderSpeed = 2f;
    [SerializeField] TextMeshProUGUI text;

    [SerializeField] TextMeshProUGUI icecreamWalaScoretext;
    [SerializeField] TextMeshProUGUI customerScoretext;
    public static UIManager Instance { get; private set; }
    IEnumerator setTimerIEnumumerator;

    void Start()
    {
        Instance = this;
        //SetRoundInOut();
    }

    public void SetTextAndPlayInOut(string txt)
    {
        text.text = txt;
        SetRoundInOut();
    }

    public void SetTextAndPlayIn(string txt)
    {
        text.text = txt;
        roundRectTransform.DOAnchorPosY(0f, speed);
    }

    public void SetTextAndPlayOut()
    {
        roundRectTransform.DOAnchorPosY(100f, 0.1f);
    }

    public void SetRoundInOut()
    {
        StartCoroutine(SetRoundInOutIEnum());
    }

    IEnumerator SetRoundInOutIEnum()
    {
        roundRectTransform.DOAnchorPosY(0f, speed);
        yield return new WaitForSeconds(inOutOfHolderSpeed);
        roundRectTransform.DOAnchorPosY(100f, speed);
    }

    public void SetTimer(int timer)
    {
        setTimerIEnumumerator = SetTimerIEnum(timer);
        StartCoroutine(setTimerIEnumumerator);
    }

    public void StopTimer()
    {
        if (setTimerIEnumumerator != null)
        {
            StopCoroutine(setTimerIEnumumerator);
            setTimerIEnumumerator = null;
        }
    }

    public void SetCustomerScore()
    {
        ++ScoreManager.custumorScore;
        customerScoretext.text = ScoreManager.custumorScore.ToString();
    }

    public void SetIcecreamWalaScore()
    {
        ++ScoreManager.icecreamWalaScore;
        customerScoretext.text = ScoreManager.icecreamWalaScore.ToString();
    }

    IEnumerator SetTimerIEnum(int timer)
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            text.text = timer.ToString();
            --timer;
        }
    }
}
