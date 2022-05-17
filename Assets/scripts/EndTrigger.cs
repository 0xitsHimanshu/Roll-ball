using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    private GameObject player;

    void Start() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

     void OnTriggerEnter ( )
    {
        gameManager.CompletedLevel();

       Rigidbody rigid = player.GetComponent<Rigidbody>();
        rigid.constraints = RigidbodyConstraints.FreezePosition;

    }
}
