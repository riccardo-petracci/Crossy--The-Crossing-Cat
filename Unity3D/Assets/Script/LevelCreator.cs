using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    //vettore per la creazione delle lane
    public GameObject[] lanes;

    //variabile temporanea per manipolazione
    GameObject tempLane;

    //la creazione parte dal punto z=2
    int zPosition = 2;

    // Start is called before the first frame update
    void Start()
    {
        //creazione Livello
        CreateLanes();
    }

    public void CreateLanes()
    {
        int i;
        for(i= zPosition; i < zPosition + 20; i++)
        {
            //creazione randomica di 20 lane
            tempLane = Instantiate(lanes[Random.Range(0, lanes.Length)], new Vector3(0, 0, i), Quaternion.identity) as GameObject;
            tempLane.transform.SetParent(gameObject.transform);
            //-1 perche altrimenti si crea un buco tra i livelli
            i += tempLane.GetComponent<NLanes>().NumberOfLanes -1;
        }

        zPosition = i;
    }
}
