using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "New Item/item")] 
// 프로젝트창에 우클릭하면 이제 NewItem 나옴

public class Item : ScriptableObject //게임오브젝트에 붙일필요없는 오브젝트 
{
    public string itemName; //아이템이름
    public ItemType itemType; //아이템 유형
    public Sprite itemImage; //아이템 이미지
    public GameObject itemPrefab; //아이템 프리팹
    public GameObject realPrefab; //실제 장치하게되는 프리팹 

    public enum ItemType { 
    
        Gun,
        Attack,
        Heal,
        CanOpen,
        Etx
   
    }

}
