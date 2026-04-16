using UnityEngine;

public class Minigun : MonoBehaviour
{
    
    //bullet
    public GameObject bullet;
    
    //bullet force
    public float shootForce;
    public float upwardForce;
    
    //Gun stats
    public float timeBetweenShots;
    public float timeBetweenShooting;
    public float spread;
    public float reloadTime;
    
    public int magazineSize;
    public int bulletPerTap;
    public bool allowButtonHold;

    private int bulletsLeft;
    private int bulletsShot;
    
    //bools
    private bool shooting;
    private bool readyToShoot;
    private bool reloading;
    
    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    private void Awake()
    {
        //make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();
    }

    private void MyInput()
    {
        //Check if allowed to hold button and take corresponding input
        if (allowButtonHold)
        {
            shooting = Input.GetButton("Fire1");
        }
        else
        {
            shooting = Input.GetButtonDown("Fire1");
        }
        
        //shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            //Set bullets to 0
            bulletsShot = 0;
            Shoot();
        }
        
    }

    private void Shoot()
    {
        readyToShoot = false;
        
        bulletsLeft--;
        bulletsShot++;
    }
}
