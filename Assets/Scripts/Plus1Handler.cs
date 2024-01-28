using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Plus1Handler : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer_;

    public void SetColor(Color color_)
    {
        spriteRenderer_.color = color_;
        StartCoroutine(InOutEnum());
    }

    IEnumerator InOutEnum()
    {
        transform.DOMoveY(transform.position.y + 10f, 1f);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
