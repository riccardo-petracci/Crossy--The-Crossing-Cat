using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager levelManager;

    private int steps;
    public int stepsToCreateMoreLanes = 12;
    private int currentSteps;

    public Text stepText;

    public Text gameOverText;

    public float restartDelay = 2f;

    //viene richiamato levelManager durante il caricamento dell'istanza dello script

    void Awake()
    {
        //si ha un solo level manager unico
        levelManager = this;
    }

    //metodo per il conteggio dei punti
    public void SetSteps()
    {
        steps++;
        stepText.text = steps.ToString();
        currentSteps++;

        //permette di aggiungere linee progredendo con il livello
        if(currentSteps > stepsToCreateMoreLanes)
        {
            currentSteps = 0;
            GetComponent<LevelCreator>().CreateLanes();
        }
    }

    //fine della partita e ricarica del gioco
    public void GameOver()
    {
        //compare il testo del game over con il punteggio raggiunto
        gameOverText.text = "Game Over \nPunteggio: " + steps.ToString();

        //viene ricaricata la scena dopo secondi impostati da restartDelay
        Invoke("Restart", restartDelay);
    }

    public void GameOverBack()
    {
        //compare il testo del game over con il punteggio raggiunto
        gameOverText.text = "Game Over \nNon puoi tornare \n troppo indietro \nPunteggio: " + steps.ToString();

        //viene ricaricata la scena dopo secondi impostati da restartDelay
        Invoke("Restart", restartDelay + 1f);
    }

    //ricarica la scena
    void Restart()
    {
        //l'idea e' di ricaricare la scena di gioco invece del menu che puo' essere richiamato con il tasto escape
        SceneManager.LoadScene("Scena di Gioco");
    }

    //viene caricato il menu principale
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu Principale");
    }
}
