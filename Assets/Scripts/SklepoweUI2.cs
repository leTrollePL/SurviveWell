using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SklepoweUI2 : MonoBehaviour
{
    private Transform container2;
    private Transform shopItemTemplate;

    WhiteController white;
    BlackController black;

    private void Awake()
    {

        container2 = transform.Find("Container2");
        shopItemTemplate = container2.Find("ShopItemTemplateRed");
        shopItemTemplate.gameObject.SetActive(false);
        shopItemTemplate = container2.Find("ShopItemTemplateRed1");
        shopItemTemplate.gameObject.SetActive(false);
        shopItemTemplate = container2.Find("ShopItemTemplateRed2");
        shopItemTemplate.gameObject.SetActive(false);

    }

    public void Show()
    {
        container2 = transform.Find("Container2");
        shopItemTemplate = container2.Find("ShopItemTemplateRed");
        shopItemTemplate.gameObject.SetActive(true);
        shopItemTemplate = container2.Find("ShopItemTemplateRed1");
        shopItemTemplate.gameObject.SetActive(true);
        shopItemTemplate = container2.Find("ShopItemTemplateRed2");
        shopItemTemplate.gameObject.SetActive(true);
    }

    public void Hide()
    {
        container2 = transform.Find("Container2");
        shopItemTemplate = container2.Find("ShopItemTemplateRed");
        shopItemTemplate.gameObject.SetActive(false);
        shopItemTemplate = container2.Find("ShopItemTemplateRed1");
        shopItemTemplate.gameObject.SetActive(false);
        shopItemTemplate = container2.Find("ShopItemTemplateRed2");
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
