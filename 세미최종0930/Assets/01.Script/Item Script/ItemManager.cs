using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{

    public static Transform currentItem;

    public static Animator currentItemAnim;
    //공유 자원임..
    public static bool isItem = false;
    [SerializeField]
    private float changeItemDelayTime;

    [SerializeField]
    private float changeItemEndDelayTime;

    [SerializeField]
    private Item[] items;


    private Dictionary<string, Item> ItemDictionary = new Dictionary<string, Item>();

    [SerializeField]
    private string currentItemType;

    //private ItemC
    // Start is called before the first frame update
    void Start()
    {

        ItemDictionary.Add("돌멩이", items[0]);
       //ItemDictionary["돌멩이"];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
