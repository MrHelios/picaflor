using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace test010
{
    public class loadSceneMuerte : MonoBehaviour {

        protected int loadingScreen;

        private void Awake()
        {
            loadingScreen = 1;
        }

        public void muerte()
        {
            SceneManager.LoadScene(loadingScreen);
        }

    }
}
