using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float vitDep = 5.0f;

    public float rotationVit = 50.0f;

    public  Camera mainCamera;

    public List<GameObject> human = new List<GameObject>();
    private List<GameObject> _humanRecolte = new List<GameObject>();
    private int _fer;
    private List<GameObject> _objSelect = new List<GameObject>();
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _fer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var moveDirection = new Vector3(horizontal, 0.0f, vertical).normalized;

        transform.Translate(moveDirection* ( vitDep *  Time.deltaTime));
        //positioner la caméra a la position de l'objet
        mainCamera.transform.position = new Vector3(pos.x, pos.y, pos.z);
        
        if (Input.GetMouseButtonDown(0))
        {
            
            _objSelect.Clear();
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                _objSelect.Add(hit.collider.gameObject);
                PerformSelection();
            }
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -rotationVit * Time.deltaTime);
            transform.eulerAngles= new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0.0f);
            mainCamera.transform.Rotate(Vector3.up, -rotationVit * Time.deltaTime);
            mainCamera.transform.eulerAngles = new Vector3(mainCamera.transform.eulerAngles.x,
                mainCamera.transform.eulerAngles.y, 0.0f);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, rotationVit * Time.deltaTime);
            transform.eulerAngles= new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0.0f);
            mainCamera.transform.Rotate(Vector3.up, rotationVit * Time.deltaTime);
            mainCamera.transform.eulerAngles = new Vector3(mainCamera.transform.eulerAngles.x,
                mainCamera.transform.eulerAngles.y, 0.0f);
        }
        
    }
    
    void PerformSelection()
    {
        foreach (GameObject obj in _objSelect)
        {
            
            var deplacementComponent = obj.GetComponent<Deplacement>();

            if (deplacementComponent)
            {
                deplacementComponent.SelectedTrue();
            }
        }
    }

    public void RecupererFer(GameObject recolteur)
    {
        if (human.Count != 0)
        {
            _humanRecolte.Add(recolteur);
            human.Remove(recolteur);
            recolteur.GetComponent<Renderer>().enabled = false;
            recolteur.GetComponent<Deplacement>().SelectedFalse();
            recolteur.GetComponent<Recolte>().OnRecolt();
        }

        if (recolteur.GetComponent<Recolte>().GetRecolte())
        {
            Debug.Log("Fer recolter");
            _fer += 200;
            human.Add(recolteur);
            _humanRecolte.Remove(recolteur);
            recolteur.GetComponent<Renderer>().enabled = true;
            recolteur.transform.Translate(-transform.forward * 2f);
        }
    }





}
    

