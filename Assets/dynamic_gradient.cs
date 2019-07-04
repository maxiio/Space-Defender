using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dynamic_gradient : MonoBehaviour
{
    private SpriteRenderer background;
    private SpriteRenderer gradient;

    public bool isDynamic;
    void Start()
    {
        background = this.transform.GetChild(0).GetComponent<SpriteRenderer>();
        gradient = GetComponent<SpriteRenderer>();

        background.color = HSBColor.ToColor(new HSBColor(Random.Range(0f,100f)/100,HSBColor.FromColor(background.color).s, HSBColor.FromColor(background.color).b));
        gradient.color = HSBColor.ToColor(new HSBColor(Random.Range(0f, 100f) / 100, HSBColor.FromColor(gradient.color).s, HSBColor.FromColor(gradient.color).b));

        Debug.Log(Random.Range(0f, 255f) / 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDynamic)
        {
            //background.color += HSBColor.ToColor(new HSBColor(0.01f, 0, 0));
            // gradient.color -= HSBColor.ToColor(new HSBColor(0.01f, 0, 0));
            background.color = HSBColor.ToColor(HSBColor.Lerp(HSBColor.FromColor(background.color), 
                                                new HSBColor(HSBColor.FromColor(background.color).h+0.1f, HSBColor.FromColor(background.color).s, HSBColor.FromColor(background.color).b),
                                                 0.1f/20));

            gradient.color = HSBColor.ToColor(HSBColor.Lerp(HSBColor.FromColor(gradient.color),
                                                new HSBColor(HSBColor.FromColor(gradient.color).h - 0.1f, HSBColor.FromColor(gradient.color).s, HSBColor.FromColor(gradient.color).b),
                                                 0.1f/20));
        }
    }
}
