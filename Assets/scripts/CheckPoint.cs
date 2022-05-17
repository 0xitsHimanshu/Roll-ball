using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] List<GameObject> CheckPoints;
    [SerializeField] GameObject player;
    [SerializeField] Vector3 vectorpoints;
    [SerializeField] float Dead;


    Vector3 RespawnPoint;

    

    private void Update()
    {
        if (player.transform.position.y < -Dead)
        {
           player.transform.position = vectorpoints;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        vectorpoints = player.transform.position;
        Destroy(other.gameObject);
       
    }

}
