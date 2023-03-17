using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;


public class UIGrideScrollView : MonoBehaviour
{
    public Transform content;
    public GameObject cellviewPrefab;
    public GameObject txtNoItemGo;
    private const int THRESHOLD = 18;
    private UIGridCellView currentFocusCellView;
    public System.Action<int> onFocus;


    public void Init() 
    {
        this.txtNoItemGo.SetActive(InfoManager.instance.InventoryInfo.itemInfos.Count == 0);

        this.CreateCellViews();

        this.GetComponent<ScrollRect>().vertical = InfoManager.instance.InventoryInfo.itemInfos.Count > THRESHOLD ;

    }

    public void Refresh()
    {
        //새로운 데이터 로드
        InfoManager.instance.LoadInventoryInfo();

        //원래 있던거 삭제
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }
        this.CreateCellViews();
        this.txtNoItemGo.SetActive(InfoManager.instance.InventoryInfo.itemInfos.Count == 0);
        this.GetComponent<ScrollRect>().vertical = InfoManager.instance.InventoryInfo.itemInfos.Count > THRESHOLD ;

    }

    private void CreateCellViews()
    {
        //int myItemCount = 15;
        //가지고 있는 아이템의 갯수만큼 생성
        for(int i=0;i<InfoManager.instance.InventoryInfo.itemInfos.Count;i++)
        {
            //cellview prefab의 인스턴스 (clone)
            var go = Instantiate(this.cellviewPrefab,this.content);
            var cellview = go.GetComponent<UIGridCellView>();
            var btn = go.GetComponent<Button>();
            btn.onClick.AddListener(()=>{
                Debug.Log(cellview.id);
                if(this.currentFocusCellView!=null)
                {
                    // 선택되어있는 cellview가 있다.
                    this.currentFocusCellView.Focus(false);
                    
                }
                cellview.Focus(true);
                this.currentFocusCellView = cellview;

                //이벤트 전송
                this.onFocus(this.currentFocusCellView.id);
            });
            //id,아이콘, 수량
            var info = InfoManager.instance.InventoryInfo.itemInfos[i];
            var data = DataManager.instance.GetItemData(info.id);
            
            
            var atlas = AtlasManager.instance.GetAtlasByName("UIItemIconAtlas");

            var sprite = atlas.GetSprite(data.sprite_name);
            

            /*
            var sprite = iconAtlas.GetSprite(data.sprite_name);
            */

            var amount = info.amount;
            cellview.Init(info.id,sprite,amount);

        }
    }

    
}
