using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb;
    public Transform wallDetector, FloorDetector;
    public LayerMask ground;
    bool facingLeft;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (Physics2D.OverlapCircle(wallDetector.position, 0.05f, ground) || Physics2D.OverlapCircle(FloorDetector.position, 0.05f, ground) == null)
        {
            facingLeft = !facingLeft;
            if (facingLeft)
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }
}



