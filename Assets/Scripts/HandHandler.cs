using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System.Collections;

public class HandHandler : MonoBehaviour
{
    float zPosition = 0f;
    Vector3 initialPosition = new Vector3(5f, -10f, 0f);
    float handSpeed = 0.5f;
    bool canTap = true;
    [SerializeField] GameObject hitObj;
    public int numOfTap = 0;

    private void Start()
    {
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
        yield return new WaitForSeconds(handSpeed);
        transform.DOMove(initialPosition, handSpeed);
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
}
