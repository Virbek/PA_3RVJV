
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float vitDep = 5.0f;

    public float rotationVit = 50.0f;

    public  Camera mainCamera;
  
    private int _pion;
    // Start is called before the first frame update
    void Start()
    {
        _pion = 0;
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
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                var objToucher = hit.collider.gameObject;
                _pion = _pion + 1;
                var deplacementComponent = objToucher.GetComponent<Deplacement>();

                if (deplacementComponent)
                {
                    deplacementComponent.SelectedTrue();
                }
            }
        }
        
        if (Input.GetKey(KeyCode.Q))
        {
            mainCamera.transform.Rotate(Vector3.up, -rotationVit * Time.deltaTime);
            mainCamera.transform.eulerAngles = new Vector3(mainCamera.transform.eulerAngles.x,
                mainCamera.transform.eulerAngles.y, 0.0f);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            mainCamera.transform.Rotate(Vector3.up, rotationVit * Time.deltaTime);
            mainCamera.transform.eulerAngles = new Vector3(mainCamera.transform.eulerAngles.x,
                mainCamera.transform.eulerAngles.y, 0.0f);
        }
        
    }
}
