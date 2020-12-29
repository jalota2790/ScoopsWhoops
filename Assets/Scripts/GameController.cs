using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public ScoopSpawner scoopSpawner;

    public int minimumScoopsTofollowCamera;

    public Cone cone;

    public CameraController cameraController;

    public float speedMultiplier;

    public float currentSpeed;

    public float scoreToAdd;

    public float scoreToAddMultiplier;

    public float scoreIncremention;

    public float currentScore;

    public float currentScoreShown;

    public Text scoreText;

    public GameObject startScreen;

    public GameObject gameOver;

    public bool isRunning;

    void Awake()
    {
        instance = this;
    }

    public void StartGame()
    {
        startScreen.SetActive(false);
        scoopSpawner.Begin();
        isRunning = true;
    }

    private void Update()
    {
        if (isRunning)
        {
            currentSpeed += currentSpeed * speedMultiplier * Time.deltaTime;
            scoreToAdd += scoreToAdd * scoreToAddMultiplier * Time.deltaTime;
        }

        if (currentScoreShown < currentScore)
            currentScoreShown += scoreIncremention * Time.deltaTime;

        scoreText.text = "Score: " + currentScoreShown.ToString("F0");
    }

    public void AddedScoop()
    {
        currentScore += scoreToAdd;

        if (cone.GetScoopsCount() >= minimumScoopsTofollowCamera)
        {
            cameraController.FollowPosition(cone.GetLastScoopPosition());
        }
    }

    public void EndGame()
    {
        isRunning = false;
        scoopSpawner.Stop();
        gameOver.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
