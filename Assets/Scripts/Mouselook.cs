using UnityEngine.UI;
using UnityEngine;
using Yarn.Unity;

public class Mouselook : MonoBehaviour
{
    public float mouse_sensitivity;
    private float sensitivity_scale = 10f;
    public Transform playerbody;
    private Camera cam;
    public Image cursor;
    public float xRot = 0f;



    void Start()
    {
        cam = GetComponent<Camera>();
        SetCursorLock(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouse_x = Input.GetAxis("Mouse X") * (mouse_sensitivity * Time.deltaTime);
        float mouse_y = Input.GetAxis("Mouse Y") * (mouse_sensitivity * Time.deltaTime);

        xRot -= mouse_y;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        if (Cursor.lockState == CursorLockMode.Locked)
        {
            cam.transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
            playerbody.Rotate(Vector3.up * mouse_x);
        }

        //hitting interactable
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if(interactable != null && interactable.CanBeInteractedWith())
            {             
                HUD.Instance.IsHighlightingInteractable = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                     interactable.Invoke("Activate",0);
                }
            }
            else
            {
                HUD.Instance.IsHighlightingInteractable = false;
            }
        }
    

        //update control sensitivity
        mouse_sensitivity += Input.mouseScrollDelta.y * sensitivity_scale;
        mouse_sensitivity = Mathf.Clamp(mouse_sensitivity, 0, 10000000);

    }
    [YarnCommand("set_cursor")]
    public void SetCursorLock(bool val)
    {

        if (val) //locked
        {

            Cursor.lockState = CursorLockMode.Locked;
            cursor.enabled = true;
            Cursor.visible = false;
        }
        else //free
        {
            Cursor.lockState = CursorLockMode.Confined;
            cursor.enabled = false;
            Cursor.visible = true;

        }
    }
}
