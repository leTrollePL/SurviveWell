using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SklepoweUI : MonoBehaviour
{
    private Transform container;
    private Transform shopItemTemplate;

    WhiteController white;
    BlackController black;

    private void Awake()
    {

        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
        shopItemTemplate = container.Find("ShopItemTemplate1");
        shopItemTemplate.gameObject.SetActive(false);
        shopItemTemplate = container.Find("ShopItemTemplate2");
        shopItemTemplate.gameObject.SetActive(false);

    }

    public void Show()
    {
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplate");
        shopItemTemplate.gameObject.SetActive(true);
        shopItemTemplate = container.Find("ShopItemTemplate1");
        shopItemTemplate.gameObject.SetActive(true);
        shopItemTemplate = container.Find("ShopItemTemplate2");
        shopItemTemplate.gameObject.SetActive(true);
    }

    public void Hide()
    {
        container = transform.Find("Container");
        shopItemTemplate = container.Find("ShopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
        shopItemTemplate = container.Find("ShopItemTemplate1");
        shopItemTemplate.gameObject.SetActive(false);
        shopItemTemplate = container.Find("ShopItemTemplate2");
        shopItemTemplate.gameObject.SetActive(false);
    }
    public void Update()
    {
        
    }

    private void Start()
    {
        Hide();
    }



    //private void CreateItemButton(Sprite imagesprite,string itemname, int itemcost)
    //{
    //    Transform shopItemTransform = Instantiate(shopItemTemplate, container);
    //    Rect()
    //}
}
