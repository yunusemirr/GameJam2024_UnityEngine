using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{


    [SerializeField] private Animator transition;
    [SerializeField] private float transitionTime = 1f;
    [SerializeField] private int nextSceneIndex = 1;
    private bool isNextScene;
    [SerializeField] private bool isNextable = false;


    private void Update()
    {
        if (Input.GetButtonDown("FireJoystick") && isNextable || isNextScene)
        {
            isNextScene = false;
            LoadNextLevel(nextSceneIndex);
        }
    }

    public void LoadNextLevel(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play Animation
        transition.SetTrigger("fade");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        GameManager.Instance.LoadNextScene(levelIndex);
        isNextScene = false;
    }

    public void NextLevelActivation(bool setActivation)
    {
        isNextScene = true;
    }

}

