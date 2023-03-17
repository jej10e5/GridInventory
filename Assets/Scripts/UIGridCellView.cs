using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIGridCellView : MonoBehaviour
{
    public Image imgIcon;
    public GameObject focusGo;
    public TMP_Text txtAmount;
    public int id;

    public void Init(int id, Sprite sprite, int amount)
    {
        this.id=id;
        this.imgIcon.sprite = sprite;
        this.imgIcon.SetNativeSize();
        this.txtAmount.text = amount.ToString();
        this.txtAmount.gameObject.SetActive(amount>1);
    }
    
    public void Focus(bool active)
    {
        this.focusGo.SetActive(active);
    }
}
