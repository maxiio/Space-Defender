using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stars_moving : MonoBehaviour
{
    public float paralax_brakes;
    public singletone_script singletone;
    private MeshRenderer mr;
    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (!singletone.disable_control || singletone.main_menu_canvas.enabled == true || singletone.level_complete_canvas.enabled == true)
        {
            Material mat = mr.material;
            Vector2 offset = mat.mainTextureOffset;
            offset.y += Time.deltaTime / paralax_brakes;
            mat.mainTextureOffset = offset;
        }
    }
}
