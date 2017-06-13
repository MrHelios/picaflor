using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class removerObstaculos : MonoBehaviour {

        private int cantRestantes;
        private GameObject obstaculo;

	    void Start ()
        {
            cantRestantes = 0;
	    }

        public void setObstaculo(GameObject go)
        {
            obstaculo = go;
        }

        public void setCantidadRestantes(int i)
        {
            cantRestantes = i;
        }

        public void unoMenos()
        {
            cantRestantes--;
            if (cantRestantes == 0)
                obstaculo.SetActive(false);
        }
	
    }
}
