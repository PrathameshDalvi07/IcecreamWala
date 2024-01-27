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
    Vector2 icecreamClampY = new Vector2(-2.86f, 1.24f);
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
            tempPosition = Mathf.Clamp(tempPosition, icecreamClampX.x, icecreamClampX.y);
            floater.PauseFloating();
            icecreamStickTransform.DOMoveX(tempPosition, speed).OnComplete(OnMovementCompleted);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            tempPosition = icecreamStickTransform.position.x - pushLength;
            tempPosition = Mathf.Clamp(tempPosition, icecreamClampX.x, icecreamClampX.y);
            floater.PauseFloating();
            icecreamStickTransform.DOMoveX(tempPosition, speed).OnComplete(OnMovementCompleted);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            tempPosition = icecreamStickTransform.position.y + pushLength;
            tempPosition = Mathf.Clamp(tempPosition, icecreamClampY.x, icecreamClampY.y);
            floater.PauseFloating();
            icecreamStickTransform.DOMoveY(tempPosition, speed).OnComplete(OnMovementCompleted);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            tempPosition = icecreamStickTransform.position.y - pushLength;
            tempPosition = Mathf.Clamp(tempPosition, icecreamClampY.x, icecreamClampY.y);
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
