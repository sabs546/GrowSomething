using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapGrow : MonoBehaviour
{
    public  bool touching;
    public  bool xReversed;
    public  bool yReversed;
    public  Vector2 growthResult;
    public  Vector2 growthSpeed;
    private Vector2 growthBase;
    // Start is called before the first frame update
    void Start()
    {
        growthBase = transform.lossyScale;
        growthSpeed = growthResult / 10.0f;
        growthSpeed.x = Mathf.Abs(growthSpeed.x);
        growthSpeed.y = Mathf.Abs(growthSpeed.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
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
        }
        if (!touching)
        {
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
        }
    }
}
