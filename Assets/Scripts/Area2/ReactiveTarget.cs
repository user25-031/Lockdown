using UnityEngine;
using System.Collections;
public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        StartCoroutine(Die());
    }
    private IEnumerator Die()
    {
        iTween.RotateAdd(this.gameObject, new Vector3(-75, 0, 0), 1);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
