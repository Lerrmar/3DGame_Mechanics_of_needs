using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int Damage = 1;
    public float FireRate = 1f;
    public float RangeShot = 30f;
    public float ForceShot = 450f;
    public ParticleSystem MuzzleFlash;
    public GameObject TargetFlash;
    public Transform BulletSpawn;
    public AudioClip ShotSFX;
    public AudioSource AudioSourceShoot;

    public Camera Camera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        AudioSourceShoot.PlayOneShot(ShotSFX);
        MuzzleFlash.Play();
        RaycastHit hit;

        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, RangeShot))
        {
            Debug.DrawLine(Camera.transform.position, hit.point, Color.red, 22f);

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ForceShot);
            }

            if (hit.collider.TryGetComponent<RifleTarget>(out RifleTarget target))
            {
                target.Health += Damage;
            }
            else Debug.Log("No game object called wibble found");

        }

    }
}
