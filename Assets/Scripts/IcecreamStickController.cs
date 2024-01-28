using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class IcecreamStickController : MonoBehaviour
{
    [SerializeField] private Transform icecreamStickTransform;

    int count = 0;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float pushLength = 2.5f;
    //bool isLeftRight = false;
    bool canTap = true;
    float tempPosition;
    Vector2 icecreamClampX = new Vector2(-5.5f, 3.2f);
    Vector2 icecreamClampY = new Vector2(-2.86f, 2.61f);
    Floater floater;
    public int numOfTap = 0;
    [SerializeField] GameObject hitObj;
    bool justOnce;
    [SerializeField] GameObject plus1Prefab;

    void Start()
    {
        numOfTap = 0;
        floater = GetComponent<Floater>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            tempPosition = transform.position.x + pushLength;
            tempPosition = Mathf.Clamp(tempPosition, icecreamClampX.x, icecreamClampX.y);
            //floater.PauseFloating();
            transform.DOMoveX(tempPosition, speed).OnComplete(OnMovementCompleted);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            tempPosition = transform.position.x - pushLength;
            tempPosition = Mathf.Clamp(tempPosition, icecreamClampX.x, icecreamClampX.y);
            //floater.PauseFloating();
            transform.DOMoveX(tempPosition, speed).OnComplete(OnMovementCompleted);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            tempPosition = transform.position.y + pushLength;
            tempPosition = Mathf.Clamp(tempPosition, icecreamClampY.x, icecreamClampY.y);
            //floater.PauseFloating();
            transform.DOMoveY(tempPosition, speed).OnComplete(OnMovementCompleted);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            tempPosition = transform.position.y - pushLength;
            tempPosition = Mathf.Clamp(tempPosition, icecreamClampY.x, icecreamClampY.y);
            //floater.PauseFloating();
            transform.DOMoveY(tempPosition, speed).OnComplete(OnMovementCompleted);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.DOScaleY(-1f, 0.3f);
            if (transform.localScale.y < -0.5f && !justOnce)
            {
                OnHitObj();
                justOnce = true;
            }
        }
        else
        {
            justOnce = false;
            transform.DOScaleY(1f, 0.3f);
        }
    }

    void OnHitObj()
    {
        StartCoroutine(ToggleHitObjIEnum());
    }

    IEnumerator ToggleHitObjIEnum()
    {
        hitObj.SetActive(true);
        yield return new WaitForSeconds(0.08f);
        hitObj.SetActive(false);
    }


    void OnMovementCompleted()
    {
        ++numOfTap;
        //floater.ResumeFloating();
    }

    public void AddPlus1()
    {
        Instantiate(plus1Prefab, hitObj.transform.position, Quaternion.identity).GetComponent<Plus1Handler>().SetColor(Color.red);
    }
}
