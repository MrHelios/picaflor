using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using test010;

public class cambiarEscenaInGame : MonoBehaviour
{
    private LayerMask hero;
    private float radio;
    public int irEscena;
    public Vector3 v;

    private void Start()
    {
        radio = 2f;
        hero = LayerMask.GetMask("Player");
    }

    void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, radio, hero);
        if (col != null && Input.GetKeyDown(KeyCode.E))
        {
            GameObject c = GameObject.Find("control");
            c.GetComponent<gamecontrol>().setEscenaVoy(irEscena);
            c.GetComponent<gamecontrol>().setPosPortal(v);
            SceneManager.LoadScene(irEscena);
        }
    }

}
