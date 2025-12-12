using UnityEngine;


public class InputManager : MonoBehaviour
{
    // Prevent warning in Unity editor.
    //#pragma warning disable 649

    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _gun
    //   _movement
    //   _mouseLook
    //   _rayOrigin
    //   _rayLength
    //   _horizontalInput
    //   _mouseInput
    //   _controls
    //   _groundMovement
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    [SerializeField] private Gun       _gun;
    [SerializeField] private Movement  _movement;
    [SerializeField] private MouseLook _mouseLook;
    [SerializeField] private Transform _rayOrigin;
    [SerializeField] private float     _rayLength = 58.5f;

    private Vector2        _horizontalInput;
    private Vector2        _mouseInput;
    private PlayerControls _controls;
    private PlayerControls.GroundMovementActions _groundMovement;

    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Awake()
    //   OnDisable()
    //   OnEnable()
    //   Update()
    // -------------------------------------------------------------------------

    #region .  Awake()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Awake()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Awake()
    {
        _controls       = new PlayerControls();
        _groundMovement = _controls.GroundMovement;

        _groundMovement.HorizontalMovement.performed += ctx => _horizontalInput = ctx.ReadValue<Vector2>();
        _groundMovement.Jump.performed               += ctx => _movement.OnJumpPressed();

        _groundMovement.MouseX.performed             += ctx => _mouseInput.x = ctx.ReadValue<float>();
        _groundMovement.MouseY.performed             += ctx => _mouseInput.y = ctx.ReadValue<float>();

        _groundMovement.Shoot.performed              += ctx => _gun.Shoot();
        //_groundMovement.Shoot.canceled               += ctx => _gun.StopShooting();

    }   // Awake()
    #endregion


    #region .  OnDisable()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnDisable()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnDisable()
    {
        _controls.Disable();

    }   // OnDisable()
    #endregion


    #region .  OnEnable()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnEnable()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnEnable()
    {
        _controls.Enable();

    }   // OnEnable()
    #endregion


    #region .  Update()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Update()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Update()
    {
        _movement .ReceiveInput(_horizontalInput);
        _mouseLook.ReceiveInput(_mouseInput);

        Ray ray = new Ray(_gun.transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.yellow);

    }   // Update()
    #endregion


}   // class InputManager
