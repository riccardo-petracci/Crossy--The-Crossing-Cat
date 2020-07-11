using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    //metodi che permettono il caricamento delle scene di gioco

    //starta la partita
    public void PlayGame()
    {
        SceneManager.LoadScene("Scena Di Gioco");
    }

    //chiude il gioco
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
