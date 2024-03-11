using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 2f;

    private void Update() => Spin();

    private void Spin()
    {
        transform.Rotate(0, 0, 360 * _rotateSpeed * Time.deltaTime);
    }
}
