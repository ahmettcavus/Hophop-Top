using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameObject paintSplashPrefab;

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.up * jumpForce;
        GameObject splash = Instantiate(paintSplashPrefab, transform.position + new Vector3(0f, -0.2f, 0f), Quaternion.Euler(new Vector3( 90, 0 , Random.Range(-360f, 360f) )));
        splash.transform.SetParent(collision.gameObject.transform);

        string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe Color (Instance)")
        {

        }
        else if(materialName == "Unsafe Color (Instance)")
        {

        }
        else if(materialName == "LastRing (Instance)")
        {

        }
    }
}
