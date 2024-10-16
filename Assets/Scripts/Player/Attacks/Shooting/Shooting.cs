using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Mathematics;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform gun;
    [SerializeField] private float gunDistansce = 1.5f;
    private Vector3 mousPos;

    [Header("Bullet")]
    //[SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;
    void Update()
    {
        mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousPos - transform.position;

        float angel = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        gun.position = transform.position + Quaternion.Euler(0,0,angel) * new Vector3(gunDistansce,0,0);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            Shoot(direction);

    }

    public void Shoot(Vector3 direction)
    {
        //GameObject newBullet = Instantiate(bulletPrefab, gun.position,Quaternion.identity);
        //newBullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
       GameObject bullet = ItemPool.instance.GetPooledObject();

        if (bullet != null)
        {
            bullet.transform.position = gun.position;
            bullet.SetActive(true);
        }
    }
}