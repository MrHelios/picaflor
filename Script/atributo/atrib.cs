using UnityEngine;
using UnityEditor;

namespace test010
{
    public abstract class atrib : MonoBehaviour
    {

        protected float vida;
        protected float vida_max;

        protected int nivel;

        protected float velocidad;

        public int queNivel()
        {
            return nivel;
        }

        public void setVida(float v)
        {
            vida = v;
        }

        public float getVida()
        {
            return vida;
        }

        public float getVidaMax()
        {
            return vida_max;
        }

        public void setVelocidad(float v)
        {
            velocidad = v;
        }

        public float getVelocidad()
        {
            return velocidad;
        }

        public abstract void perderVida(float t);

    }
}