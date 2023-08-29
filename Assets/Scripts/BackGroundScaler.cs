using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer rb = GetComponent<SpriteRenderer>();
        Vector3 temScale = transform.localScale;

        float height = rb.bounds.size.y;
        float width = rb.bounds.size.x;

        float worldheight = Camera.main.orthographicSize*2f;
        float worldlwidth = worldheight * Screen.width/Screen.height;

        temScale.y = worldheight / height;
        temScale.x = worldlwidth/width;

        transform.localScale = temScale;

    }

}
