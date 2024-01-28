using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] RectTransform roundRectTransform;
    [SerializeField] float offset = 5f;
    [SerializeField] float speed = 0.5f;
    float inOutOfHolderSpeed = 2f;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Slider slider_;

    [SerializeField] TextMeshProUGUI icecreamWalaChartScoretext;
    [SerializeField] TextMeshProUGUI customerChartScoretext;
    public static UIManager Instance { get; private set; }
    IEnumerator setTimerIEnumumerator;
    [SerializeField] SpriteRenderer winnerSR;
    [SerializeField] Sprite customerSprite;
    [SerializeField] Sprite icecreamWalaSprite;

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
        roundRectTransform.DOAnchorPosY(130f, 0.1f);
    }

    public void SetRoundInOut()
    {
        StartCoroutine(SetRoundInOutIEnum());
    }

    IEnumerator SetRoundInOutIEnum()
    {
        roundRectTransform.DOAnchorPosY(0f, speed);
        yield return new WaitForSeconds(inOutOfHolderSpeed);
        roundRectTransform.DOAnchorPosY(130f, speed);
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
        slider_.value -= 0.01f;
    }

    public void SetIcecreamWalaScore()
    {
        ++ScoreManager.icecreamWalaScore;
        slider_.value += 0.01f;
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

    public void ResetSliderAndSetScore()
    {
        if (slider_.value > 0.5f)
        {
            ++ScoreManager.icecreamWalaChartScore;
        }
        else
        {
            ++ScoreManager.custumorChartScore;
        }

        if (ScoreManager.icecreamWalaChartScore > ScoreManager.custumorChartScore)
        {
            winnerSR.sprite = icecreamWalaSprite;
        }
        else
        {
            winnerSR.sprite = customerSprite;
        }

        icecreamWalaChartScoretext.text = ScoreManager.icecreamWalaChartScore.ToString();
        customerChartScoretext.text = ScoreManager.custumorChartScore.ToString();
        slider_.value = 0.5f;
    }
}
