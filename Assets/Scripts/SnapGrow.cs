using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapGrow : MonoBehaviour
{
    public Vector2 growthMax;
    private Vector2 growthBase;
    private bool touching;
    // Start is called before the first frame update
    void Start()
    {
        growthBase = transform.lossyScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (touching)
        {
            if (transform.localScale.x < growthMax.x)
                transform.localScale += new Vector3(growthMax.x / 10.0f, growthMax.y / 10.0f);
        }
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
