using System.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    int iterations;
    [SerializeField] TextMeshPro iterationText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Win()
    {
        Debug.Log("Level finished");
        endScreen.SetActive(true);
    }
}
