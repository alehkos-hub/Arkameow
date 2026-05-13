using TMPro;
using UnityEngine;

public enum GameState
{
    Menu,
    Playing,
    Victory,
    GameOver
}
public class GameManager : MonoBehaviour
{
    [SerializeField] BlockGridSpawner blockSpawner;

    int blocksRemaining;
    int score;
    GameState state = GameState.Menu;
    public GameState CurrentState => state;
    [SerializeField] int maxLives = 3;
    int currentLives;

    [SerializeField] BallController ball;
    [SerializeField] Transform ballSpawn;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] GameObject panelMenu;
    [SerializeField] GameObject panelHUD;
    [SerializeField] GameObject panelVictory;
    [SerializeField] GameObject panelGameOver;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip victoryClip;
    [SerializeField] AudioClip loseClip;

    [SerializeField] TextMeshProUGUI scoreText;

    public void StartGame()
    {
        score = 0;
        currentLives = maxLives;
        UpdateScoreUI();
        UpdateLivesUI();
        SetState(GameState.Playing);
        if (blockSpawner != null)
        {
            blockSpawner.Spawn();
            blocksRemaining = blockSpawner.GetTotalBlocks();
        }
        ResetBall();
    }
    public void AddScore(int amount)
    {
        score += amount;
        blocksRemaining--;
        UpdateScoreUI();
        CheckVictory();
        Debug.Log("Puntuación: " + score);
        Debug.Log("Bloques restantes: " + blocksRemaining);
    }
    void CheckVictory()
    {
        if (blocksRemaining <= 0)
        {
            SetState(GameState.Victory);
        }
    }
    void SetState(GameState newState)
    {
        state = newState;
        panelMenu.SetActive(newState == GameState.Menu);
        panelHUD.SetActive(newState == GameState.Playing);
        panelVictory.SetActive(newState == GameState.Victory);
        panelGameOver.SetActive(newState == GameState.GameOver);

        if (newState == GameState.Victory)
        {
            audioSource.PlayOneShot(victoryClip);
        }
        if (newState == GameState.GameOver)
        {
            audioSource.PlayOneShot(loseClip);
        }
    }

    void Start()
    {
        SetState(GameState.Menu);
        ResetBall();
    }
    void Update()
    {

    }
    void UpdateLivesUI()
    {
        livesText.text = "Lives: " + currentLives;
    }
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
    public void LoseLife()
    {
        if (state != GameState.Playing)
            return;
        currentLives--;
        UpdateLivesUI();
        if (currentLives <= 0)
        {
            SetState(GameState.GameOver);
        }
        else
        {
            ResetBall();
        }
    }
    void ResetBall()
    {
        ball.ResetBall(ballSpawn.position);
    }
    public void ReturnToMenu()
    {
        SetState(GameState.Menu);
        ResetBall();
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
