using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class audiosettings : MonoBehaviour
{
    #region
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerInput _input;

    private float footStepDelay = 0.6f;
    private float nextFootStepTime = 0.6f;
    #endregion

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (_player.GetComponent<movement>().moveInput.x != 0)
        {
            if(Time.time >= nextFootStepTime)
            {
                nextFootStepTime = Time.time + footStepDelay;
                _audioSource.Play();
            }
        }
    }
}
