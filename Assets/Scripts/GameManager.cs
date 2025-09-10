using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    int numTries = 0;

    [SerializeField] TextMeshProUGUI totalTriesText;

    void Start()
    {
        UpdateNumTriesDisplayed();
    }

    public void IncrementNumTries()
    {
        numTries += 1;
        UpdateNumTriesDisplayed();
    }

    void UpdateNumTriesDisplayed()
    {
        totalTriesText.text = "Total Tries: " + numTries;

    }
}
