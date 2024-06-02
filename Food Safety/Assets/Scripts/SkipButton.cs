using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipButton : MonoBehaviour
{
    [SerializeField]
    private GameObject btnSkip;

    public void Awake()
    {
        btnSkip.SetActive(false);
        StartCoroutine(WaitForFiveSeconds());
    }

    private IEnumerator WaitForFiveSeconds()
    {
        btnSkip.SetActive(false);

        yield return new WaitForSeconds(5);

        btnSkip.SetActive(true);
    }
}
