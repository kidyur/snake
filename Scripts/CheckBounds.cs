using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CheckBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
