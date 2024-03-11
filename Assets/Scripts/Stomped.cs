using UnityEngine;

public class Stomped : MonoBehaviour
{
    [SerializeField] private float _force;

    private void OnTriggerEnter2D(Collider2D trigger)
    { 
        if (trigger.CompareTag("Player"))
        {
            Rigidbody2D playerRigidbody = trigger.GetComponent<Rigidbody2D>();
            playerRigidbody.AddForce(Vector2.up * _force);
            BoxCollider2D boxCollider = transform.parent.GetComponent<BoxCollider2D>();
            boxCollider.enabled = false;
        }
    }

   private void OnBecameInvisible()
   {
        Destroy(transform.parent.gameObject);
   }
}
