using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Positioner;

    private float fireRate = 0.15f;
    private float nextFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bulletObject = ObjectPoolingManager.Instance.GetBullet();
            var Pos = Positioner.transform.position + Positioner.transform.forward;
            Pos.y = 1.1f;
            bulletObject.transform.position = Pos;
            Debug.Log(bulletObject.transform.position.y);
            bulletObject.transform.forward = Positioner.transform.forward;
        }
        if(Input.GetMouseButton(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate; 
            GameObject bulletObject = ObjectPoolingManager.Instance.GetBullet();
            var Pos = Positioner.transform.position + Positioner.transform.forward;
            Pos.y = 1.1f;
            bulletObject.transform.position = Pos;
            bulletObject.transform.forward = Positioner.transform.forward;
        }
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
