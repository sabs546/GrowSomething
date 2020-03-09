using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Collider col;
    public GameObject[] walls;
    public float gravity;
    public Vector2 currentSpeed;
    private float defaultGravity;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        walls = GameObject.FindGameObjectsWithTag("Walls");
        defaultGravity = gravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentSpeed.y < 0.0f && gravity < currentSpeed.y * 1.1f)
            gravity *= 1.1f;
        else if (Input.GetKey(KeyCode.W) && gravity > defaultGravity * 0.4f)
            gravity *= 0.9f;

        if (currentSpeed.y > -gravity)
            currentSpeed.y -= gravity * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            currentSpeed.x -= 10.0f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentSpeed.x += 10.0f * Time.deltaTime;
        }

        Vector2 oldPos = transform.position;
        transform.Translate(currentSpeed * Time.deltaTime);

        for (int i = 0; i < walls.Length; i++)
        {
            switch (col.CheckCollision(walls[i].transform.position, walls[i].transform.lossyScale / 2, oldPos))
            {
                case 0:
                    WallHit(i, false);
                    break;
                case 1: // Floor
                    if (currentSpeed.y < 0.0f)
                        currentSpeed.y = 0.0f;
                    Punch(i, 1);
                    WallHit(i, true);
                    Debug.Log("Floor");
                    break;
                case 2: // Left
                    Punch(i, 2);
                    WallHit(i, true);
                    Debug.Log("Left");
                    break;
                case 3: // Right
                    Punch(i, 3);
                    WallHit(i, true);
                    Debug.Log("Right");
                    break;
                case 4: // Ceiling
                    Punch(i, 4);
                    WallHit(i, true);
                    Debug.Log("Ceiling");
                    break;
            }
        }
    }

    private void Punch(int index, int direction)
    {
        Vector2 speed;
        if (walls[index].GetComponent<SnapGrow>() != null)
            speed = walls[index].GetComponent<SnapGrow>().growthSpeed * 10;
        else
            return;

        switch (direction)
        {
            case 1:
                currentSpeed.y += speed.y;
                break;
            case 2:
                currentSpeed.x -= speed.x;
                break;
            case 3:
                currentSpeed.x += speed.x;
                break;
            case 4:
                currentSpeed.y -= speed.y;
                break;
        }
    }

    private void WallHit(int index, bool value)
    {
        if (walls[index].GetComponent<Growth>() != null)
            walls[index].GetComponent<Growth>().touching = value;
        else if (walls[index].GetComponent<SnapGrow>() != null)
            walls[index].GetComponent<SnapGrow>().touching = value;
    }
}
