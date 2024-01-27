using UnityEngine;
using DG.Tweening;
using System.Collections;

public class Floater : MonoBehaviour
{
    [SerializeField] float floatingHeight = 0.15f;
    [SerializeField] float floatingDuration = 3.5f;

    private Tween floatingTween;

    private void Start()
    {
        FloatUp();
    }

    public void FloatUp()
    {
        floatingTween = transform.DOMoveY(transform.position.y + floatingHeight, floatingDuration)
            .SetEase(Ease.InOutQuad) // Set the ease type for a smooth motion
            .SetLoops(-1, LoopType.Yoyo); // Set the loop type to Yoyo for continuous up and down motion
    }

    public void FloatUp(float floatingHeight_, float floatingDuration_)
    {
        floatingTween = transform.DOMoveY(transform.position.y + floatingHeight_, floatingDuration_)
            .SetEase(Ease.InOutQuad)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void PauseFloating()
    {
        if (floatingTween != null)
        {
            floatingTween.Pause();
        }
    }

    public void ResumeFloating()
    {
        if (floatingTween != null)
        {
            floatingTween.Play();
        }
    }
}