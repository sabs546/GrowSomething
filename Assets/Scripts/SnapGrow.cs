using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapGrow : MonoBehaviour
{
    public Vector2 growthResult;
    private Vector2 growthBase;
    public Vector2 growthSpeed;
    public bool touching;
    // Start is called before the first frame update
    void Start()
    {
        growthBase = transform.lossyScale;
        growthSpeed = growthResult / 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            if (transform.localScale.x < growthResult.x)
            {
                transform.localScale += new Vector3(growthSpeed.x, 0.0f);
                transform.position += new Vector3(growthSpeed.x / 2.0f, 0.0f);
            }

            if (transform.localScale.y < growthResult.y)
            {
                transform.localScale += new Vector3(0.0f, growthSpeed.y);
                transform.position += new Vector3(0.0f, growthSpeed.y / 2.0f);
            }
        }
        if (!touching)
        {
            if (transform.localScale.x > growthBase.x)
            {
                transform.localScale -= new Vector3(growthSpeed.x / 2.0f, 0.0f);
                transform.position -= new Vector3(growthSpeed.x / 4.0f, 0.0f);
            }

            if (transform.localScale.y > growthBase.y)
            {
                transform.localScale -= new Vector3(0.0f, growthSpeed.y / 2.0f);
                transform.position -= new Vector3(0.0f, growthSpeed.y / 4.0f);
            }
        }
    }
}
