using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;



public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public int score = 0;
    public GameObject deadText;

    void Start()
    {
        Instance = this;
    }

    public void LoadNextScene(int levelIndex = 0)
    {
        StartCoroutine(LoadSceneAsync(levelIndex));
    }

    private IEnumerator LoadSceneAsync(int levelIndex)
    {

        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        yield return SceneManager.UnloadSceneAsync(buildIndex);

        SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Single).completed +=
            (AsyncOperation) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
            };

    }

    public void IncreaseScore(int score)
    {
        this.score += score;
    }

}
