using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collider : MonoBehaviour
{
    public int CheckCollision(Vector2 pos2, Vector2 scale2, Vector2 oldPos)
    {
        if (transform.position.x + transform.lossyScale.x / 2 > pos2.x - scale2.x && transform.position.x - transform.lossyScale.x / 2 < pos2.x + scale2.x &&
            transform.position.y + transform.lossyScale.y / 2 > pos2.y - scale2.y && transform.position.y - transform.lossyScale.y / 2 < pos2.y + scale2.y)
        {
            if (oldPos.y > pos2.y + scale2.y)
            { // Ground
                transform.position = new Vector3(transform.position.x, pos2.y + (scale2.y + (transform.lossyScale.y / 2)), 0.0f);
                return 1;
            }
            else if (oldPos.y < pos2.y - scale2.y)
            { // Ceiling
                transform.position = new Vector3(transform.position.x, pos2.y - (scale2.y + (transform.lossyScale.y / 2)), 0.0f);
                return 4;
            }

            if (oldPos.x > pos2.x + scale2.x)
            { // Left wall
                transform.position = new Vector3(pos2.x + (scale2.x + (transform.lossyScale.y / 2)), transform.position.y / 2, 0.0f);
                return 2;
            }
            else if (oldPos.x < pos2.x - scale2.x)
            { // Right wall
                transform.position = new Vector3(pos2.x - (scale2.x + (transform.lossyScale.y / 2)), transform.position.y / 2, 0.0f);
                return 3;
            }
        }
        return 0;
    }
}
