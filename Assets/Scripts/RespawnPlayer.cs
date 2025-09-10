using System.Collections;
using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;


public class RespawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject emptyBodyGO;
    [SerializeField] Transform spawnPoint;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] AudioClip powerOffSFX;
    [SerializeField] AudioClip powerOnSFX;
    [SerializeField] float respawnAnimationTime = 1f;

    FirstPersonController firstPersonController;
    [SerializeField] GameManager gameManager;

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
        gameManager.IncrementNumTries();
        AudioSource.PlayClipAtPoint(powerOffSFX, Camera.main.transform.position);

        // Spawn a dead body
        Instantiate(emptyBodyGO, transform.position, Quaternion.identity);


        yield return new WaitForSeconds(respawnAnimationTime);


        // Teleport back to last spawn
        /*
        Since we're using first person asset, they have some weird locks that don't allow transform.position to be reassigned.
        So the fix is this: https://discussions.unity.com/t/unable-to-teleport-the-starter-asset-first-person-controller/917851
        */
        transform.SetPositionAndRotation(spawnPoint.position, Quaternion.identity);
        Physics.SyncTransforms();


        particleSystem.Play();
        AudioSource.PlayClipAtPoint(powerOnSFX, Camera.main.transform.position);

        firstPersonController.enabled = true;
    }

    public void OnRespawn(InputValue value)
    {
        isRespawning = value.isPressed;
    }
}
