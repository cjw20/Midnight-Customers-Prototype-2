using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlashLight : MonoBehaviour
{
    private PlayerInput playerInput; //asset that has player controls
    bool on = false;
    [SerializeField] Light2D fLight;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleFlashlight()
    {
        on = !on;
        fLight.enabled = on;
        

    }
}
