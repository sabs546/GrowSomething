using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapGrow : MonoBehaviour
{
    public Vector2 growthMax;
    private Vector2 growthBase;
    public Vector2 growthSpeed;
    public bool touching;
    // Start is called before the first frame update
    void Start()
    {
        growthBase = transform.lossyScale;
        growthSpeed = growthMax / 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            if (transform.localScale.x < growthMax.x)
            {
                transform.localScale += new Vector3(growthSpeed.x, 0.0f);
                transform.position += new Vector3(growthSpeed.x / 2.0f, 0.0f);
            }

            if (transform.localScale.y < growthMax.y)
            {
                transform.localScale += new Vector3(0.0f, growthSpeed.y);
                transform.position += new Vector3(0.0f, growthSpeed.y / 2.0f);
            }
        }
        if (!touching)
        {
            if (transform.localScale.x > growthBase.x)
            {
                transform.localScale -= new Vector3(growthBase.x / 20.0f, 0.0f);
                transform.position -= new Vector3(growthBase.x / 40.0f, 0.0f);
            }

            if (transform.localScale.y > growthBase.y)
            {
                transform.localScale -= new Vector3(0.0f, growthBase.y / 20.0f);
                transform.position -= new Vector3(0.0f, growthBase.y / 40.0f);
            }
        }
    }
}
