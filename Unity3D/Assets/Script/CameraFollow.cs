using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /*
     per spostare la camera non basta spostarla della posizione 
     del personaggio ma anche della distanza fra 
     camera e personaggio
    */

    public Transform player;

    //differenza di posizione
    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //la telecamera segue il giocatore ad una distanza fissa
        transform.position = new Vector3(player.position.x + offset.x, offset.y, player.position.z + offset.z);

    }
}
