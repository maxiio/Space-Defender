using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constant_rotator : MonoBehaviour
{
    private Transform tr;
    private float speed;
    private float redYOffset;
    private float redXOffset;
    private float blueYOffset;
    private float blueXOffset;
    private SpriteRenderer shader;

    public bool rotate = true;

    private void Start()
    {
        shader = GetComponent<SpriteRenderer>();

        tr = GetComponent<Transform>();
        speed = Random.Range(0.1f, 1f);
        
        redYOffset = Random.Range(-0.02f, 0.02f);
        redXOffset = Random.Range(-0.02f, 0.02f);
        blueXOffset = Random.Range(-0.02f, 0.02f);
        blueYOffset = Random.Range(-0.02f, 0.02f);

        shader.material.SetFloat("_RedOffsetX", redXOffset);
        shader.material.SetFloat("_RedOffsetY", redYOffset);
        shader.material.SetFloat("_BlueOffsetX", blueXOffset);
        shader.material.SetFloat("_BlueOffsetY", blueYOffset);

    }

    private void Update()
    {
        if (rotate)
        {
            tr.Rotate(new Vector3(0, 0, speed));
            this.transform.localScale = tr.localScale;
        }
    }
}
