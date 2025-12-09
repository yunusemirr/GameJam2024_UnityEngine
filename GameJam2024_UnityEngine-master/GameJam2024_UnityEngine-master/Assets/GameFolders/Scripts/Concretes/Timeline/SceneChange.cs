using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlatformerGame.Concretes.Timeline
{
    public class SceneChange : MonoBehaviour
    {
        
        [SerializeField] private float delayLevelTime = 2f;

        public void ChangeSceneNext(int levelIndex)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }
        
        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(delayLevelTime);
            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            yield return SceneManager.UnloadSceneAsync(buildIndex);

            SceneManager.LoadSceneAsync(buildIndex + levelIndex).completed += (AsyncOperation obj) =>
            {

                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));

            };
        }
    }
}
