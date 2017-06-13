using UnityEngine;
using System.Collections;

namespace test010
{
    public class testKey : MonoBehaviour
    {

        void Start()
        {
            ejecutarAnimation();
        }

        private void queTeclaApreto()
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                    Debug.Log(vKey.ToString());
            }
        }

        private void ejecutarAnimation()
        {
            GetComponent<Animation>().Play();
        }

    }
}
