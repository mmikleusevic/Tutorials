using System;
using UnityEngine;

namespace _11
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] private SettingsPopup settingsPopup;

        private void Start()
        {
            settingsPopup.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                bool isShowing = settingsPopup.gameObject.activeSelf;
                settingsPopup.gameObject.SetActive(!isShowing);

                if (isShowing)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
            }
        }
    }
}