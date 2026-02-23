using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPortal : MonoBehaviour
{
    public LevelCompleteManager levelCompleteManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelCompleteManager.TriggerLevelComplete();
        }
    }
}