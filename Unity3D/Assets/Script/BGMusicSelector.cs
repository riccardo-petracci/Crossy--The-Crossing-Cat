using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicSelector : MonoBehaviour
{
    //creazione campi per inserire le canzoni
    public AudioSource track1;

    public AudioSource track2;

    public AudioSource track3;

    //variabile intera per selezionare le tracce audio
    int trackSelector;

    //variabile intera che permette di memorizzare lo storico delle tracce audio
    int trackHistory;

    // al primo frame viene creato il selettore delle tracce audio
    void Start()
    {
        TrackSelector();
    }

    // ad ogni frame viene controllato l'andamento audio
    void Update()
    {
        if(track1.isPlaying == false && track2.isPlaying == false && track3.isPlaying == false)
        {
            TrackSelector();
        }
        
    }

    //metodo che permette la gestione della riproduzione delle tracce audio
    //andando a cambiare la lo storico delle tracce eseguite per evitare 
    //che la stessa traccia audio venga ripetuta consecutivamente
    void TrackSelector()
    {
        trackSelector = Random.Range(0, 3);

        if (trackSelector == 0 && trackHistory != 1)
        {
            track1.Play();
            trackHistory = 1;
        }
        else if (trackSelector == 1  && trackHistory != 2)
        {
            track2.Play();
            trackHistory = 2;
        }
        else if (trackSelector == 2 && trackHistory != 3)
        {
            track3.Play();
            trackHistory = 3;
        }
    }
}
