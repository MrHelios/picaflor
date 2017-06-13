using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace test010
{
    public class loadSceneMuerte : MonoBehaviour {

        public void muerte()
        {
            Debug.Log("Has perdido");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
