using UnityEngine;


public class Movement : MonoBehaviour
{
    // Prevent warning in Unity editor.
    //#pragma warning disable 649

    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _controller
    //   _groundMask
    //   _clamp
    //   _gravity
    //   _jumpHeight
    //   _speed
    //   _isGrounded
    //   _jump
    //   _horizontalInput
    //   _verticalVelocity
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    [SerializeField] private CharacterController _controller;
    [SerializeField] private LayerMask           _groundMask;
    [SerializeField] private Transform           _player;
    [SerializeField] private float               _clamp      =  30.0f;
    [SerializeField] private float               _gravity    = -30.0f;
    [SerializeField] private float               _jumpHeight =   3.5f;
    [SerializeField] private float               _speed      =  11.0f;

    private bool    _isGrounded;
    private bool    _jump;
    private Vector2 _horizontalInput;
    private Vector3 _verticalVelocity;

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   OnJumpPressed()
    //   ReceiveInput()
    // -------------------------------------------------------------------------

    #region .  OnJumpPressed()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnJumpPressed()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void OnJumpPressed()
    {
        _jump = true;

    }   // OnJumpPressed()
    #endregion


    #region .  ReceiveInput()  .
    // -------------------------------------------------------------------------
    //   Method.......:  ReceiveInput()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void ReceiveInput(Vector2 horizontalInput)
    {
        _horizontalInput = horizontalInput;

    }   // ReceiveInput()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Update()
    // -------------------------------------------------------------------------

    #region .  Update()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Update()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Update()
    {
        _isGrounded = Physics.CheckSphere(transform.position, 0.1F, _groundMask);
        if (_isGrounded)
        {
            _verticalVelocity.y = 0f;
        }

        if (_player.position.x > -_clamp && _player.position.x < _clamp)
        {
            Vector3 horizontalVelocity = (transform.right * _horizontalInput.x + transform.forward * _horizontalInput.y) * _speed;
            _controller.Move(horizontalVelocity * Time.deltaTime);
        }

        if (_jump)
        {
            if (_isGrounded)
            {
                _verticalVelocity.y = Mathf.Sqrt(-2.0f * _jumpHeight * _gravity);
            }

            _jump = false;
        }

        _verticalVelocity.y += _gravity * Time.deltaTime;
        _controller.Move(_verticalVelocity * Time.deltaTime);

    }   // Update()
    #endregion


}   // class Movement
