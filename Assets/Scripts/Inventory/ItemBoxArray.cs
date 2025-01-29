using UnityEngine;

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

        itemBoxPosition[0] = Vector3.zero;
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
            SpawnItemBox(1500,1150);
        }
    }
    void SpawnItemBox(int width, int height)
    {
        Debug.Log(itemBoxPosition[currentIndex]);

        GameObject newItem = Instantiate(items, itemBoxPosition[currentIndex], Quaternion.identity, GameObject.FindGameObjectWithTag("BoxUI").transform);
        itemBoxPosition[currentIndex] = newItem.transform.position;
        currentIndex++;
        Vector3 nextPosition = itemBoxPosition[currentIndex - 1];
        if (nextPosition.x >= width)
        {
            nextPosition.x = 0; // Reset to the beginning of the row
            nextPosition.y += SpawnDistentsDown; // Move down to the next row
        }
        else
        {
            nextPosition += itemBoxPositionOffsetRight; // Move to the right
        }

        if (currentIndex < maxItemboxCount)
        {
            itemBoxPosition[currentIndex] = nextPosition;
        }
    }
}
