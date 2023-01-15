using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
     private Health health;
     public bool isDead = false;

      void Start()
    {
        health = GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }
    void CheckHealth()
    {
    if(health.health<=0)
    {
        isDead=true;
        Invoke("RestartGame",2f);
    }
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}