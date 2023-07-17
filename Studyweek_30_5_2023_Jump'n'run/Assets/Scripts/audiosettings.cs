using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class audiosettings : MonoBehaviour
{
    #region
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private GameObject _player;
    [SerializeField] private PlayerInput _input;

    private float footStepDelay = 0.6f;
    private float nextFootStepTime = 0.6f;
    #endregion

    private void Update()
    {
        if (_player.GetComponent<movement>().moveInput.x != 0 && _player.GetComponent<movement>().isGrounded)
        {
            if(Time.time >= nextFootStepTime)
            {
                nextFootStepTime = Time.time + footStepDelay;
                _audioSource.Play();
            }
        }
    }
}
