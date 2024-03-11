using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Transform _playerTransform;

    private void Update() => MoveCamera();

    private void MoveCamera()
    {
        transform.position = new Vector3(_playerTransform.position.x, _playerTransform.position.y, transform.position.z);
    }
}
