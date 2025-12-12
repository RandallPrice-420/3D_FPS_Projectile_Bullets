using UnityEngine;


public class MouseLook : MonoBehaviour
{
    // Prevent warning in Unity editor.
    //#pragma warning disable 649

    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _sensivityX
    //   _sensivityY
    //   _xClamp
    //   _playerCamera
    //   _mouseX
    //   _mouseY
    //   _xRotation
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    [SerializeField] float     _sensivityX =  8.0f;
    [SerializeField] float     _sensivityY =  0.5f;
    [SerializeField] float     _xClamp     = 85.0f;
    [SerializeField] Transform _playerCamera;

    private float _mouseX;
    private float _mouseY;
    private float _xRotation = 0.0f;

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   ReceiveInput()
    // -------------------------------------------------------------------------

    #region .  OnJumpPressed()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnJumpPressed()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void ReceiveInput(Vector2 mouseInput)
    {
        _mouseX = mouseInput.x * _sensivityX;
        _mouseY = mouseInput.y * _sensivityY;

    }   // ReceiveInput()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Start()  --  COMMENTED OUT
    //   Update()
    // -------------------------------------------------------------------------

    #region .  Start()  --  COMMENTED OUT  .
    // -------------------------------------------------------------------------
    //   Method.......:  Start()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;

    }   // Start()
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
        transform.Rotate(Vector3.up, _mouseX * Time.deltaTime);

        _xRotation -= _mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -_xClamp, _xClamp);

        Vector3 targetRotation = transform.eulerAngles;
        targetRotation.x = _xRotation;

        _playerCamera.eulerAngles = targetRotation;

    }   // Update()
    #endregion


}   // class MouseLook
