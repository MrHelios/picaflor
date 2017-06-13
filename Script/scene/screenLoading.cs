using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class screenLoading : MonoBehaviour {

    private bool loadScene;
    private int scene;

    void Awake()
    {
        scene = -1;    
    }

    public void setScene(int i)
    {
        scene = i;
    }

    private IEnumerator loadNewScene()
    {
        yield return new WaitForSeconds(3);

        AsyncOperation async = SceneManager.LoadSceneAsync(scene);
        while (!async.isDone)
            yield return null;
    }
	
	void Update ()
    {
        if (scene != -1 && !loadScene)
        {
            loadScene = true;
            StartCoroutine(loadNewScene());
        }		
	}

}
