using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageMovement : MonoBehaviour
{
    public float speed = 3f;

    [SerializeField] private float max_x;
    [SerializeField] private float min_x;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > min_x)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector3(max_x,transform.position.y,transform.position.z);
        }
    }
}
