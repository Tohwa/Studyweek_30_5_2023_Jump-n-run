using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class deactivateShroom : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _shroom;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _Wall;
    [SerializeField] private GameObject _notification;

    private bool checkShroomEaten;
    private bool checkKeyTaken;
    public static bool waitForResponse;
    [SerializeField] private bool clicked;

    #endregion

    void Start()
    {
        _notification.SetActive(false);
    }

    void Update()
    {
        checkShroomEaten = _player.gameObject.GetComponent<Interaction>().shroomEaten;
        checkKeyTaken = _player.gameObject.GetComponent<Interaction>().keyTaken;       

        if(clicked && waitForResponse)
        {
            NoLongerWaiting();
        }

        if (checkKeyTaken)
        {
            _key.SetActive(false);
        }
    }

    public void OnResponse(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            clicked = true;
        }
        
    }

    public void Waiting()
    {
        _shroom.SetActive(false);
        _notification.SetActive(true);
        Time.timeScale = 0f;
        waitForResponse = true;
    }

    private void NoLongerWaiting()
    {
        _notification.SetActive(false);
        Time.timeScale = 1f;
        waitForResponse = false;
        clicked = false;
    }
}
