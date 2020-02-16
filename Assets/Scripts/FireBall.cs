using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float speed;
    Vector3 direction;

    void Start()
    {
        //speed = 10f;
        // direction = transform.parent.GetComponent<Blob>().getMovingDirection();
        // Debug.Log(direction);
        direction = Vector3.forward;
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}

