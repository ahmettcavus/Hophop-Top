using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] helixRings;
    public GameObject helixTube;
    public GameObject scoreObject;
    private AudioSource audioSource;

    public float ySpawn = 0;
    public float ringsDistance = 4;
    public int numberOfRings = 7;

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
        audioSource.Play();
        Application.targetFrameRate = 60;
        for (int i = 0; i < numberOfRings; i++)
        {            
            SpawnRing();
        }
        Time.timeScale = 0;
    }

    public void SpawnRing()
    {
        float angle = 0;
        float random =  Random.Range(-360f, 360f);
        for (int j = 0; j < 8; j++)
        {   
                GameObject ring = Instantiate(helixRings[(j==0)?0:Random.Range(0, helixRings.Length)], transform.up * ySpawn, Quaternion.Euler(new Vector3(0, random+angle, 0)));
                ring.transform.parent = transform;
            angle += 45;
        }
        GameObject pole = Instantiate(helixTube,transform.up * ySpawn, transform.rotation);
        pole.transform.parent = transform;
        GameObject score = Instantiate(scoreObject, transform.up * ySpawn, transform.rotation);
        score.transform.parent = transform;
        ySpawn -= ringsDistance;
    }

    public void Pause(int num)
    {
        Time.timeScale = num;
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
