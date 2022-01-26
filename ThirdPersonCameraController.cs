using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Modified code from: https://www.youtube.com/watch?v=7nxpDwnU0uU&ab_channel=StephenBarr

public class ThirdPersonCameraController : MonoBehaviour
{

    public float RotationSpeed = 1;
    public Transform Target, Player;

    float mouseX, mouseY;
    private bool mouseIsFrozen;

    public Transform obstruction;
    public float zoomSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        obstruction = Target;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        CamControl();
        //ViewObstructed();
    }

    private void CamControl()
    {
        if (mouseIsFrozen != true)
        {
            mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
            mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
            mouseY = Mathf.Clamp(mouseY, -35, 60);

            transform.LookAt(Target);

            Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
            Player.rotation = Quaternion.Euler(0, mouseX, 0);
        }
    }

    private void ViewObstructed()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Target.position - transform.position, out hit, 4.5f))
        {
            if(hit.collider.gameObject.tag != "Player")
            {
                obstruction = hit.transform;
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                
                if(Vector3.Distance(obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, Target.position) >= 1.5f)
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
            }
            else
            {
                obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if (Vector3.Distance(transform.position, Target.position) < 4.5f)
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
            }
        }
    }

    public void freezePlayerMouse(bool b)
    {
        if (b == true)
            mouseIsFrozen = true;
        if (b == false)
            mouseIsFrozen = false;
    }
}
