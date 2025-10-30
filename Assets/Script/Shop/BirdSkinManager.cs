using UnityEngine;

[System.Serializable]
public struct SkinConfiguration 
{
    public string itemID; // Deve ser EXATAMENTE igual ao itemID no ShopItem
    public AnimatorOverrideController animationOverride; 
}

public class BirdSkinManager : MonoBehaviour
{
    public SkinConfiguration[] possibleSkins; 
    
    private Animator birdAnimator;

    void Awake()
    {
        birdAnimator = GetComponent<Animator>();
        LoadSkin();
    }

    void LoadSkin()
    {
        string equippedSkinID = PlayerPrefs.GetString("EquippedItem", "Classic");

        AnimatorOverrideController controllerToEquip = null;
        foreach (var skin in possibleSkins)
        {
            if (skin.itemID == equippedSkinID)
            {
                controllerToEquip = skin.animationOverride;
                break; 
            }
        }

        if (controllerToEquip != null)
        {
            birdAnimator.runtimeAnimatorController = controllerToEquip;
        }
        else
        {
            Debug.LogWarning($"Skin ID '{equippedSkinID}' não encontrada em BirdSkinManager!");
            
            if (possibleSkins.Length > 0)
            {
                birdAnimator.runtimeAnimatorController = possibleSkins[0].animationOverride;
            }
        }
    }
}