using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

using test010;

public class atribPrincipalesPlayerTest {	

    
    public void vida_al_inicio()
    {
        GameObject hero = new GameObject();
        hero.AddComponent<atribPrincipalesPlayer>();
        Assert.AreEqual(hero.GetComponent<atrib>().getVida(), 100);
    }

    [Test]
    public void experiencia_al_inicio()
    {
        GameObject hero = new GameObject();
        hero.AddComponent<atribPrincipalesPlayer>();
        Assert.AreEqual(hero.GetComponent<atribPrincipalesPlayer>().getExperiencia(), 0);
    }

    
    public void nivel_al_inicio()
    {
        GameObject hero = new GameObject();
        hero.AddComponent<atribPrincipalesPlayer>();
        Assert.AreEqual(hero.GetComponent<atrib>().queNivel(), 1);
    }

}
