using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growth : MonoBehaviour
{
    public  Vector2 growthSpeed;
    public  Vector2 growthMax;
    private Vector2 growthBase;
    private Vector2 growthSpeedOriginal;
    private bool touching;
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
            if (transform.lossyScale.x < growthMax.x)
                transform.localScale += new Vector3(growthSpeed.x * Time.deltaTime, 0.0f, 0.0f);
            if (transform.lossyScale.y < growthMax.y)
                transform.localScale += new Vector3(0.0f, growthSpeed.y * Time.deltaTime, 0.0f);
            growthSpeed -= growthSpeed / 10.0f;

            if (growthSpeed.x < 0.1f)
                growthSpeed.x = 0.0f;
            if (growthSpeed.y < 0.1f)
                growthSpeed.y = 0.0f;
        }
        else
        {
            if (growthSpeed.x == 0.0f)
                growthSpeed.x = 0.1f;
            if (growthSpeed.y == 0.0f)
                growthSpeed.y = 0.1f;

            if (transform.lossyScale.x > growthBase.x)
                transform.localScale -= new Vector3(growthSpeed.x * Time.deltaTime, 0.0f, 0.0f);
            if (transform.lossyScale.y > growthBase.y)
                transform.localScale -= new Vector3(0.0f, growthSpeed.y * Time.deltaTime, 0.0f);
        }
        if (growthSpeed.x < growthSpeedOriginal.x)
            growthSpeed.x += growthSpeed.x / 10.0f;
        if (growthSpeed.y < growthSpeedOriginal.y)
            growthSpeed.y += growthSpeed.y / 10.0f;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Growth>() == null)
            touching = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touching = false;
    }
}
