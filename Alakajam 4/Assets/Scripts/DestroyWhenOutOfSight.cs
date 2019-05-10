using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenOutOfSight : MonoBehaviour
{
    private Camera Camera = null;

    private void Start()
    {
        Camera = Camera.main;
    }

    private void FixedUpdate()
    {
        if (transform.position.y > Camera.transform.position.y + 10)
            Destroy(gameObject);
    }
}
