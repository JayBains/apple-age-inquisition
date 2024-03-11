using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] private Transform _wallDetector;
    [SerializeField] private Transform _floorDetector;
    [SerializeField] private LayerMask _groundMask;
    
    private bool _isFacingLeft;

    void Update()
    {
        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime);
        if (Physics2D.OverlapCircle(_wallDetector.position, 0.05f, _groundMask) || Physics2D.OverlapCircle(_floorDetector.position, 0.05f, _groundMask) == null)
        {
            _isFacingLeft = !_isFacingLeft;
            gameObject.transform.rotation = Quaternion.Euler(0, _isFacingLeft ? 0 : 180, 0);
        }
    }
}



