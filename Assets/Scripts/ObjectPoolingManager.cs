using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{

    private static ObjectPoolingManager instance;
    public static ObjectPoolingManager Instance { get { return instance; } }

    public GameObject bulletPrefab;
    public int bulletAmount = 20;

    private List<GameObject> bullets;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

        // Preload bullets
        bullets = new List<GameObject>(bulletAmount);

        for(int i = 0; i< bulletAmount; i++)
        {
            GameObject prefabInstance = Instantiate(bulletPrefab);
            prefabInstance.transform.SetParent(transform);
            prefabInstance.SetActive(false);

            // Add instantiated bullets to list 
            bullets.Add(prefabInstance);
        }
    }

    public GameObject GetBullet()
    {
        // Use inactive bullets 
        foreach (GameObject bullet in bullets)
        {
            if (!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
            
        }
        // Add new bullets when all bullets are being used
        GameObject prefabInstance = Instantiate(bulletPrefab);
        prefabInstance.transform.SetParent(transform);
        bullets.Add(prefabInstance);

        return prefabInstance;
    }
}
