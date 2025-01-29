using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomLocation : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject targetPlayer;
    [SerializeField] float Radius = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))ObjectAtRandom();
    }

    void ObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitSphere * Radius;

       GameObject newEnemy = Instantiate(enemy, randomPos, Quaternion.identity);
        newEnemy.GetComponent<AIChaise>().player = targetPlayer;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}
