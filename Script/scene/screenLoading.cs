using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using test010;

public class screenLoading : MonoBehaviour
{

    private bool loadScene;
    private int scene;    

    public void setScene(int i)
    {
        scene = i;
    }

    private IEnumerator loadNewScene()
    {
        GameObject control = GameObject.Find("control");
        if (control.GetComponent<gamecontrol>().getMuerto())
            scene = control.GetComponent<gamecontrol>().getEscena();
        else
            scene = control.GetComponent<gamecontrol>().getQueEscenaVoy();

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
