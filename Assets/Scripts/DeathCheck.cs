using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheck : MonoBehaviour
{
    ReloadScene reload;
    private void Awake()
    {
        reload = GetComponent<ReloadScene>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        reload.LoadScene();
    }
}
