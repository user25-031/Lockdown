using UnityEngine;
using System.Collections;

public class FallingTile : MonoBehaviour
{
    bool triggered = false;
    public void TriggerTile()
    {
        if (!triggered)
        {
            triggered = true;
            StartCoroutine(Disappear());
        }
    }
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(3f);
        gameObject.SetActive(false);
    }
}