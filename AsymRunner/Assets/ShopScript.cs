using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public int skinNumber;
    public int activeSkin;
    public Image image;
    public Color color;


    private void Start()
    {
        image.sprite = ShopManager.singleton.skins[skinNumber].Icon;
        color = image.color;
    }
    private void Update()
    {
        if (Player1.singleton.currentSkin == skinNumber)
        {
            image.color = Color.black;
        }
        else
        {
            image.color = color;
        }
    }
    public void SetSkin()
    {
        if (ShopManager.singleton.skins[skinNumber].IsAvailable)
        {
            Player2.singleton.currentSkin = skinNumber;
            Player2.singleton.sprite.sprite = image.sprite;

            Player1.singleton.currentSkin = skinNumber;
            Player1.singleton.sprite.sprite = image.sprite;
        }
        else
        {
            Debug.Log("You need to buy it first");
        }
    }

    public void BuySkin()
    {
        if (GameManager.singleton.coins >= ShopManager.singleton.skins[skinNumber].Cost && ShopManager.singleton.skins[skinNumber].IsAvailable == false)
        {
            ShopManager.singleton.skins[skinNumber].IsAvailable = true;
            GameManager.singleton.coins -= ShopManager.singleton.skins[skinNumber].Cost;
            SetSkin();
        }
        
    }
}
