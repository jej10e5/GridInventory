using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;



public class AtlasManager : MonoBehaviour
{
    public static AtlasManager instance;

    public List<SpriteAtlas> arrAtlas = new List<SpriteAtlas>();

    private void Awake() 
    {
        AtlasManager.instance=this;
    }
    private AtlasManager(){}

    public SpriteAtlas GetAtlasByName(string name)
    {
        foreach(var v in arrAtlas) 
        {
            if(v.name == name)
            return v;
        }
        return null;

    }
    
}
