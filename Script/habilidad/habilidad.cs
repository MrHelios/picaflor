using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace test010
{
    public abstract class habilidad : MonoBehaviour {

        protected float mana;
        protected float aguante;
        protected float cooldown;
        protected float ultimoUso;
        protected KeyCode tecla;
        protected int nivel_necesario;

        public Sprite icono_hab;

        public int getNivelNecesario()
        {
            return nivel_necesario;
        }

        public void setIcon(Sprite s)
        {
            icono_hab = s;
        }

        // COOLDOWN

        public void setCooldown(float c)
        {
            cooldown = c;
        }

        public float getCooldown()
        {
            return cooldown;
        }

        // ULTIMO USO

        public void setUltimoUso(float c)
        {
            ultimoUso = c;
        }

        public float getUltimoUso()
        {
            return ultimoUso;
        }

        // TECLA

        public void setTecla(KeyCode k)
        {
            tecla = k;
        }

        public void queTecla()
        {
            int cant_hab = 4;
            for (int i = 0; i < cant_hab; i++)
                if (gameObject == gameObject.transform.parent.GetChild(i).gameObject && i == 0)
                    tecla = KeyCode.Mouse0;
                else if (gameObject == gameObject.transform.parent.GetChild(i).gameObject && i == 1)
                    tecla = KeyCode.Mouse1;
                else if (gameObject == gameObject.transform.parent.GetChild(i).gameObject && i == 2)
                    tecla = KeyCode.Alpha1;
                else if (gameObject == gameObject.transform.parent.GetChild(i).gameObject && i == 3)
                    tecla = KeyCode.Alpha2;
        }

        public void efectoCooldown()
        {
            ultimoUso = Time.time + cooldown;
        }

        public abstract void efecto();

    }
}
