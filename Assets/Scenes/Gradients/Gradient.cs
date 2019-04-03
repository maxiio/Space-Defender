using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gradient : MonoBehaviour
{
    public SpriteRenderer downColor;
    public SpriteRenderer upColor;

    //Debug
    [Range(0,1)]
    public float testNewHueUP;


    private void Start()
    {
        upColor = this.gameObject.GetComponent<SpriteRenderer>();
        downColor = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Color Changed");
            downColor.color = new Color(upColor.color.r, upColor.color.g, upColor.color.b);
            upColor.color = HSBColor.ToColor(new HSBColor(testNewHueUP, 0.55f, 0.90f));
            
        }
    }
}
