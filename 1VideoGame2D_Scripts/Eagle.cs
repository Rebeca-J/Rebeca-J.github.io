using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public GameObject eagle;

    public float fireRate;
    public float nextFire;
     // Start is called before the first frame update
    void Start()
    {
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("eagle") == null)
        {
            Instantiate(eagle, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
      
    }

    


}
