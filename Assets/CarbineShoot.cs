using UnityEngine;

public class CarbineShoot : MonoBehaviour
{
    [SerializeField]
    private float range = 100f;             // Maximum range of the raycast

    [SerializeField]
    private Camera fpsCamera;               // Reference to the player's camera

    [SerializeField]
    private float fireRate = 15f;           // Bullets per second

    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        Vector3 rayOrigin = fpsCamera.transform.position;
        Vector3 rayDirection = fpsCamera.transform.forward;

        Debug.DrawRay(rayOrigin, rayDirection * range, Color.yellow, 1f);

        if (Physics.Raycast(rayOrigin, rayDirection, out hit, range))
        {
            Debug.Log("I hit an object");
        }
    }
}
