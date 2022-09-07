using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveSpeed = Random.Range(4f, 10f);
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        if (transform.position.x < -12f)
        {
            Destroy(gameObject);
            //GameManager.instance.IncrementScore();
        }
    }
}
