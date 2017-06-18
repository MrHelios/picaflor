using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class screenLoading : MonoBehaviour {

    private bool loadScene;
    public int scene;    

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
        if (!loadScene)
        {
            loadScene = true;
            StartCoroutine(loadNewScene());
        }		
	}

}
