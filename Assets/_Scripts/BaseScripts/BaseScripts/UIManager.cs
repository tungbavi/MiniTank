using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : Singleton<UIManager>
{
    [SerializeField] GameObject homeScene;
    [SerializeField] GameObject shopScene;
    [SerializeField] GameObject eventScene;
    [SerializeField] GameObject mapScene;
    [SerializeField] GameObject upgadeScene;
    [SerializeField] GameObject previewScene;
    [SerializeField] GameObject purchasedScene;

    public void ShowHomeScene() 
    {
        homeScene.SetActive(true);
        shopScene.SetActive(false);
        eventScene.SetActive(false);
        upgadeScene.SetActive(false);
        mapScene.SetActive(false);
        previewScene.SetActive(false);
        purchasedScene.SetActive(false);
    }

    public void ShowShopScene() 
    {
        homeScene.SetActive(false);
        shopScene.SetActive(true);
        eventScene.SetActive(false);
        upgadeScene.SetActive(false);
        mapScene.SetActive(false);
        previewScene.SetActive(false);
        purchasedScene.SetActive(false);
    }

    public void ShowEventScene() 
    {
        homeScene.SetActive(false);
        shopScene.SetActive(false);
        eventScene.SetActive(true);
        upgadeScene.SetActive(false);
        mapScene.SetActive(false);
        previewScene.SetActive(false);
        purchasedScene.SetActive(false);
    }

    public void ShowMapScene() 
    {
        homeScene.SetActive(false);
        shopScene.SetActive(false);
        eventScene.SetActive(false);
        upgadeScene.SetActive(false);
        mapScene.SetActive(true);
        previewScene.SetActive(false);
        purchasedScene.SetActive(false);
    }

    public void ShowUpgadeScene() 
    {
        homeScene.SetActive(false);
        shopScene.SetActive(false);
        eventScene.SetActive(false);
        upgadeScene.SetActive(true);
        mapScene.SetActive(false);
        previewScene.SetActive(false);
        purchasedScene.SetActive(false);
    }  

    public void ShowPreviewScene() 
    {
        homeScene.SetActive(false);
        shopScene.SetActive(false);
        eventScene.SetActive(false);
        upgadeScene.SetActive(false);
        previewScene.SetActive(true);
        mapScene.SetActive(false);
        purchasedScene.SetActive(false);
    }

    public void ShowPurchasedScene()
    {
        homeScene.SetActive(false);
        shopScene.SetActive(false);
        eventScene.SetActive(false);
        upgadeScene.SetActive(false);
        previewScene.SetActive(false);
        purchasedScene.SetActive(true);
        mapScene.SetActive(false);
    }
    
    public void LoadBattleLv1()
    {
        SceneManager.LoadScene(1);
    }  
    
    public void LoadBattleLv2()
    {
        SceneManager.LoadScene(2);
    } 
    
    public void LoadBattleLv3()
    {
        SceneManager.LoadScene(3);
    }
}
