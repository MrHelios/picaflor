using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace test010
{
    public class iniciado_fin : MonoBehaviour
    {
	
	    void Start ()
        {
            if (SceneManager.GetActiveScene().buildIndex == GetComponent<detectarJugPos>().escena)
                GetComponent<detectarJugPos>().enabled = true;
        }	
	
    }
}
