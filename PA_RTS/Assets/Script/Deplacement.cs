using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Deplacement : MonoBehaviour
{
    public float vitDep = 5.0f;
    private bool _selected = false;
    private bool _move = false;
    private Vector3 _positionClic ;
    
    

    // Update is called once per frame
    private void Update()
    {
        if (_selected)
        {
            if (Input.GetMouseButtonDown(1))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var objToucher = hit.collider.gameObject;
                    if (objToucher.CompareTag("sol") || objToucher.CompareTag("fer"))
                    {
                        _positionClic = hit.point;
                        _move = true;
                    }
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                _selected = false;
            }
        }

        if (_move)
        {
            
            MoveToPosition(_positionClic);
            if (transform.position == _positionClic)
            {
                _move = false;
            }
        }
    }

    public void SelectedTrue()
    {
        _selected = true;
    }
    
    public void SelectedFalse()
    {
        _selected = false;
        _move = false;
    }
    
    private void MoveToPosition(Vector3 targetPosition)
    {
        var direction = targetPosition - transform.position;
        direction.y = 0.0f;
        direction.Normalize();
        transform.Translate(direction * (vitDep * Time.deltaTime));
    }
}
  
