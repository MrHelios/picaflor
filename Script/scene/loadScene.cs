using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace test010
{
    public class loadScene : MonoBehaviour {	

        public void LoadByIndex(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void LoadSameLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
