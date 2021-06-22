using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : MonoBehaviour
{
    Rigidbody2D _rb;
    public Transform[] points;
    int _index;
    public float speed;
    public float range;
    Vector2 movement;
    Animator anim;

    private enum State { walk };

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {

    }

    void Update()
    {
        Vector2 dir = (points[_index].position - transform.position);
        Vector2 dirN = dir.normalized;

        if (dir.magnitude < range)
        {
            if (_index == points.Length - 1)
            {
                _index = 0;
            }
            else
            {
                _index++;
            }

        }

        _rb.velocity = dirN * speed;

        if (points[_index].position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }


        else
        {
            transform.localScale = new Vector2(1, 1);
        }

    }


}
