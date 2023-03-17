using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class DataManager : MonoBehaviour
{
    public static readonly DataManager instance = new DataManager();

    //컬렉션 초기화
    private Dictionary<int,ItemData> dicItemData;

    //생성자
    private DataManager(){}

    public void LoadItemData()
    {
        //Resource
        //Data/item_data
        TextAsset asset = Resources.Load<TextAsset>("Data/item_data");
        string json = asset.text;
        Debug.Log(json);
        //역직렬화
        ItemData[] arr = JsonConvert.DeserializeObject<ItemData[]>(json);
        //foreach, for 돌리면서 dic에 추가(dic 인스턴스화 필요)
        
        //Linq 사용 (dic 인스턴스화 필요 x)
        this.dicItemData = arr.ToDictionary(x=>x.id); //id를 키로
        Debug.Log("item data loaded.");
        Debug.LogFormat("item data count : <color=yellow>{0}</color>", this.dicItemData.Count);
    }

    public ItemData GetItemData(int id)
    {
        if(this.dicItemData.ContainsKey(id))
        {
            return this.dicItemData[id];
        }
        Debug.LogFormat("key ({0}) not found.",id);
        return null;
    }

    public ItemData GetRandomItemData()
    {
        //랜덤 아이템 획득
        //0 ~ (count-1)  + 100
        var randId = Random.Range(0,this.dicItemData.Count) + 100;
        return GetItemData(randId);
    }
}
