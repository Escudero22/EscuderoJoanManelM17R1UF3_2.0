using UnityEngine;
using UnityEngine.UI;

public class OnPlay : MonoBehaviour
{
    public GameObject hudCanvas;
    public GameObject startCanvas;
    public GameObject control;
  

    void Start()
    {
        // Al iniciar el juego, desactivar el HUD y activar el men� de inicio
        hudCanvas.SetActive(false);
        control.SetActive(false);
        startCanvas.SetActive(true);

        // Asociar la funci�n PlayButtonOnClick al evento onClick del bot�n de jugar

    }

    public void PlayButtonOnClick()
    {
        // Al hacer clic en el bot�n de jugar, activar el HUD y desactivar el men� de inicio
        hudCanvas.SetActive(true);
        startCanvas.SetActive(false);
    }  public void ControlsOnClick()
    {
        // Al hacer clic en el bot�n de jugar, activar el HUD y desactivar el men� de inicio
        control.SetActive(true);
        startCanvas.SetActive(false);
    }public void StartOnClick()
    {
        // Al hacer clic en el bot�n de jugar, activar el HUD y desactivar el men� de inicio
        control.SetActive(false);
        startCanvas.SetActive(true);
    }

}
