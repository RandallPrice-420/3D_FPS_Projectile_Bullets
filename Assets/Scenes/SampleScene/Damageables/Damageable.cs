using System.Collections;
using UnityEngine;


public class Damageable : MonoBehaviour
{
    // Prevent warning in Unity editor.
    //#pragma warning disable 649

    // -------------------------------------------------------------------------
    // Private Properties:
    // -------------------
    //   _dieDelay
    //   _hitDelay
    //   _hitEffect
    //   _maxHealth
    //   _currentHealth
    // -------------------------------------------------------------------------

    #region .  Private Properties  .

    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private float      _dieDelay  = 0.5f;
    [SerializeField] private float      _hitDelay  = 0.5f;
    [SerializeField] private float      _maxHealth = 100.0f;

    private float _currentHealth;

    #endregion


    // -------------------------------------------------------------------------
    // Public Methods:
    // ---------------
    //   Die()
    //   SpawnEffect()
    //   TakeDamage()
    // -------------------------------------------------------------------------

    #region .  Die()  .
    // -------------------------------------------------------------------------
    //   Method.......:  Die()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public IEnumerator Die()
    {
        yield return new WaitForSeconds(_dieDelay);

        print($"{name} was destroyed.");
        Destroy(gameObject, 0.5f);

    }   // Die()
    #endregion


    #region .  SpawnEffect()  .
    // -------------------------------------------------------------------------
    //   Method.......:  SpawnEffect()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public IEnumerator SpawnEffect(GameObject effect, Vector3 position, Vector3 rotation, float delay)
    {
        yield return new WaitForSeconds(delay);

        Instantiate(effect, position, Quaternion.LookRotation(rotation));

    }   // SpawnEffect()
    #endregion


    #region .  TakeDamage()  .
    // -------------------------------------------------------------------------
    //   Method.......:  TakeDamage()
    //   Description..:  
    //   Parameters...:  None
    //   Returns......:  Nothing
    // -------------------------------------------------------------------------
    public void TakeDamage(float damage, Vector3 hitPosition, Vector3 hitNormal)
    {
        SpawnEffect(_hitEffect, hitPosition, hitNormal, _hitDelay);

        _currentHealth -= damage;

        if (_currentHealth <= 0.0f)
        {
            Die();
        }
        else
        {
            print($"{name} took {damage} damage.  Max health:  {_maxHealth},  Current ealth: {_currentHealth}");
        }

    }   // TakeDamage()
    #endregion


    // -------------------------------------------------------------------------
    // Private Methods:
    // ----------------
    //   Awake()
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
        _currentHealth = _maxHealth;

    }   // Awake()
    #endregion


}   // class Damageable
