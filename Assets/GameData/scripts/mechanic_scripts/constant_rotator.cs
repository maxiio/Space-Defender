using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constant_rotator : MonoBehaviour
{
    private Transform tr;
    private float speed;

    private void Start()
    {
        tr = GetComponent<Transform>();
        speed = Random.Range(0.1f, 1f);
    }

    private void Update()
    {
        tr.Rotate(new Vector3(0,0,speed));
        this.transform.localScale = tr.localScale;
    }
}
