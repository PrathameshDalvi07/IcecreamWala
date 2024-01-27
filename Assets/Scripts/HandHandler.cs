using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;

public class HandHandler : MonoBehaviour
{
    float zPosition = 0f;
    Vector3 handInitialPosition;
    Vector3 handEndPosition;
    float handSpeed = 0.1f;
    bool canTap = true;
    [SerializeField] GameObject hitObj;
    public int numOfTap = 0;
    [SerializeField] Animator animator;

    private void Start()
    {
        handInitialPosition = new Vector3(6f, -0.5f, 0f);
        handEndPosition = new Vector3(24f, -0.5f, 0f);
        numOfTap = 0;
    }

    private void OnEnable()
    {
        TouchHandler.OnTap += OnTap;
    }

    private void OnDisable()
    {
        TouchHandler.OnTap -= OnTap;
    }

    public void OnTap(PointerEventData eventData)
    {
        ++numOfTap;
        var tempPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        tempPosition.z = zPosition;
        if (!canTap) return;
        StartCoroutine(OnTapEnum(tempPosition));
    }

    IEnumerator OnTapEnum(Vector3 tapPosition)
    {
        canTap = false;
        transform.DOMove(tapPosition, handSpeed);
        yield return new WaitForSeconds(handSpeed / 2);
        animator.Play("catch");
        yield return new WaitForSeconds(handSpeed / 2);
        transform.DOMove(handInitialPosition, handSpeed);
        yield return ToggleHitObjIEnum();
        yield return new WaitForSeconds(handSpeed + 0.3f);
        canTap = true;
    }

    IEnumerator ToggleHitObjIEnum()
    {
        hitObj.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        hitObj.SetActive(false);
    }

    public void HandInOut(bool value)
    {
        if (value)
        {
            transform.DOMove(handInitialPosition, handSpeed);
        }
        else
        {
            transform.DOMove(handEndPosition, handSpeed);
        }
    }
}
