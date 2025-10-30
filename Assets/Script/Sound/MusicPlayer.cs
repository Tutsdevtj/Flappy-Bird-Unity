using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;
    private AudioSource audioSource;

    [Header("Trilha Sonora")]
    public AudioClip trilhaSonora;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.volume = 0.4f; // volume da música
    }

    private void Start()
    {
        if (trilhaSonora != null)
        {
            audioSource.clip = trilhaSonora;
            audioSource.Play();
        }
    }
}
