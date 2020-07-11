using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGame : MonoBehaviour
{
    /*metodo invocato al primo frame che permette 
    di caricare la scena del menu da cui potranno essere
    disponibili le opzioni del gioco*/

    void Start()
    {
        LevelManager.levelManager.MainMenu();   
    }
}
