using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlacerBatiment : MonoBehaviour
{
    public static PlacerBatiment Instance;
    public LayerMask groundLayerMask;
    
    private GameObject _prefBat;
    private GameObject _toBuild;

    private Camera _mainCamera;
    private Ray _ray;
    private RaycastHit _hit;
    private void Awake()
    {
        Instance = this;
        _mainCamera = Camera.main;
        _prefBat = null;
    }

    private void Update()
    {
        if (_prefBat != null)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                if(_toBuild.activeSelf) _toBuild.SetActive(false);
            }
            else if (!_toBuild.activeSelf) _toBuild.SetActive(true);
            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, 1000f, groundLayerMask)) 
            {
                if (!_toBuild.activeSelf) _toBuild.SetActive(true);
                _toBuild.transform.position = _hit.point;

                if (Input.GetMouseButtonDown(0))
                {
                    BatimentManager m = _toBuild.GetComponent<BatimentManager>();
                    if (m.hasValidPlacement)
                    {
                        m.SetPlacementMode(PlacementMode.Fixed);

                        _prefBat = null;
                        _toBuild = null;
                    }
                }
            }
            else if(_toBuild.activeSelf) _toBuild.SetActive(false);
        }
    }

    public void SetPrefBat(GameObject prefab)
    {
        _prefBat = prefab;
        _prepareBat();
    }

    private void _prepareBat()
    {
        if (_toBuild) Destroy(_toBuild);
    
        _toBuild = Instantiate(_prefBat);
        _toBuild.SetActive(false);

        BatimentManager m = _toBuild.GetComponent<BatimentManager>();
        m.isFixed = false;
        m.SetPlacementMode(PlacementMode.Valid);

    }

}

