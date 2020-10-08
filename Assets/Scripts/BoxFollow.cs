using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxFollow : MonoBehaviour
{
    [HideInInspector]
    public Vector3 targetpos;

    private float SmoothMove = 1f;

    private void Start()
    {
        targetpos = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetpos, SmoothMove * Time.deltaTime);
    }
}
