using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private PlayerMovement player;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponent<PlayerMovement>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") && player.playerState == DeadState.alive)
        {
            Die();
        }

    }

    private void Die()
    {
        deathSoundEffect.Play();
        player.playerState = DeadState.dead;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
