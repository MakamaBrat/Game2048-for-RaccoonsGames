using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRotation : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public float radius = 5f;
    private Vector3 centerPosition;

    void Start()
    {
        centerPosition = transform.position;
    }

    void Update()
    {
        float angle = Time.time * rotationSpeed;
        Vector3 offset = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle)) * radius;
        transform.position = centerPosition + offset;
        transform.LookAt(centerPosition);
    }
}
