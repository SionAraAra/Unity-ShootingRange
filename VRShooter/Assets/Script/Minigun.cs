using UnityEngine;
using UnityEngine.XR;

public class RaycastGun : MonoBehaviour
{
    public Transform firePoint;
    public float range = 100f;
    public VRHudManager hudManager;

    // Which controller shoots
    public XRNode controllerNode = XRNode.RightHand;

    private InputDevice device;

    void Start()
    {
        
        device = InputDevices.GetDeviceAtXRNode(controllerNode);
    }

    void Update()
    {
        // Reconnect if controller disconnects
        if (!device.isValid)
        {
            device = InputDevices.GetDeviceAtXRNode(controllerNode);
        }

        // Trigger button
        bool triggerPressed;

        if (device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerPressed)
            && triggerPressed)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = new Ray(firePoint.position, firePoint.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, range))
        {
            Target target = hit.collider.GetComponent<Target>();

            if (target != null)
            {
                hudManager.AddScore(target.GetScoreValue());

                Destroy(target.gameObject);
            }
        }
    }
}