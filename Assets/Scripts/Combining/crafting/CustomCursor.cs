using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        transform.position = mousePos;
        Cursor.visible = false;
        transform.position = Input.mousePosition;
    }
}
