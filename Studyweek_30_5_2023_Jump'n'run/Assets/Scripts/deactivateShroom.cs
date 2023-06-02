using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivateShroom : MonoBehaviour
{
    #region Fields

    [SerializeField] private GameObject _shroom;
    [SerializeField] private GameObject _key;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _Wall;

    private bool checkShroomEaten;
    private bool checkKeyTaken;

    #endregion

    // Update is called once per frame
    void Update()
    {
        checkShroomEaten = _player.gameObject.GetComponent<Interaction>().shroomEaten;
        checkKeyTaken = _player.gameObject.GetComponent<Interaction>().keyTaken;

        if (checkShroomEaten)
        {
            _shroom.SetActive(false);
        }

        if (checkKeyTaken)
        {
            _key.SetActive(false);
        }
    }
}
