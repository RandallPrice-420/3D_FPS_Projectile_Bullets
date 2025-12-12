using UnityEngine;


namespace ProjectileBullets
{
    public class MoveBullet : MonoBehaviour
    {
        public Vector3    HitPoint;
        public GameObject Dirt;
        public GameObject Blood;
        public int        Speed;


        private void Start()
        {
            this.GetComponent<Rigidbody>().AddForce((this.HitPoint - this.transform.position).normalized * this.Speed);
        }


        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                GameObject blood = Instantiate(this.Blood, this.transform.position, this.transform.rotation);
                blood.transform.parent = collision.transform;
                Destroy(this.gameObject);
            }
            else
            {
                Instantiate(this.Dirt, this.transform.position, this.transform.rotation);
                Destroy(this.gameObject);
            }

            Destroy(this.gameObject);
        }   // OnCollisionEnter()


    }   // class MoveBullet

}   // namespace ProjectileBullets
