using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameManager gameManagerScript;
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Cylinder")
        {
            gameManagerScript.SpawnRing();
        }
        Destroy(collision.gameObject);
    }
}
