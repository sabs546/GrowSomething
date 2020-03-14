using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapGrow : MonoBehaviour
{
    public  bool touching;
    public  bool grow;
    public  bool xReversed;
    public  bool yReversed;
    public  Vector2 growthResult;
    public  Vector2 growthSpeed;
    private Vector2 growthBase;
    public bool ready;
    // Start is called before the first frame update
    void Start()
    {
        growthBase = transform.lossyScale;
        growthSpeed = growthResult / 10.0f;
        growthSpeed.x = Mathf.Abs(growthSpeed.x);
        growthSpeed.y = Mathf.Abs(growthSpeed.y);
        grow = false;
        ready = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (touching && ready)
            grow = true;
        if (grow)
        {
            if (transform.localScale.x < growthResult.x)
            {
                transform.localScale += new Vector3(growthSpeed.x, 0.0f);
                if (!xReversed)
                    transform.position += new Vector3(growthSpeed.x / 2.0f, 0.0f);
                else
                    transform.position -= new Vector3(growthSpeed.x / 2.0f, 0.0f);
            }

            if (transform.localScale.y < growthResult.y)
            {
                transform.localScale += new Vector3(0.0f, growthSpeed.y);
                if (!yReversed)
                    transform.position += new Vector3(0.0f, growthSpeed.y / 2.0f);
                else
                    transform.position -= new Vector3(0.0f, growthSpeed.y / 2.0f);
            }

            if (transform.localScale.x >= growthResult.x && transform.localScale.y >= growthResult.y)
                grow = false;
        }
        else
        {
            ready = false;
            if (transform.localScale.x > growthBase.x)
            {
                transform.localScale -= new Vector3(growthSpeed.x / 2.0f, 0.0f);
                if (!xReversed)
                    transform.position -= new Vector3(growthSpeed.x / 4.0f, 0.0f);
                else
                    transform.position += new Vector3(growthSpeed.x / 4.0f, 0.0f);
            }

            if (transform.localScale.y > growthBase.y)
            {
                transform.localScale -= new Vector3(0.0f, growthSpeed.y / 2.0f);
                if (!yReversed)
                    transform.position -= new Vector3(0.0f, growthSpeed.y / 4.0f);
                else
                    transform.position += new Vector3(0.0f, growthSpeed.y / 4.0f);
            }

            if (transform.localScale.x <= growthBase.x && transform.localScale.y <= growthBase.y)
                ready = true;
        }
    }
}
