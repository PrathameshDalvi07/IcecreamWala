using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject roundObj;
    [SerializeField] float offset = 5f;
    [SerializeField] float speed = 0.5f;
    Vector2 roundPosition;

    void Start()
    {
        roundPosition = roundObj.transform.localPosition;
        SetRoundInOut();
    }

    public void SetRoundInOut()
    {
        //StartCoroutine(SetRoundInOutIEnum());
    }

    IEnumerator SetRoundInOutIEnum()
    {
        roundObj.transform.DOLocalMoveY(roundPosition.x + offset, speed);
        yield return new WaitForSeconds(speed);
        //roundObj.transform.DOLocalMoveY(roundPosition.x - offset, speed);

    }
}
