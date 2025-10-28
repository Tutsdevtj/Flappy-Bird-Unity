using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public GameObject painelMadeiraMenu;

    void Start()
    {
        painelMadeiraMenu.SetActive(false);
    }

    public void OpenShop()
    {
        painelMadeiraMenu.SetActive(true);
        Debug.Log("Shop aberta!");
    }

    public void CloseShop()
    {
        painelMadeiraMenu.SetActive(false);
        Debug.Log("Shop fechada!");
    }
}
