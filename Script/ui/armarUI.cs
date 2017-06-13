using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace test010
{
    public class armarUI : MonoBehaviour {

        private float wx;
        private float hy;
	
	    void Start () {
            hy = Screen.height;
            wx = Screen.width;

            if (SceneManager.GetActiveScene().buildIndex == 0)
                efectoMenu();
            else
                inGame();
        }

        private void efectoMenu()
        {
            transform.GetChild(0).gameObject.transform.position = new Vector3((wx - wx) + 100, (hy - hy) + hy*0.8f, 0);
            transform.GetChild(1).gameObject.transform.position = new Vector3((wx - wx) + 100, (hy - hy) + hy * 0.73f, 0);

            transform.GetChild(2).gameObject.transform.position = new Vector3((wx - wx) + wx * 0.5f, (hy - hy) + hy * 0.1f, 0);
            transform.GetChild(3).gameObject.transform.position = new Vector3((wx - wx) + wx * 0.7f, (hy - hy) + hy * 0.1f, 0);
        }

        private void inGame()
        {
            transform.GetChild(0).gameObject.transform.position = new Vector3((wx - wx) + 100, (hy - hy) + hy * 0.9f, 0);
            transform.GetChild(1).gameObject.transform.position = new Vector3((wx - wx) + 100, (hy - hy) + hy * 0.88f, 0);
            transform.GetChild(2).gameObject.transform.position = new Vector3((wx - wx) + 50, (hy - hy) + hy * 0.93f, 0);

            transform.GetChild(3).gameObject.transform.position = new Vector3((wx - wx) + wx * 0.5f, (hy - hy) + hy * 0.05f, 0);
        }

    }
}
