using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody rb;

    //forza per saltare
    public float jumpforce = 112f;

    //variabile che ci permette di capire se il player e in contatto con il terreno
    public float groundCheckDistance = 0.3f;

    //con questa variabile evitiamo che il movimento venga cliccato 
    private bool isGrounded = false;

    //creiamo il player morto
    public GameObject playerDead;

    //variabile che tiene traccia dei passi fatti indietro
    private int backSteps = 0;

    // Start is called before the first frame update
    void Start() {

        rb = GetComponent<Rigidbody>();

    }
    

    // Update is called once per frame
    void Update()
    {
        //verifichiamo se il player viene in contatto con il terreno
        if(Physics.Raycast((transform.position + Vector3.up * 0.1f), Vector3.down, groundCheckDistance)){
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        //viene permesso lo spostamento solo se il player tocca il terreno e
        //puo muoversi nelle 4 direzioni

        if(isGrounded)
        { 
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(backSteps > 0)
                {
                    backSteps -= 1;
                }
                           
                AdjustPositionRotation(new Vector3(0, 0, 0));
                rb.AddForce(new Vector3(0, jumpforce, jumpforce));
                  
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                //il player non puo tornare 3 volte consegutive
                //indietro altrimenti perde la partita
                backSteps += 1;

                if (backSteps == 3)
                {
                    GameOverBack();
                }

                AdjustPositionRotation(new Vector3(0, -180, 0));
                rb.AddForce(new Vector3(0, jumpforce, -jumpforce));
                

            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                AdjustPositionRotation(new Vector3(0, -90, 0));
                rb.AddForce(new Vector3(-jumpforce, jumpforce, 0));

            }

            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                AdjustPositionRotation(new Vector3(0, 90, 0));
                rb.AddForce(new Vector3(jumpforce, jumpforce, 0));

            }
        }

        //nel caso in cui il player dovesse scendere sotto il terreno di gioco
        //termina la partita

        if(rb.position.y < 0f)
        {
            GameOverBack();
        }

        //se il player vuole interrompere
        //la partita e tornare al menu principale deve schiacciare il tasto ESC

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
            LevelManager.levelManager.MainMenu();
        }


    }

    /* permette di far spostare il player correttamente
       metodo richiamato per l'appunto nel metodo
       del movimento del player
    */
   
    void AdjustPositionRotation (Vector3 newRotation)
    {
        //annulla la velocità che potrebbe accumularsi
        rb.velocity = Vector3.zero;
        //permette la corretta rotazione del player
        transform.eulerAngles = newRotation;
        //permette al player di spostarsi correttamente di unità intere e non float
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Round(transform.position.z));
    }

    //richiamato quando l'oggetto Collider entra in contatto con il trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StepTrigger"))
        {
            //viene richiamato il metodo per aggiungere i passi
            //e viene distrutto lo step appena superato

            LevelManager.levelManager.SetSteps();
            Destroy(other.gameObject);
        }

        //al contatto con i bordi esterni il player muore

        if (other.CompareTag("Ostacolo"))
        {
            GameOver();
        }
    }

    //richiamato quando il collider/rigidbody entra in contatto con un altro rigidbody/collider

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ostacolo"))
        {
            //al contatto con macchine o cespugli il player muore

            GameOver();
        }
    }

    //metodo che viene richiamato quando il player va troppo indietro

    void GameOverBack()
    {
        rb.AddForce(0, 1000, 0);

        //gameObject.SetActive(false);
        LevelManager.levelManager.GameOverBack();

    }

    //definisce la fine della partita

    void GameOver()
    {
        Instantiate(playerDead, transform.position, transform.rotation);
        gameObject.SetActive(false);
        LevelManager.levelManager.GameOver();

    }
}
