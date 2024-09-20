using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLocation : MonoBehaviour
{
    [SerializeField] GameObject item;
    [SerializeField] float Radius = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))ObjectAtRandom();
    }

    void ObjectAtRandom()
    {
        Vector3 randomPos = Random.insideUnitSphere * Radius;

        Instantiate(item, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(this.transform.position, Radius);
    }
}
