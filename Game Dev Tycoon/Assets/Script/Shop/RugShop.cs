using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class RugShop : MonoBehaviour
{
   [SerializeField] List<RugsType> didntBoughtRug = new List<RugsType>();
   [SerializeField] RectTransform rugSaleTemplate;

   List<RectTransform> currentRugs = new List<RectTransform>();
   OwnedItems ownedItems;
   MoneyManager moneyManager;
   ChangeRug changeRug;
   int currentIndex;
   

    private void OnEnable() 
    {
        if(ownedItems==null)return;
        SetList(ownedItems);    
    }
   private void Awake() 
   {
        ownedItems = FindObjectOfType<OwnedItems>();
        moneyManager = FindObjectOfType<MoneyManager>();
        changeRug = FindObjectOfType<ChangeRug>();
   }

   public void SetList(OwnedItems ownedItems)
   {
        if(currentRugs.Count>0)
        {
            foreach(RectTransform rectTransform in currentRugs)
            {
                Destroy(rectTransform.gameObject);
            }
            currentRugs.Clear();
        }


        foreach(RugsType rug in ownedItems.CheckOwnedRugs())
        {
            if(didntBoughtRug.Contains(rug))
            {
                didntBoughtRug.Remove(rug);
            }
        }

        SetRugInfo setRugInfo = new SetRugInfo();

        foreach(RugsType rug in didntBoughtRug)
        {
           RectTransform rugSale = Instantiate(rugSaleTemplate, transform.position, Quaternion.identity, transform);
           rugSale.anchoredPosition = new Vector2(0, rugSaleTemplate.position.y+(-currentIndex*(rugSaleTemplate.sizeDelta.y+45)));
           setRugInfo.SetRug(rug,rugSale,moneyManager,changeRug, ownedItems, this);
           currentRugs.Add(rugSale);
           currentIndex++;
        }
   }
}


public class SetRugInfo
{
  public void SetRug(RugsType rugsType, RectTransform rectTransform, MoneyManager moneyManager,ChangeRug changeRug , OwnedItems ownedItems, RugShop rugShop)
  {
    rectTransform.Find("Image").GetComponent<UnityEngine.UI.Image>().sprite = rugsType.rugImage;
    rectTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = rugsType.rugName;
    rectTransform.Find("Cost").GetComponent<TextMeshProUGUI>().text = $"Cost: {rugsType.cost}";
    rectTransform.Find("Button").GetComponent<Button>().onClick.AddListener(() => CanAfford(moneyManager,changeRug,rugsType,rugsType.cost, ownedItems, rugShop));
  }

  public void CanAfford(MoneyManager moneyManager, ChangeRug changeRug, RugsType rugsType ,int cost, OwnedItems ownedItems, RugShop rugShop)
  {
    Debug.Log("saadsdas");

    if(moneyManager.CanAfford(cost))
    {
      ownedItems.AddRug(rugsType);
      changeRug.NewRug(rugsType.rugMaterial); 
      moneyManager.DecreaseMoney(cost);
      rugShop.SetList(ownedItems);
    }
  }

}
