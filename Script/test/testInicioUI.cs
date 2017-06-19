using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace test010
{

    public class testInicioUI : MonoBehaviour {
	
	    void Start () {
            estaCanvas();
            cantidadCorrectaElementos(GameObject.Find("Canvas"), 7,
               "La cantidad de elementos requeridas en el canvas no es correcta.");
            estaUIVida();
            estaUIMana();
            estaUIEnergia();
            estaPanelAtajos();
            estaVentanaPersonaje();
            estaVentanaHabilidades();
            estaVentanaConfig();

            botones_panel_atajos(3, 7);
            ventana_personaje();
            ventana_habilidades();
            ventana_config();

            IntegrationTest.Pass();
	    }

        private void estaCanvas()
        {
            if (GameObject.Find("Canvas") == null)
            {
                Debug.Log("No esta Canvas.");
                IntegrationTest.Fail();
            }

            if (GameObject.Find("EventSystem") == null)
            {
                Debug.Log("No esta EventSystem.");
                IntegrationTest.Fail();
            }
        }

        private void cantidadCorrectaElementos(GameObject ui, int c, string err)
        {        
            int cant = ui.transform.childCount;
            int cant_elementos_deberia = c;
            if (cant != cant_elementos_deberia)
            {
                IntegrationTest.Fail();
                Debug.Log(ui);
                Debug.Log(err);
                Debug.Log("Se esperaba: " + c + " -> " + cant);
            }
        }

        private void analisisColor(Color color, float r, float b, float g, string err)
        {
            Color c = new Color(r, g, b);
            if (!c.Equals(color))
            {
                IntegrationTest.Fail();
                Debug.Log(err);
                Debug.Log("Se esperaba: " + color + " -> " + c);
                Debug.Log(color.r);
            }
        }

        private void analizar(int pos, string n,bool estado, string err)
        {
            GameObject canvas = GameObject.Find("Canvas");
            GameObject ui = canvas.transform.GetChild(pos).gameObject;

            bool activo = ui.activeSelf;
            string nombre = ui.name;

            if (estado != activo || ui.name != n)
            {
                IntegrationTest.Fail();
                Debug.Log(ui + " error: " + err);
                Debug.Log("Activo: " + activo);
                Debug.Log("Nombre: " + nombre);            
            }

            if (n.Contains("vida") || n.Contains("mana") || n.Contains("energia"))
            {
                GameObject hijo = ui.transform.GetChild(0).gameObject;

                if (n.Contains("vida"))
                {
                    float r = 1;
                    float b = 0;
                    float g = 0;
                    analisisColor(hijo.GetComponent<Image>().color, r, b, g, "El color de la vida no es correcto.");
                }
                else if (n.Contains("mana"))
                {
                    float r = 0;
                    float b = 1;
                    float g = 0;
                    analisisColor(hijo.GetComponent<Image>().color, r, b, g, "El color del mana no es correcto.");
                }
                else
                {
                    float r = 0;
                    float b = 0;
                    float g = 1;
                    analisisColor(hijo.GetComponent<Image>().color, r, b, g, "El color de la energia no es correcto.");
                }
            }
        }

        // TEST SIMPLES.

        private void estaUIVida()
        {
            analizar(0, "ui_vida", true, "UIVida");
        }

        private void estaUIMana()
        {
            analizar(1, "ui_mana", true, "UIMana");
        }

        private void estaUIEnergia()
        {
            analizar(2, "ui_energia", true, "UIEnergia");
        }
    
        private void estaPanelAtajos()
        {
            analizar(3, "ui_panel_atajos", true, "Panel atajos");
        }

        private void estaVentanaPersonaje()
        {
            analizar(4, "ui_ventana_personaje", false, "Ventana personaje");
        }

        private void estaVentanaHabilidades()
        {
            analizar(5, "ui_ventana_habilidades", false, "Ventana habilidades");
        }

        private void estaVentanaConfig()
        {
            analizar(6, "ui_ventana_config", false, "Ventana configuracion");
        }

        // TEST MAS ESPECIALIZADOS.

        private void botones_panel_atajos(int pos, int cant_hijos)
        {
            GameObject canvas = GameObject.Find("Canvas");
            GameObject ui = canvas.transform.GetChild(pos).gameObject;

            // ATAJOS
            cantidadCorrectaElementos(ui, cant_hijos, "La cantidad de hijos no es la esperada.");        

            for (int i = 0; i < 5; i++)
            {
                GameObject atajo = ui.transform.GetChild(i).gameObject;

                if (atajo.name != "atajo_" + i)
                {
                    IntegrationTest.Fail();
                    Debug.Log("El nombre del atajo no es correcto.");
                    Debug.Log("Se esperaba:  atajo_" + i + " -> " + atajo.name);
                }

                if (atajo.GetComponent<Button>() == null || !atajo.GetComponent<Button>().enabled)
                {
                    IntegrationTest.Fail();
                    Debug.Log(atajo);
                    Debug.Log("El GO no tiene la componente boton o esta desactivado.");
                }

                if (atajo.GetComponent<ventana_hab>() == null)
                {
                    IntegrationTest.Fail();
                    Debug.Log(atajo);
                    Debug.Log("El GO no tiene la componente para activar la ventana de habilidades");
                }
            }

            // PERSONAJE
            GameObject hijo = ui.transform.GetChild(5).gameObject;
            if (hijo.name != "boton_personaje")
            {
                IntegrationTest.Fail();
                Debug.Log("El nombre del boton del personaje no es correcto");
                Debug.Log("Se esperaba:  boton_personaje -> " + hijo.name);
            }

            if (hijo.GetComponent<Button>() == null || !hijo.GetComponent<Button>().enabled)
            {
                IntegrationTest.Fail();
                Debug.Log("El GO boton_personaje no tiene boton como componente o esta desactivado.");
            }

            if (hijo.GetComponent<ventana_personaje>() == null)
            {
                IntegrationTest.Fail();
                Debug.Log(hijo);
                Debug.Log("El GO no tiene la componente para activar la ventana de personaje");
            }

            // CONFIG
            hijo = ui.transform.GetChild(6).gameObject;
            if (hijo.name != "boton_config")
            {
                IntegrationTest.Fail();
                Debug.Log("El nombre del boton_config no es correcto");
                Debug.Log("Se esperaba:  boton_config -> " + hijo.name);
            }

            if (hijo.GetComponent<Button>() == null || !hijo.GetComponent<Button>().enabled)
            {
                IntegrationTest.Fail();
                Debug.Log("El GO boton_config no tiene boton como componente o esta desactivado.");
            }

            if (hijo.GetComponent<ventana_config>() == null)
            {
                IntegrationTest.Fail();
                Debug.Log(hijo);
                Debug.Log("El GO no tiene la componente para activar la ventana de config");
            }

        }

        private void ventana_personaje()
        {
            GameObject canvas = GameObject.Find("Canvas");
            GameObject ui = canvas.transform.GetChild(4).gameObject;

            if (ui.GetComponent<Image>() == null)
            {
                IntegrationTest.Fail();
                Debug.Log("La imagen para la ventana de personaje no es correcta.");
            }

            cantidadCorrectaElementos(ui, 1, "La cantidad de botones en la ventana habilidades no es correcta.");
        }

        private void ventana_habilidades()
        {
            GameObject canvas = GameObject.Find("Canvas");
            GameObject ui = canvas.transform.GetChild(5).gameObject;

            if (ui.GetComponent<Image>() == null)
            {
                IntegrationTest.Fail();
                Debug.Log("La imagen para la ventana de habilidades no es correcta.");
            }

            cantidadCorrectaElementos(ui, 9, "La cantidad de botones en la ventana habilidades no es correcta.");

            for (int i = 0; i < 8; i++)
                if (ui.transform.GetChild(i).GetComponent<cambiarAtajo>() == null)
                {
                    IntegrationTest.Fail();
                    Debug.Log(ui.transform.GetChild(i));
                    Debug.Log("En el boton de atajo falta el script cambiarAtajos.");
                }
        }

        private void ventana_config()
        {
            GameObject canvas = GameObject.Find("Canvas");
            GameObject ui = canvas.transform.GetChild(6).gameObject;

            if (ui.GetComponent<Image>() == null)
            {
                IntegrationTest.Fail();
                Debug.Log("La imagen para la ventana de habilidades no es correcta.");
            }        

            cantidadCorrectaElementos(ui, 3, "La cantidad de botones en la ventana configuracion no es correcta.");

            string[] datos = { "boton_reanudar", "boton_opciones", "boton_salir" };
            for (int i = 0; i < ui.transform.childCount; i++)
            {
                GameObject hijo = ui.transform.GetChild(i).gameObject;

                if (hijo.name != datos[i])
                {
                    IntegrationTest.Fail();
                    Debug.Log(hijo);
                    Debug.Log("Se esperaba: " + datos[i] + " -> " + hijo.name);
                }

                if (hijo.GetComponent<Button>() == null)
                {
                    IntegrationTest.Fail();
                    Debug.Log(hijo);
                    Debug.Log("Uno de los GO de la ventana config no tiene la componente Boton.");
                }         
            }

        }

    }
}
