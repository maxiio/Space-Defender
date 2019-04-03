using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stars_moving : MonoBehaviour
{
    public float paralax_brakes;
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.material;
        Vector2 offset = mat.mainTextureOffset;
        offset.y += Time.deltaTime/ paralax_brakes;
        mat.mainTextureOffset = offset;
    }
}
