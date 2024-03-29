using UnityEngine;
using UnityEngine.UI;

public class OnPlay : MonoBehaviour
{
    public GameObject hudCanvas;
    public GameObject startCanvas;
    public GameObject control;
  

    void Start()
    {
        // Al iniciar el juego, desactivar el HUD y activar el menú de inicio
        hudCanvas.SetActive(false);
        control.SetActive(false);
        startCanvas.SetActive(true);

        // Asociar la función PlayButtonOnClick al evento onClick del botón de jugar

    }

    public void PlayButtonOnClick()
    {
        // Al hacer clic en el botón de jugar, activar el HUD y desactivar el menú de inicio
        hudCanvas.SetActive(true);
        startCanvas.SetActive(false);
    }  public void ControlsOnClick()
    {
        // Al hacer clic en el botón de jugar, activar el HUD y desactivar el menú de inicio
        control.SetActive(true);
        startCanvas.SetActive(false);
    }public void StartOnClick()
    {
        // Al hacer clic en el botón de jugar, activar el HUD y desactivar el menú de inicio
        control.SetActive(false);
        startCanvas.SetActive(true);
    }

}
