using UnityEngine;

public class DropGate : MonoBehaviour
{

    [SerializeField] GameObject gate;
    Rigidbody gateRb;

    void Awake()
    {
        // make sure associated gate is not falling.
        gateRb = gate.GetComponent<Rigidbody>();
        gateRb.useGravity = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gateRb.useGravity = true;
        }
    }
}
