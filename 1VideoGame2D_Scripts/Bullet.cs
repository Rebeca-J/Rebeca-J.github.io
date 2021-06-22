using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Bullet : MonoBehaviour
{
    Rigidbody2D bulletRb;
    public float bulletSpeed;
    public float bulletLife;

    Player target;
    Vector2 moveDirection;


    // Start is called before the first frame update

    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        bulletRb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, bulletLife);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            Debug.Log("Hit");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }


}
