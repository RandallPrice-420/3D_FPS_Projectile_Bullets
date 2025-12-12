using UnityEngine;


namespace ProjectileBullets
{
    public class Health : MonoBehaviour
    {
        public int CurrentHealth;


        private void Update()
        {
            if (this.CurrentHealth <= 0)
            {
                Destroy(this.gameObject);
            }

        }   // Update()


    }   // class Health

}   // namespace ProjectileBullets
