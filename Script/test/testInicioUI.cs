﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testInicioUI : MonoBehaviour {
	
	void Start () {
        estaCanvas();
        cantidadCorrectaElementos();
        estaUIVida();
        estaUIMana();
        estaUIEnergia();
        estaPanelHabilidades();
        estaVentanaPersonaje();

        botones_panel_habilidades(3, 7);

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

    private void cantidadCorrectaElementos()
    {
        GameObject canvas = GameObject.Find("Canvas");
        int cant = canvas.transform.childCount;
        if (cant != 5)
        {
            Debug.Log("La cantidad de elementos no es la esperada.");
            IntegrationTest.Fail();
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

    private void botones_panel_habilidades(int pos, int cant_hijos)
    {
        GameObject canvas = GameObject.Find("Canvas");
        GameObject ui = canvas.transform.GetChild(pos).gameObject;

        // ATAJOS
        int cant = ui.transform.childCount;
        if (cant_hijos != cant)
        {
            IntegrationTest.Fail();
            Debug.Log("La cantidad de hijos no es la esperada.");
        }
        
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

    }

    private void estaPanelHabilidades()
    {
        analizar(3, "ui_panel_habilidades", true, "Panel Habilidades");        
    }

    private void estaVentanaPersonaje()
    {
        analizar(4, "ui_ventana_personaje", false, "Ventana personaje");
    }
	
}
