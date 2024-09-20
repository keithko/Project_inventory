using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class ItemBoxArray : MonoBehaviour
{ 
    [SerializeField] GameObject items;
    [SerializeField] GameObject[] spawnItemBox;

    [SerializeField] int itemBoxCount;
    int maxItemboxCount = 30;
    private int currentIndex = 0;

    private Vector3[] itemBoxPosition;
    private Vector3 itemBoxPositionOffsetRight = new Vector3(250,0,0);
    private Vector3 itemBoxPositionOffsetLeft = new Vector3(0,-250,0);

    GameObject DisposableItems;

    [SerializeField] int SpawnDistentsRighgt = 250;
    [SerializeField] int SpawnDistentsDown = -250;
    // Start is called before the first frame update
    void Start()
    { 
        itemBoxPosition = new Vector3[maxItemboxCount];
        spawnItemBox = new GameObject[maxItemboxCount];
    }

    // Update is called once per frame
    void Update()
    {
        ItemBox();
    }


    void ItemBox()
    {
        if (Input.GetKeyDown(KeyCode.I) && currentIndex < maxItemboxCount)
            {
            SpawnItemBox();
        }
    }
    void SpawnItemBox()
    {
        GameObject newItem = Instantiate(items, itemBoxPosition[currentIndex], Quaternion.identity);
        itemBoxPosition[currentIndex] = newItem.transform.position;
        currentIndex++;
        if (itemBoxPosition[currentIndex].x >= 1500)
        {
            itemBoxPosition[currentIndex] += new Vector3(SpawnDistentsRighgt, itemBoxPosition[currentIndex].y);
            itemBoxPosition[currentIndex] += new Vector3(itemBoxPosition[currentIndex].x, SpawnDistentsDown);
        }
        else
        {
            itemBoxPosition[currentIndex] += new Vector3 (itemBoxPosition[currentIndex].x + itemBoxPositionOffsetRight.x,0 ,0);
            Debug.Log(itemBoxPosition[currentIndex]);
        }

        if (itemBoxPosition[currentIndex].y >= 1150)
        {
            itemBoxPosition[currentIndex] = itemBoxPosition[currentIndex] + itemBoxPositionOffsetLeft;
        }

        
    }
}
