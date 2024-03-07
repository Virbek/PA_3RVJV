using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolte : MonoBehaviour
{
    private float _fin = 10f;
    private float _tempsEcouler = 0f;
    private bool _recolter = false;
    private bool _appeller = false;


    private void Update()
    {
        if (_appeller)
        {
            OnRecolt();
        }
    }

    public void OnRecolt()
    {
        _appeller = true;
        _tempsEcouler += Time.deltaTime;
        if (_tempsEcouler >= _fin && !_recolter)
        {
            _recolter = true;
            _appeller = false;
            _tempsEcouler = 0f;
        }
    }

    public bool GetRecolte()
    {
        return _recolter;
    }

    public void SetRecolte(bool recolte)
    {
        _recolter = recolte;
    }
}
