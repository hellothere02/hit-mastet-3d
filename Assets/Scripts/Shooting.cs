using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPref;
    [SerializeField] private GameObject gunTrans;
    [SerializeField] private int bulletsCount;

    private GameObject[] bullets;
    private int shots = 0;

    private void Start()
    {
        bullets = new GameObject[bulletsCount];
        bullets = CreatBullets();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Shoot(out shots);
            }
        }
    }

    public void Shoot(out int shot)
    {
        shot = shots;
        if (shots >= bulletsCount)
        {
            bullets = CreatBullets();
            shots = 0;
        }
        bullets[shots].transform.parent = null;
        bullets[shot].SetActive(true);
        shot++;
    }

    private GameObject[] CreatBullets()
    {
        GameObject[] bullet = new GameObject[bulletsCount];
        for (int i = 0; i < bulletsCount; i++)
        {
            GameObject currentBullet = Instantiate(bulletPref, gunTrans.transform.position, Quaternion.identity, gunTrans.transform);
            currentBullet.SetActive(false);
            bullet[i] = currentBullet;
        }
        return bullet;
    }
}
