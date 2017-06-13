using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public class buttonSetClass : MonoBehaviour {

	
        public void setClass(string c)
        {
            GameObject.Find("Hero").GetComponent<atribPrincipalesPlayer>().clase = c;

            if(c=="Guerrero")
                GameObject.Find("Hero").GetComponent<equiparArma>().setArma("hacha01");
            else if(c=="Mago")
                GameObject.Find("Hero").GetComponent<equiparArma>().setArma("baston01");
            GameObject.Find("Hero").GetComponent<equiparArma>().equipar();
        }

    }
}
