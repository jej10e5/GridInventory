using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGrideScrollViewDirector : MonoBehaviour
{

    public UIGrideScrollView scrollView;
    public Button btnTestGetItem;
    public UIPopupItemDetail popupDetail;

   public void Init()
   {
      this.popupDetail.onSell=(id)=>{
        Debug.LogFormat("<color=magenta>Sell Item : {0}</color>",id);
        this.SellItem(id);
      };

      this.scrollView.onFocus=(id)=>{
        var foundInfo = InfoManager.instance.InventoryInfo.itemInfos.Find(x=>x.id==id);
        Debug.LogFormat("<color=yello>[UIGRIDEScrollViewDirector] onFocus - id : {0}, amount : {1}</color>",id,foundInfo.amount);
        this.popupDetail.Init(id).Open();
      };

      this.popupDetail.btnClose.onClick.AddListener(()=>{
          this.popupDetail.Close();
      });

      this.btnTestGetItem.onClick.AddListener(()=>{
        
        var data = DataManager.instance.GetRandomItemData();

        var id = data.id;
        var foundInfo = InfoManager.instance.InventoryInfo.itemInfos.Find(x=> x.id == id);
        //없으면 info : null
        if(foundInfo==null)
        {
          //인벤토리에 없다.
          ItemInfo info = new ItemInfo(id);
          InfoManager.instance.InventoryInfo.itemInfos.Add(info); //최초 아이템 획득
        }
        else
        {
          foundInfo.amount++;
        }

        //저장
        InfoManager.instance.SaveInventoryInfo();

        this.scrollView.Refresh();
      });
      this.scrollView.Init();
   }

   private void SellItem(int id)
   {
      var info = InfoManager.instance.InventoryInfo.itemInfos.Find(x=>x.id==id);
      Debug.LogFormat("찾은 아이템 id : {0}, 수량 : {1}",info.id,info.amount);
      
      //하나밖에 없다 -> 인벤토리에서 제거
      if(info.amount==1)
      {
        //지우고
        Debug.LogFormat("지우기 전 :{0}",InfoManager.instance.InventoryInfo.itemInfos.Count);
        InfoManager.instance.InventoryInfo.itemInfos.Remove(info);
        Debug.LogFormat("지운 후 :{0}",InfoManager.instance.InventoryInfo.itemInfos.Count);

        //팝업을 끄고
        this.popupDetail.Close();  
        
      }
      else
      {
        --info.amount;
      }

      //지우거나 수량을 줄이고 저장
      InfoManager.instance.SaveInventoryInfo();

      //리스트를 새로고침
      this.scrollView.Refresh();
   }

}
