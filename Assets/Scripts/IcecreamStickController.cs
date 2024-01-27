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
    Vector2 clampX = new Vector2(-7f, 7f);
    Vector2 clampY = new Vector2(-3f, 3.5f);
    Floater floater;
    public int numOfTap = 0;

    void Start()
    {
        numOfTap = 0;
        floater = GetComponent<Floater>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            tempPosition = icecreamStickTransform.position.x + pushLength;
            tempPosition = Mathf.Clamp(tempPosition, clampX.x, clampX.y);
            floater.PauseFloating();
            icecreamStickTransform.DOMoveX(tempPosition, speed).OnComplete(OnMovementCompleted);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tempPosition = icecreamStickTransform.position.x - pushLength;
            tempPosition = Mathf.Clamp(tempPosition, clampX.x, clampX.y);
            floater.PauseFloating();
            icecreamStickTransform.DOMoveX(tempPosition, speed).OnComplete(OnMovementCompleted);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tempPosition = icecreamStickTransform.position.y + pushLength;
            tempPosition = Mathf.Clamp(tempPosition, clampY.x, clampY.y);
            floater.PauseFloating();
            icecreamStickTransform.DOMoveY(tempPosition, speed).OnComplete(OnMovementCompleted);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tempPosition = icecreamStickTransform.position.y - pushLength;
            tempPosition = Mathf.Clamp(tempPosition, clampY.x, clampY.y);
            floater.PauseFloating();
            icecreamStickTransform.DOMoveY(tempPosition, speed).OnComplete(OnMovementCompleted);
        }
    }

    void OnMovementCompleted()
    {
        ++numOfTap;
        floater.ResumeFloating();
    }
}
