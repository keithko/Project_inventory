
using UnityEngine;

public class Draggable : MonoBehaviour
{
    bool isDrag = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isDrag = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDrag = false;
        }


        if (isDrag)
        {

            Vector2 mousePosition = Input.mousePosition;
            Vector3 mPos = new Vector3(mousePosition.x,mousePosition.y,1f);
            
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mPos);
            Debug.Log(worldPosition + " : " + mousePosition);
            this.transform.localPosition = new Vector3(worldPosition.x, worldPosition.y,0f);
            
        }
    }
}
