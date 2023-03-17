using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
//싱글톤 클래스
public class InfoManager
{
    public static readonly InfoManager instance = new InfoManager();

    public InventoryInfo InventoryInfo{get;set;}

    private InfoManager(){}

    public void SaveInventoryInfo()
    {
        try
        { //시도
            var path = string.Format("{0}/inventory_info.json",Application.persistentDataPath);
            //직렬화
            var json = JsonConvert.SerializeObject(this.InventoryInfo);
            //파일로 저장
            File.WriteAllText(path,json);
            Debug.Log("<color=yellow>saved success inventory_info.json</color>");
        }
        catch(System.Exception e)
        { //문제가 난다면

        }
        finally
        { //문제가 나든 안나든 실행

        }     
    }

    public void LoadInventoryInfo()
    {
        var path = string.Format("{0}/inventory_info.json",Application.persistentDataPath);
        var json = File.ReadAllText(path);
        //역직렬화
        this.InventoryInfo = JsonConvert.DeserializeObject<InventoryInfo>(json);
        Debug.Log("<color=yellow>saved success inventory_info.json</color>");

    }

}
