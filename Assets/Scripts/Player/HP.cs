using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    [SerializeField] private int maxHp;
    [SerializeField]private float currentHp;
    [SerializeField] public int bDamage;
    [SerializeField] int enemyDamage;
    private bool isColliding = false;
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    // Start is called before the first frame update
    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        if (isColliding == true)
        {
            Damage();
        }
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHp -= bDamage;
            return;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isColliding = false;
    }

    void Damage()
    {
        currentHp -= enemyDamage * Time.deltaTime;
        return;
    }

    void Die()
    {
        if (currentHp<= 0)
        {
            if (gameObject.tag == ("Player"))
            {
                gameObject.SetActive(false);
            }
            else 
            {
                Destroy(gameObject);
            }
        }
    }
}