using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MyGameNamespace.Utils
{
    public class UI : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // Initialize UI elements here, such as setting up buttons or labels.
            Debug.Log("UI initialized.");
        }

        void Update()
        {
            // Update UI elements, such as checking for button clicks or animations.
            Debug.Log("UI updated every frame.");
        }


        public void SwitchTo(GameObject _menu)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }

            if (_menu != null)
            {
                _menu.SetActive(true);
            }
        }
    }
}