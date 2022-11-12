using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static Unity.VisualScripting.Member;

public class ScoreCollider : MonoBehaviour
{
    public GameObject scoreObject;
    public TextMeshProUGUI scoreText;
    private AudioSource source;
    private int score = 0;


    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Score")
        {
            AddScore(1);
            source.Play();
        }
    }

    public void AddScore(int scorePerRing)
    {
        score += scorePerRing;
        scoreText.text = score.ToString();
    }
}
