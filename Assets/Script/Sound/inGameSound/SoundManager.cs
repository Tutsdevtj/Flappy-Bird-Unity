using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    public AudioClip coinColete;
    public AudioClip birdMorte;
    public AudioClip birdWing;

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // DontDestroyOnLoad(gameObject); mantém o som entre cenas
    }

    public void PlayCoin()
    {
        audioSource.PlayOneShot(coinColete);
    }

    public void PlayMorte()
    {
        audioSource.volume = 0.1f;
        audioSource.PlayOneShot(birdMorte);
    }

    public void PlayWing()
    {
        audioSource.PlayOneShot(birdWing);
    }
}
