using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl; // Necessário para Coroutines (Efeito de Flash)

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerFlappyBird : MonoBehaviour
{
    [Header("Controles e Física")]
    [SerializeField]
    private float velocidadePulo = 5f;

    [Header("Rotação (Estilo Flappy Bird)")]
    [SerializeField]
    private float upRotation = 35f;
    [SerializeField]
    private float downRotationLimit = -90f;
    [SerializeField]
    private float downRotationSpeed = 300f;

    [Header("Referências de Jogo")]
    public GameOver game;

    [Header("Referências de UI (Menu)")]

    public GameObject getReadyUI;


    public UnityEngine.UI.Image screenFlashImage;


    private Rigidbody2D _rb2D;
    private GameHandler _gameHandler;
    private bool isGameStarted = false;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _gameHandler = FindFirstObjectByType<GameHandler>();
        _rb2D.isKinematic = true;
        isGameStarted = false;
        if (getReadyUI != null)
            getReadyUI.SetActive(true);
        if (screenFlashImage != null)
            screenFlashImage.color = new Color(1f, 1f, 1f, 0f);
            screenFlashImage.color = new Color(1f, 1f, 1f, 0f);
    }

    void Update()
    {
        if (!isGameStarted)
        {
            Points.scoreValue = 0;
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                StartGame();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                Pular();
            }

            HandleRotation();
        }
    }

    private void StartGame()
    {
        isGameStarted = true;

        _rb2D.isKinematic = false;

        if (getReadyUI != null)
            getReadyUI.SetActive(false);

        Pular();

        if (screenFlashImage != null)
            StartCoroutine(ScreenFlash());
    }

    private void Pular()
    {
        SoundManager.instance.PlayWing();

        _rb2D.linearVelocity = new Vector2(_rb2D.linearVelocity.x, velocidadePulo);
        transform.rotation = Quaternion.Euler(0, 0, upRotation);
    }

    private void HandleRotation()
    {
        if (_rb2D.linearVelocity.y < -0.1f)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 0, downRotationLimit);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                downRotationSpeed * Time.deltaTime
            );
        }
    }


    IEnumerator ScreenFlash()
    {
        screenFlashImage.color = Color.white;

        float fadeDuration = 0.5f;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            screenFlashImage.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }

        screenFlashImage.color = new Color(1f, 1f, 1f, 0f);
    }
    private bool isDead = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isDead)
        {
            isDead = true;


            SoundManager.instance.PlayMorte();


            _rb2D.isKinematic = false;
            _rb2D.linearVelocity = Vector2.zero;
            _rb2D.gravityScale = 3f;


            transform.rotation = Quaternion.Euler(0, 0, -90);


            StartCoroutine(ShowGameOverAfterDelay(1f));
        }
    }

    private IEnumerator ShowGameOverAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (game != null)
        {
            game.GameOverActive();
        }
        else
        {
            Debug.LogWarning("Referência para 'GameOver' não foi definida no Inspector.");
        }
    }

}
