using UnityEngine;
using UnityEditor;

namespace test010
{
    public abstract class atrib : MonoBehaviour
    {
        // ATRIBUTOS BASICOS

        protected int fuerza;
        protected int fortaleza;
        protected int agilidad;
        protected int fe;
        protected int inteligencia;
        protected int suerte;

        protected int puntos_no_gastados;

        // ATRIBUTOS COMPUESTO

        protected float vida;
        protected float vida_max;

        protected float mana;
        protected float mana_max;

        protected float aguante;
        protected float aguante_max;

        protected float velocidad;

        protected int nivel;

        // METEDOS ATRIBUTOS BASICOS

        public void setFuerza(int f)
        {
            fuerza = f;
        }

        public int getFuerza()
        {
            return fuerza;
        }

        public void setFortaleza(int f)
        {
            fortaleza = f;
        }

        public int getFortaleza()
        {
            return fortaleza;
        }

        public void setAgilidad(int a)
        {
            agilidad = a;
        }

        public int getAgilidad()
        {
            return agilidad;
        }

        public void setFe(int f)
        {
            fe = f;
        }

        public int getFe()
        {
            return fe;
        }

        public void setInteligencia(int i)
        {
            inteligencia = i;
        }

        public int getInteligencia()
        {
            return inteligencia;
        }

        public void setSuerte(int s)
        {
            suerte = s;
        }

        public int getSuerte()
        {
            return suerte;
        }

        public void setPuntosNoGastados(int p)
        {
            puntos_no_gastados = p;
        }

        public int getPuntosNoGastados()
        {
            return puntos_no_gastados;
        }

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