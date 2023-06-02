using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameralock : MonoBehaviour
{
    #region
    [SerializeField] private GameObject _player;
    [SerializeField] private Collider2D _playableArea;

    private float cameraHalfHeight;
    private float cameraHalfWidth;
    #endregion

    private void Start()
    {
        Camera _camera = GetComponent<Camera>();
        cameraHalfHeight = _camera.orthographicSize;
        cameraHalfWidth = _camera.orthographicSize * _camera.aspect;
    }

    private void LateUpdate()
    {
        Vector3 playerPosition = _player.transform.position;

        float clampedX = Mathf.Clamp(playerPosition.x, _playableArea.bounds.min.x + cameraHalfWidth, _playableArea.bounds.max.x - cameraHalfWidth);
        float clampedY = Mathf.Clamp(playerPosition.y, _playableArea.bounds.min.y + cameraHalfHeight, _playableArea.bounds.max.y - cameraHalfHeight);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
