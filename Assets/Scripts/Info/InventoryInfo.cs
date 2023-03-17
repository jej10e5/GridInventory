using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 변하는 데이터 (저장 객체)
/// </summary>
public class InventoryInfo
{
    public List<ItemInfo> itemInfos; //컬렉션 반드시 사용 전 인스턴스화

    /// <summary>
    /// Called only for new users
    /// </summary>
    //처음 생성될 때 (우리가 객체를 만든다)
    public void Init()
    {
        this.itemInfos = new List<ItemInfo>(); //신규유저일 경우만 호출
    }

    //저장되어 있는 json파일을 불러와서 json 문자열을 역직렬화 될때 (Newton -> 객체를 생성)

}
