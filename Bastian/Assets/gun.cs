using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float firerate = 32;

    public Camera fpsCam;


    private float nextTimeTofire = 0f;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1")&& Time.time >= nextTimeTofire)
        {
            nextTimeTofire = Time.time + 1f / firerate; 
            Shoot();
        }

    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            target target = hit.transform.GetComponent<target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

}
