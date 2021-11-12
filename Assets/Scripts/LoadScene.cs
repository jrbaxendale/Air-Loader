using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public string LevelName;
    public Slider progressBar;


    /*  public string SceneToLoad;

      AsyncOperation LoadingOperation;
    


      private void Awake()
      {

          SceneToLoad = "v10";
      }

      public void CreateLPWS()

      {
          LoadingOperation = SceneManager.LoadSceneAsync(SceneToLoad);


      }

      public void Update()

      {
          progressBar.value = Mathf.Clamp01(LoadingOperation.progress / 0.9f);


      }


      */


    public void Start()
    {
        LevelName = "v10";

    }

    public void LoadLevel()
    {
        StartCoroutine(LoadSceneAsync(LevelName));
    }

    IEnumerator LoadSceneAsync(string levelName)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(levelName);
        //op.allowSceneActivation = false;
        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            progressBar.value = progress;

            yield return null;
        }
    }

   





}




