using UnityEngine;

public class Celebrate : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] ParticleSystem particleSystem;
    [SerializeField] bool isPlaying = false;

    void Update()
    {
        if (isPlaying)
        {
            RotateDiscoBall();
        }
    }

    void RotateDiscoBall()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
    }

    public void PlayAllCelebrations()
    {
        isPlaying = true;
        particleSystem.Play();
    }
}
