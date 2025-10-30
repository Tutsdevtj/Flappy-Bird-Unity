using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    public AudioClip coinColete;
    public AudioClip birdMorte;
    public AudioClip birdWing;
    public AudioClip scoreSound; // <-- renomeado aqui
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
    }

    public void PlayCoin()
    {
        audioSource.volume = 0.3f;
        audioSource.PlayOneShot(coinColete);
    }

    public void SoundScoreAdd()
    {
        audioSource.volume = 0.2f;
        audioSource.PlayOneShot(scoreSound);
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
