using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiosettings : MonoBehaviour
{
    #region
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private AudioSource _audioSource;

    private float footStepDelay = 0.5f;
    private float nextFootStepTime = 0.5f;
    #endregion

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(_rb.velocity.x != 0)
        {
            if(Time.time >= nextFootStepTime)
            {
                nextFootStepTime = Time.time + footStepDelay;
                _audioSource.Play();
            }
        }
    }
}
