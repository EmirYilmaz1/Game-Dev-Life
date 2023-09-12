using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetFurnitureInfo
{
  public void SetInfo(RectTransform rectTransform, Furniture furnitureType, OwnedItems ownedItems, MoneyManager moneyManager, Shop shop)
  {
    rectTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = furnitureType.FurnitureName;
    rectTransform.Find("Image").GetComponent<Image>().sprite = furnitureType.FurnitureImage;
    rectTransform.Find("Cost").GetComponent<TextMeshProUGUI>().text = $"Cost {furnitureType.Cost}";
    rectTransform.Find("Button").GetComponent<Button>().onClick.AddListener(() => CanAfford(furnitureType, ownedItems,moneyManager, shop));
  }

  public void CanAfford(Furniture furnitureType, OwnedItems ownedItems, MoneyManager moneyManager, Shop shop)
  {
    if(moneyManager.CanAfford(furnitureType.Cost))
    {
        moneyManager.DecreaseMoney(furnitureType.Cost);
        ownedItems.AddItem(furnitureType);
        shop.SetList();
    }
  }
}
