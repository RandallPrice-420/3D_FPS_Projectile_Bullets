using UnityEngine;


public class Gun : MonoBehaviour
{
    // Prevent warning in Unity editor.
    //#pragma warning disable 649

    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _firePosition
    //   _muzzleFlash
    //   _damage
    //   _range
    //   _camera
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    [SerializeField] private Transform  _firePosition;
    [SerializeField] private GameObject _muzzleFlash;
    [SerializeField] private float      _damage = 10.0f;
    [SerializeField] private float      _range  = 50.0f;   

    private Transform _camera;

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   Shoot()
    // -------------------------------------------------------------------------

    #region .  Shoot()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Shoot()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void Shoot()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(_camera.position, _camera.forward, out hit, _range);

        if (isHit)
        {
            GameObject muzzleFlash = Instantiate(_muzzleFlash, _firePosition.position, Quaternion.LookRotation(hit.normal));

            if (hit.collider.GetComponent<Damageable>() != null)
            {
                hit.collider.GetComponent<Damageable>().TakeDamage(_damage, hit.point, hit.normal);
                print($"Hit damageable:  {hit.collider.name}");;
            }
            else
            {
                print($"Hit something else:   {hit.collider.name}");
            }

            Destroy(muzzleFlash, 0.25f);
        }

    }   // Shoot()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Awake()
    //   OnDestroy()
    //   OnDisable()
    //   OnEnable()
    //   OnValidate()
    // -------------------------------------------------------------------------

    #region.  Awake()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Awake()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void Awake()
    {
        _camera = Camera.main.transform;

    }   // Awake()
    #endregion


    #region .  OnDestroy()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnDestroy()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnDestroy()
    {
        print("Gun destroyed.");

    }   // OnDestroy()
    #endregion


    #region .  OnDisable()  .
    // -------------------------------------------------------------------------
    //   Method.......:  OnDestroy()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    private void OnDisable()
    {
        print("Gun disabled.");

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
        print("Gun enabled.");

    }   // OnEnable()
    #endregion


    // -------------------------------------------------------------------------
    // Internal Methods:
    // -----------------
    //   StopShooting()
    // -------------------------------------------------------------------------

    #region .  StopShooting()  .
    // -------------------------------------------------------------------------
    //   Method.......:  StopShooting()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    internal void StopShooting()
    {
        print((_camera == null) ? "Camera is null." : "Stop shooting.");

    }   // StopShooting()
    #endregion


}   // class Gun
