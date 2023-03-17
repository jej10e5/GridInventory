using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIPopupItemDetail : MonoBehaviour
{
    public TMP_Text txtItemType;
    public Image imgItemIcon;
    public TMP_Text txtItemName;
    public Button btnSell;
    public TMP_Text txtSellPrice;
    public Button btnClose;
    public System.Action<int> onSell;
    private int id;

    

    /// <summary>
    /// Must be called before opening.
    /// </summary>
    public UIPopupItemDetail Init(int id)
    {
        this.id = id;
        var data = DataManager.instance.GetItemData(id);
        var type = (UIEnums.eItemType)data.type;
        this.txtItemType.text = type.ToString();

        var atlas = AtlasManager.instance.GetAtlasByName("UIItemIconAtlas");
        var sprite = atlas.GetSprite(data.sprite_name);
        this.imgItemIcon.sprite=sprite;

        this.txtItemName.text = data.name;

        if(data.sell_price!=-1)
        {
            this.btnSell.onClick.AddListener(OnSellActionHandler);

            this.btnSell.gameObject.SetActive(true);
            this.txtSellPrice.text = string.Format("{0}",data.sell_price);
            
            
        }
        else
        {
            //Quest 아이템이라면
            this.btnSell.gameObject.SetActive(false);

        }

        

        return this;
        
    }

    private void OnSellActionHandler()
    {
       this.onSell(this.id);

    }

   public void Open()
   {
        this.gameObject.SetActive(true);
   }
   public void Close()
   {
        this.gameObject.SetActive(false);
        this.btnSell.onClick.RemoveListener(OnSellActionHandler);
   }
}
