using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace test010
{
    public abstract class item : MonoBehaviour
    {
        protected string nombre;

        protected bool equipable;
        protected bool acumulable;
        protected int cantidad;

        public abstract void efecto();

        public abstract void iniciar();

        // NOMBRE.

        public void setNombre(string n)
        {
            nombre = n;
        }

        public string getNombre()
        {
            return nombre;
        }

        // EQUIPABLE.

        public void setEquipable(bool e)
        {
            equipable = e;
        }

        public bool esEquipable()
        {
            return equipable;
        }

        // ACUMULABLE.

        public void setAcumulable(bool a)
        {
            acumulable = a;
        }

        public bool esAcumulable()
        {
            return acumulable;
        }

        // CANTIDAD

        public void setCantidad(int c)
        {
            cantidad = c;
        }

        public void cambiarCantidad(int c)
        {
            if(esAcumulable())
                cantidad += c;
        }

        public int getCantidad()
        {
            return cantidad;
        }
	    
    }
}
