using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public GameObject type;
    private Transform[] parallax;
    private new GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        parallax = type.GetComponentsInChildren<Transform>();
        camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        int j = parallax.Length;
        for (int i = 1; i < parallax.Length; i++)
        {
            parallax[i].transform.position = new Vector3(transform.position.x - (camera.transform.position.x / (j * 5)),
                                                         transform.position.y - (camera.transform.position.y / (j * 10)));
            j--;
        }
    }
}
