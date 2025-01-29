using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
     private Vector3 mousPosition;

    private void Update()
    {

        mousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = (mousPosition - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            //Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }

        else
        {
            StartCoroutine(DisableAfterDelay(30f));
        }
    }

    private IEnumerator DisableAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        gameObject.SetActive(false);
    }

}
