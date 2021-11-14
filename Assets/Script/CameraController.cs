using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Enemy;
    public Vector3 _offset;

    void Start()
    {
        transform.position = Enemy.position + _offset;
    }

    void LateUpdate()
    {
        transform.position = Enemy.position + _offset;
    }
}
