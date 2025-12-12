using UnityEngine;


namespace ProjectileBullets
{
    public class Gun : MonoBehaviour
    {
        public float       Accuracy;
        public float       CooldownSpeed;
        public float       FireRate;
        public float       MaxSpreadAngle;
        public float       RecoilCooldown;
        public float       TimeTillMaxSpread;
        public GameObject  Bullet;
        public GameObject  ShootPoint;
        public AudioSource Gunshot;
        public AudioClip   SingleShot;


        private void OnDrawGizmos()
        {
            // Draw a line from the fire point to the direction of the bullet
            Gizmos.color = Color.red;
            Gizmos.DrawLine(this.ShootPoint.transform.position, this.ShootPoint.transform.position + this.ShootPoint.transform.forward * 10);

        }   // OnDrawGizmos()


        private void OnGUI()
        {
            // Display the fire rate on the screen
            GUI.Label(new Rect(10, 10, 200, 20), "Fire Rate: " + this.FireRate);

        }   // OnGUI()


        private void OnValidate()
        {
            // Ensure the fire rate is positive
            if (this.FireRate <= 0.0f)
            {
                this.FireRate = 0.1f;
            }

        }   // OnValidate()


        private void Shoot()
        {
            RaycastHit   hit;
            Quaternion   fireRotation = Quaternion.LookRotation(this.transform.forward);
            float        currentSpeed = Mathf.Lerp(0.0f, this.MaxSpreadAngle, this.Accuracy / this.TimeTillMaxSpread);

            fireRotation = Quaternion.RotateTowards(fireRotation, Random.rotation, Random.Range(0.0f, currentSpeed));

            if (Physics.Raycast(this.transform.position, fireRotation * Vector3.forward, out hit, Mathf.Infinity))
            {
                GameObject bullet = Instantiate(this.Bullet, this.ShootPoint.transform.position, fireRotation);
                bullet.GetComponent<MoveBullet>().HitPoint = hit.point;
            }

        }   // Shoot()


        private void Update()
        {
            this.CooldownSpeed += 60.0f * Time.deltaTime;

            if (Input.GetMouseButton(0))
            {
                this.Accuracy += 4.0f * Time.deltaTime;

                if (this.CooldownSpeed >= this.FireRate)
                {
                    this.Shoot();
                    this.Gunshot.PlayOneShot(this.SingleShot);
                    this.CooldownSpeed = 0.0f;
                    this.RecoilCooldown = 1.0f;
                }
            }
            else
            {
                this.RecoilCooldown -= Time.deltaTime;
                if (this.RecoilCooldown <= 0.0f)
                {
                    this.Accuracy = 0.0f;
                }
            }

        }   // Update()


    }   // class Gun

}   // namespace ProjectileBullets