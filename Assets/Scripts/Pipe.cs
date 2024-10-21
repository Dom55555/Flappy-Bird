using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public static float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += Vector3.left * Time.deltaTime * speed;
        if (transform.position.x < -7)
        {
            transform.position = new Vector3(3,Random.Range(-2,2.7f),0);
        }
    }
}
