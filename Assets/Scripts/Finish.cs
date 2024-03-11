using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource _finishSound;

    private bool _levelCompleted;
    
    private void CompleteLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
    private void Start()
    {
        _finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !_levelCompleted)
        {
            _finishSound.Play();
            _levelCompleted = true;
            Invoke("CompleteLevel", 1f);
        }
    }

}
