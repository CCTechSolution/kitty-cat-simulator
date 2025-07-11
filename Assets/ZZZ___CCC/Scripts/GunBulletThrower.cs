using UnityEngine;

public class GunBulletThrower : MonoBehaviour
{
    [SerializeField] float throwForce;
    [SerializeField] Transform nozzle;
    [SerializeField] GameObject fireBullet;
    [SerializeField] GameObject shockBullet;
    [SerializeField] GameObject beeBullet;

    void Shoot(GameObject gb)
    {
        GameObject bullet = Instantiate(gb,nozzle.position,Quaternion.identity);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(nozzle.forward * throwForce, ForceMode.Impulse);
    }

    public void ShootFireBullet()
    {
        Shoot(fireBullet);
    }
    public void ShootShockBullet()
    {
        Shoot(shockBullet);
    }
    public void ShootBeeBUllet()
    {
        Shoot(beeBullet);
    }
}
