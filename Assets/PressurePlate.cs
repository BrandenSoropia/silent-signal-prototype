using UnityEngine;

public class PressurePlate : MonoBehaviour
{

    [SerializeField] Material safeColourMaterial;
    [SerializeField] Material dangerColourMaterial;

    [SerializeField] bool isSafe;

    MeshRenderer myMeshRenderer;

    void Awake()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (isSafe)
            {
                myMeshRenderer.material = safeColourMaterial;

            }
            else
            {
                myMeshRenderer.material = dangerColourMaterial;
            }

        }
    }
}
