using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;


public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject emptyBodyGO;
    [SerializeField] Transform spawnPoint;
    [SerializeField] ParticleSystem particleSystem;

    FirstPersonController firstPersonController;

    void Awake()
    {
        firstPersonController = GetComponent<FirstPersonController>();
    }

    bool isRespawning = false;

    void Update()
    {
        if (isRespawning)
        {
            isRespawning = false; // Reset respawn.

            StartCoroutine(Respawn());
        }
    }

    IEnumerator Respawn()
    {
        firstPersonController.enabled = false;

        yield return new WaitForSeconds(0.5f);

        // Spawn a dead body
        Instantiate(emptyBodyGO, transform.position, Quaternion.identity);
        particleSystem.Play();


        // Teleport back to last spawn
        /*
        Since we're using first person asset, they have some weird locks that don't allow transform.position to be reassigned.
        So the fix is this: https://discussions.unity.com/t/unable-to-teleport-the-starter-asset-first-person-controller/917851
        */
        transform.SetPositionAndRotation(spawnPoint.position, Quaternion.identity);
        Physics.SyncTransforms();

        firstPersonController.enabled = true;
    }

    public void OnRespawn(InputValue value)
    {
        isRespawning = value.isPressed;
    }
}
