using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skin.asset", menuName = "Data/Player/Skin")]
public class PlayerSkinData : ScriptableObject
{
    public int ID;
    public GameObject Prefab;
    public Sprite image;


}

// public class PhuKien : ScriptableObject{
//     public int ID;
//     public Sprite image;
// }
