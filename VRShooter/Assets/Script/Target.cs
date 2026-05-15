using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public int scoreValue = 10;

    // How long target stays disabled
    public float respawnTime = 3f;

    // Everything to disable
    private Renderer[] renderers;
    private Collider[] colliders;

    private bool isActive = true;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
        colliders = GetComponentsInChildren<Collider>();
    }

    public int GetScoreValue()
    {
        return scoreValue;
    }

    public void Hit()
    {
        // Prevent multiple hits
        if (!isActive)
        {
            return;
        }

        StartCoroutine(DisableTarget());
    }

    IEnumerator DisableTarget()
    {
        isActive = false;

        // Hide target
        foreach (Renderer r in renderers)
        {
            r.enabled = false;
        }

        // Disable collisions
        foreach (Collider c in colliders)
        {
            c.enabled = false;
        }

        // Wait before respawn
        yield return new WaitForSeconds(respawnTime);

        // Show target again
        foreach (Renderer r in renderers)
        {
            r.enabled = true;
        }

        // Enable collisions
        foreach (Collider c in colliders)
        {
            c.enabled = true;
        }

        isActive = true;
    }
}