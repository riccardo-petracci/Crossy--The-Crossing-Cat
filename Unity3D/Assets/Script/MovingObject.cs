using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    //variabile per la velocita massima e minima degli oggetti
    public float minSpeed, maxSpeed;

    //variabile per il corpo rigido
    private Rigidbody rb;

    //vettore 3D per le nuove velocita
    private Vector3 newVelocity;

    // Start is called before the first frame update
    void Start()
    {
        //prendiamo il corpo rigido
        rb = GetComponent<Rigidbody>();

        //in maniera randomica assegnamo velocita iniziale agli oggetti sull'asse X
        newVelocity = new Vector3(Random.Range(minSpeed, maxSpeed),0,0);

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //assegnazione nuova velocita
        rb.velocity = newVelocity;
    }
}
