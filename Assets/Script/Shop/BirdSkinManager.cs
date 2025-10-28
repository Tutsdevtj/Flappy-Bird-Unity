using UnityEngine;

public class BirdSkinManager : MonoBehaviour
{
    public static BirdSkinManager Instance;
    private SpriteRenderer sr;

    [Header("Sprites das Skins")]
    public Sprite classicSprite;
    public Sprite yellowClassicSprite;
    public Sprite luizinhoSprite;
    public Sprite tutuCalvoSprite;
    public Sprite kaueIndianoSprite;
    public Sprite thePoffoSprite;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        sr = GetComponent<SpriteRenderer>();

        // Carrega a skin salva ao iniciar o jogo
        string equippedID = PlayerPrefs.GetString("EquippedItem", "Classic");
        ApplySkin(equippedID);
    }

    public void ApplySkin(string itemID)
    {
        switch (itemID)
        {
            case "Classic":
                sr.sprite = classicSprite;
                break;
            case "YellowClassic":
                sr.sprite = yellowClassicSprite;
                break;
            case "Luizinho":
                sr.sprite = luizinhoSprite;
                break;
            case "TutuCalvo":
                sr.sprite = tutuCalvoSprite;
                break;
            case "KaueIndiano":
                sr.sprite = kaueIndianoSprite;
                break;
            case "ThePoffo":
                sr.sprite = thePoffoSprite;
                break;
            default:
                sr.sprite = classicSprite;
                break;
        }

        Debug.Log($"Skin carregada: {itemID}");
    }

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}
