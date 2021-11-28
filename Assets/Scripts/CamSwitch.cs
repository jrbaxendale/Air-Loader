
using UnityEngine;
using UnityEngine.InputSystem;

public class CamSwitch : MonoBehaviour
{
    [SerializeField]

#pragma warning disable CS0649 // Field 'CamSwitch.action' is never assigned to, and will always have its default value null
    private InputAction action;
#pragma warning restore CS0649 // Field 'CamSwitch.action' is never assigned to, and will always have its default value null

    private Animator animator;
    public bool Cam2 = true;



    private void Awake()
    {

        animator = GetComponent<Animator>();
    }


    private void OnEnable()
    {

        action.Enable();
    }


    private void OnDisable()
    {
        action.Disable();


    }

    private void Start()
    {
        action.performed += _ => SwitchState();
        Debug.Log("Camera Started");
    }

    public void SwitchState()
    {
        if (Cam2)
        {

            animator.Play("Cam1");
            Debug.Log("CAM1");
        }

        else

        {
            animator.Play("Cam2");
            Debug.Log("Cam2");
        }
        Cam2 = !Cam2;

    }



}




