using UnityEngine;
using UnityEditor;

namespace test010
{
    public abstract class atrib : MonoBehaviour
    {

        protected float vida;
        protected float vida_max;

        protected float mana;
        protected float mana_max;

        protected float aguante;
        protected float aguante_max;

        protected int nivel;

        protected float velocidad;

        // NIVEL

        public int queNivel()
        {
            return nivel;
        }

        // VIDA

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

        public abstract void perderVida(float t);

        // MANA

        public void setMana(float m)
        {
            mana = m;
        }

        public float getMana()
        {
            return mana;
        }

        public float getManaMax()
        {
            return mana_max;
        }

        public bool tieneMana(float m)
        {
            if (mana >= m)
                return true;
            else
                return false;
        }

        public abstract void perderMana(float m);        

        // AGUANTE

        public void setAguante(float a)
        {
            aguante = a;
        }

        public float getAguante()
        {
            return aguante;
        }

        public float getAguanteMax()
        {
            return aguante_max;
        }

        public bool tieneAguante(float a)
        {
            if (aguante >= a)
                return true;
            else
                return false;
        }

        public abstract void perderAguante(float m);

        // VELOCIDAD

        public void setVelocidad(float v)
        {
            velocidad = v;
        }

        public float getVelocidad()
        {
            return velocidad;
        }

    }
}