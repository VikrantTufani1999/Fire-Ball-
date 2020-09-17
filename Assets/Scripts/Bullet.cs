using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeDuration = 2f;

    private float lifeTimer;

    [SerializeField]
    private GameObject player;

    GamaManager link;

    void OnEnable()
    {
        lifeTimer = lifeDuration;
    }

    private void Start()
    {
        link = FindObjectOfType<GamaManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // make the bullet move
        transform.position += transform.forward * speed * Time.deltaTime;

        // check if bullet should be destroyed
        lifeTimer -= Time.deltaTime;
        if(lifeTimer<=0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Box")
        {
            Destroy(other.gameObject, 0.1f);
            this.gameObject.SetActive(false);
        }

        if(other.gameObject.tag == "Obstacle")
        {
            this.gameObject.SetActive(false);
            link.ActivateLosePanel();
            Debug.Log("You Lose!");
        }

        if(other.gameObject.tag == "WinBox")
        {
            link.ActivateWinPanel();
            Debug.Log("You Win!");
        }
    }
}
