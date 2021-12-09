using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    private PlayerInput playerInput; //asset that has player controls
    bool on = false;
    [SerializeField] Light2D fLight;

    [SerializeField] float rotateSpeed;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (!on)
            return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, mousePos.y, 0); // ignores z position of mouse so that flashlight stays in 2d plane
        
        Vector3 targetDirection = mousePos - transform.position;

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        angle -= 90; //dont know why, but above function is off by 90 degrees so this fixes it
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }
    public void ToggleFlashlight()
    {
        if (!gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }
        on = !on;
        fLight.enabled = on;
    }
}