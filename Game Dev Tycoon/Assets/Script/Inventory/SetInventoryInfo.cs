
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetInventoryInfo 
{
   public void SetInventory(RectTransform inventoryTemplate, Furniture furniture, Spawner spawner)
   {
      inventoryTemplate.Find("Name").GetComponent<TextMeshProUGUI>().text = furniture.FurnitureName;
      inventoryTemplate.Find("Image").GetComponent<Image>().sprite = furniture.FurnitureImage;
      inventoryTemplate.Find("Button").GetComponent<Button>().onClick.AddListener(() => spawner.Spawn(furniture));
   }
}
