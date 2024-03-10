using System.Collections.Generic;
using UnityEngine;

public class SelectOption : MonoBehaviour
{

    public List<GameObject> menuPunkt;

    public List<UnityEngine.UI.Button> menuButtons;

    private int menuIndex = 0;


    // Verzögerung zwischen den Menu Optionen
    private float delayTimer = 0f;

    // Wird einmal pro Frame aufgerufen
    void Update()
    {
        delayTimer -= Time.deltaTime;
        // Bei Input nach unten wird der menuIndex verringert
        if (delayTimer <= 0 && Input.GetAxis("Vertical") < -0.5f)
        {
            menuPunkt[menuIndex++].SetActive(false);

            menuIndex = Mathf.Clamp(menuIndex, 0, menuPunkt.Count - 1);

            menuPunkt[menuIndex].SetActive(true);

            delayTimer = 0.5f;
        }
        delayTimer -= Time.deltaTime;
        // Bei Input nach open wird der menuIndex vergrößert
        if (delayTimer <= 0 && Input.GetAxis("Vertical") > 0.5f)
        {
            menuPunkt[menuIndex--].SetActive(false);

            menuIndex = Mathf.Clamp(menuIndex, 0, menuPunkt.Count + 1);

            menuPunkt[menuIndex].SetActive(true);

            delayTimer = 0.5f;
        }
        // Auswahl von Menu Ui Buttons
        if (Input.GetButtonDown("Jump"))
        {
            menuButtons[menuIndex].onClick.Invoke();
        }
    }


}
