using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace test010
{
    public class limpieza_fin : MonoBehaviour {

        void Start()
        {
            if (SceneManager.GetActiveScene().buildIndex == GetComponent<marca>().escena)
            {
                GetComponent<Collider2D>().enabled = true;
                GetComponent<atrib>().enabled = true;
                GetComponent<detectarJugadorIA>().enabled = true;
                GetComponent<esquivarObstaculosIA>().enabled = true;

                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }            
        }

    }
}
