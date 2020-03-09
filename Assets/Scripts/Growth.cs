using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : MonoBehaviour
{
    public  Vector2 growthSpeed;
    public  Vector2 growthResult;
    private Vector2 growthBase;
    private Vector2 growthSpeedOriginal;
    public bool touching;
    // Start is called before the first frame update
    void Start()
    {
        growthBase = transform.lossyScale;
        growthSpeedOriginal = growthSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            if ((transform.lossyScale.x < growthResult.x && growthSpeed.x > 0) || (growthResult.x < transform.lossyScale.x && growthSpeed.x < 0))
            {
                transform.localScale += new Vector3(growthSpeed.x * Time.deltaTime, 0.0f, 0.0f);
                transform.position += new Vector3((growthSpeed.x / 2) * Time.deltaTime, 0.0f, 0.0f);
            }

            if ((transform.lossyScale.y < growthResult.y && growthSpeed.y > 0) || (growthResult.y < transform.lossyScale.y && growthSpeed.y < 0))
            {
                transform.localScale += new Vector3(0.0f, growthSpeed.y * Time.deltaTime, 0.0f);
                transform.position += new Vector3(0.0f, (growthSpeed.y / 2) * Time.deltaTime, 0.0f);
            }

            growthSpeed -= growthSpeed / 10.0f;

            if (Mathf.Abs(growthSpeed.x) < 0.1f)
                growthSpeed.x = 0.0f;
            if (Mathf.Abs(growthSpeed.y) < 0.1f)
                growthSpeed.y = 0.0f;
        }
        else
        {
            if ((transform.lossyScale.x > growthBase.x && growthSpeed.x < 0) || (growthBase.x > transform.lossyScale.x && growthSpeed.x > 0))
            {
                transform.localScale -= new Vector3(growthSpeed.x * Time.deltaTime, 0.0f, 0.0f);
                transform.position -= new Vector3((growthSpeed.x / 2)* Time.deltaTime, 0.0f, 0.0f);
            }

            if ((transform.lossyScale.y > growthBase.y && growthSpeed.y < 0) || (growthBase.y > transform.lossyScale.y && growthSpeed.y > 0))
            {
                transform.localScale -= new Vector3(0.0f, growthSpeed.y * Time.deltaTime, 0.0f);
                transform.position -= new Vector3(0.0f, (growthSpeed.y / 2) * Time.deltaTime, 0.0f);
            }
        }
        if (Mathf.Abs(growthSpeed.x) < Mathf.Abs(growthSpeedOriginal.x))
            growthSpeed.x += growthSpeed.x / 10.0f;
        if (Mathf.Abs(growthSpeed.y) < Mathf.Abs(growthSpeedOriginal.y))
            growthSpeed.y += growthSpeed.y / 10.0f;
    }
}
