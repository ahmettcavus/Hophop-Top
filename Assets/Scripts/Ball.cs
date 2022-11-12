using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    public GameObject paintSplashPrefab;
    public GameObject endScreen;
    public TextMeshProUGUI score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public GameObject graphic1;
    public AudioClip dieAudio;
    public AudioClip hiScoreAudio;
    public AudioSource music;

    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.GetContact(0).normal.y > 0)
        {
            rb.velocity = Vector3.up * jumpForce;
        }
        GameObject splash = Instantiate(paintSplashPrefab, transform.position + new Vector3(0f, -0.18f, 0f), Quaternion.Euler(new Vector3( 90, 0 , UnityEngine.Random.Range(-360f, 360f) )));
        splash.transform.SetParent(collision.gameObject.transform);

        string materialName = collision.gameObject.GetComponent<MeshRenderer>().material.name;
        
        if(materialName == "Unsafe Color (Instance)")
        {
            GameObject splash2 = Instantiate(paintSplashPrefab, transform.position + new Vector3(0f, -0.18f, 0f), Quaternion.Euler(new Vector3(90, 0, UnityEngine.Random.Range(-360f, 360f))));
            splash2.transform.localScale = new Vector3(1,1,1);
            this.gameObject.SetActive(false);
            Time.timeScale = 0;
            score.gameObject.SetActive(false);

            //PlayerPrefs.SetInt("Score", 0);
            if (Convert.ToInt32(score.text) > PlayerPrefs.GetInt("Score"))
            {
                PlayerPrefs.SetInt("Score", Convert.ToInt32(score.text));
                graphic1.SetActive(true);
                bestScoreText.GetComponent<Animator>().enabled = true;
                bestScoreText.text = "YENI EN IYI: " + PlayerPrefs.GetInt("Score");
                music.clip = hiScoreAudio;
            }
            else
            {
                bestScoreText.text = "EN IYI: " + PlayerPrefs.GetInt("Score");
                music.clip = dieAudio;
            }
            music.loop = false;
            music.Play();
            scoreText.text = "SKOR: " + score.text;
            endScreen.SetActive(true);
        }
    }
}
