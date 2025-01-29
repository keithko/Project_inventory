using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRetreval : MonoBehaviour
{
    [SerializeField] private List<Image> imageSlots;
    [SerializeField] private Sprite newItemImage;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            if (imageSlots.Count == 0 || newItemImage == null)
            {
                Debug.LogWarning("No image slots assigned or no new image set!");
                return;
            }

            foreach (Image img in imageSlots)
            {
                if (img.sprite == null)
                {
                    img.sprite = newItemImage;
                    Debug.Log($"Image changed on {img.gameObject.name}");

                    Destroy(gameObject);
                    return;
                }
            }
        }
    }
}