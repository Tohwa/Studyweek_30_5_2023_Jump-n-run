using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AudioSettings : MonoBehaviour
{
    #region
    [Header("Components")]
    [SerializeField] private AudioSource _audioSource;

    [Header("Scripts")]
    [SerializeField] private InputManager _input;
    [SerializeField] private GameManager _manager;

    private float footStepDelay = 0.6f;
    private float nextFootStepTime = 0.6f;
    #endregion

    private void Update()
    {
        if (_input.moveInput.x != 0 && _manager.grounded)
        {
            if(Time.time >= nextFootStepTime)
            {
                nextFootStepTime = Time.time + footStepDelay;
                _audioSource.Play();
            }
        }
    }
}
