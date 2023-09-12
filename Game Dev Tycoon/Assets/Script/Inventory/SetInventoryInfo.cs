
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetInventoryInfo 
{
   public void SetInventory(RectTransform inventoryTemplate, Furniture furniture)
   {
      inventoryTemplate.Find("Name").GetComponent<TextMeshProUGUI>().text = furniture.FurnitureName;
      inventoryTemplate.Find("Image").GetComponent<Image>().sprite = furniture.FurnitureImage;
      Debug.Log("Okay man its working, now you have to code this future!");
      inventoryTemplate.Find("Button").GetComponent<Button>().onClick.AddListener(() => Debug.Log("Okay man its working, now you have to code this future!"));
   }
}
