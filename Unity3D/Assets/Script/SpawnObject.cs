using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    //variabile object per permettere lo spawn degli oggetti
    public GameObject[] objects;

    //tempo minimo e massimo per lo spawn degli oggetti
    public float minSpawnTime, maxSpawntime;

    //variabile booleana per differenziare gli oggetti dinamici da quelli statici
    public bool spawnMovingObjects = false;


    // Start is called before the first frame update
    void Start()
    {
        if (spawnMovingObjects)
        {
            SpawnMovingObjects();
        }
        else
        {
            SpawnStaticObjects();
        }
        
    }

    //metodo per lo spawn casuale dei veicoli

    void SpawnMovingObjects()
    {
        //vengono clonati gli oggetti originali ritornando dei cloni
        Instantiate(objects[Random.Range(0, objects.Length)], transform);

        //viene invocato il metodo in un range randomico delimitato da un tempo minimo e massimo
        Invoke("SpawnMovingObjects", Random.Range(minSpawnTime, maxSpawntime));

    }

    //metodo per lo spawn casuale degli oggetti 

    void SpawnStaticObjects()
    {
        for (int i = 0; i < 3; i++)
        {
            //istanziati un gameobject randomico tra 0 e object.length con vettore di pozioni e rotazioni
            Instantiate(objects[Random.Range(0, objects.Length)], new Vector3(Random.Range(-5, 5), 0.5f, transform.position.z), Quaternion.identity);
        }

    }
}
