using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler : MonoBehaviour
{
    Collider2D collider_;
    ContactFilter2D contactFilter_;
    List<Collider2D> results;

    private void Initialize()
    {
        if (collider_ == null)
            collider_ = GetComponent<Collider2D>();
        contactFilter_ = new ContactFilter2D();
        if (results == null)
            results = new List<Collider2D>();
    }

    private void OnEnable()
    {
        IsHitting();
    }

    public void IsHitting()
    {
        Initialize();
        int n = Physics2D.OverlapCollider(collider_, contactFilter_, results);
        if (n > 1)
        {
            Debug.Log("Win!! ");
        }
    }
}
