using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform target;
    public float attackOn;
    public float fireRate;
    public float nextFire;
    public float MinpositionHeroX;
    public float MaxpositionHeroX;

    // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTimeToFire();

    }

    void CheckTimeToFire()
    {

        if (Time.time > nextFire && (Vector3.Distance(target.position, transform.position) <= attackOn) && (target.position.x >= MinpositionHeroX) && (target.position.x <= MaxpositionHeroX))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            nextFire = Time.time + fireRate;

        }


    }



}
