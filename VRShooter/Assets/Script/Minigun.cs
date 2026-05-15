using UnityEngine;
using UnityEngine.XR;
using System.Collections;

public class RaycastGun : MonoBehaviour
{
    public Transform firePoint;
    public float range = 100f;

    public VRHudManager hudManager;

    public XRNode controllerNode = XRNode.RightHand;

    // Laser
    public LineRenderer laserLine;

    // How long laser stays visible
    public float laserDuration = 0.05f;

    private InputDevice device;

    private bool wasPressedLastFrame = false;

    public AudioSource shoot;
    public AudioSource explode;

    void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(controllerNode);

        // Hide laser at start
        laserLine.enabled = false;
    }

    void Update()
    {
        if (!device.isValid)
        {
            device = InputDevices.GetDeviceAtXRNode(controllerNode);
        }

        bool triggerPressed;

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerPressed))
        {
            if (triggerPressed && !wasPressedLastFrame)
            {
                Shoot();
            }

            wasPressedLastFrame = triggerPressed;
        }
    }

    void Shoot()
    {
        shoot.Play();
        Ray ray = new Ray(firePoint.position, firePoint.forward);

        Vector3 endPoint;

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            endPoint = hit.point;

            Target target = hit.collider.GetComponent<Target>();

            if (target != null)
            {
                hudManager.AddScore(target.GetScoreValue());

                target.Hit();
                explode.Play();
            }
        }
        else
        {
            endPoint = firePoint.position + firePoint.forward * range;
        }

        // Show laser briefly
        StartCoroutine(ShowLaser(endPoint));
    }

    IEnumerator ShowLaser(Vector3 endPoint)
    {
        laserLine.enabled = true;

        laserLine.SetPosition(0, firePoint.position);
        laserLine.SetPosition(1, endPoint);

        yield return new WaitForSeconds(laserDuration);

        laserLine.enabled = false;
    }
}