using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectManager : MonoBehaviour
{
    public static UnitSelectManager Instance { get; set; }
    public List<GameObject> allUnitsList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
    
}
