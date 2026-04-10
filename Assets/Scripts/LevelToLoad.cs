using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLevelOne : MonoBehaviour
{
    [SerializeField] private string level;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(level);
        }
    }
}
