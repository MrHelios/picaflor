using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace test010
{
    public class atribPrincipalesPlayer : atrib {

        private float experiencia;    
        private int exp_proximo_nivel;
        private Vector3 pos_caso_de_muerte;
        public string clase;

        void Awake()
        {
            // Valores por defecto.
            gameObject.transform.position = pos_caso_de_muerte;
            vida = vida_max = 30;

            experiencia = 0;
            nivel = 1;
            exp_proximo_nivel = nivel * 10;

            clase = "Mago";
        }

        void Start()
        {            
            if (SceneManager.GetActiveScene().buildIndex == 2)
                GameObject.Find("Hero").gameObject.transform.position = new Vector3(0, 0, 0);
            else if (SceneManager.GetActiveScene().buildIndex == 1)
                pos_caso_de_muerte = new Vector3(-134,0.5f,0);            
        }

        public void setClase(string c)
        {
            clase = c;
        }

        public string getClase()
        {
            return clase;
        }

        public float getExperiencia()
        {
            return experiencia;
        }

        private void armarHabilidadClase()
        {
            if (clase == "Mago")
            {
                habilidad h = GameObject.Find("Mago").gameObject.transform.GetChild(0).GetComponent<habilidad>();
                gameObject.transform.GetChild(0).gameObject.AddComponent(h.GetType());
                gameObject.GetComponent<sistemaAtajo>().armarLibroAtajos();
            }
            else if (clase == "Guerrero")
            {
                habilidad h = GameObject.Find("Guerrero").gameObject.transform.GetChild(0).GetComponent<habilidad>();
                gameObject.transform.GetChild(0).gameObject.AddComponent(h.GetType());
                gameObject.GetComponent<sistemaAtajo>().armarLibroAtajos();
            }            
        }

        private void ui_exp_modificacion()
        {
            gameObject.GetComponent<uiPlayerExp>().modificar(experiencia / exp_proximo_nivel);
        }

        private void nivelNuevo()
        {
            experiencia = 0;
            ui_exp_modificacion();
            nivel++;
            Debug.Log(nivel);
            exp_proximo_nivel = nivel * 10;
        }

        public void reestablecerMaxVida()
        {
            vida = vida_max;
        }

        public void sumarExp(float f)
        {
            experiencia += f;

            if (experiencia >= exp_proximo_nivel)
                nivelNuevo();
            else
                ui_exp_modificacion();
        }

        public override void perderVida(float f)
        {
            if (gameObject.GetComponent<escudoDivino>() != null)
                gameObject.GetComponent<escudoDivino>().corte();
            else
            {
                vida -= f;
                gameObject.GetComponent<uiPlayerVida>().modificar(vida / vida_max);
                GetComponent<Animator>().SetTrigger("sangre");
            }

            if (vida <= 0) {
                gameObject.GetComponent<loadSceneMuerte>().muerte();
            }        
        }

        public void setPosicionMuerte(Vector3 v)
        {
            pos_caso_de_muerte = v;
        }

        public void ubicarHeroe()
        {
            gameObject.transform.position = pos_caso_de_muerte;
        }

    }
}
