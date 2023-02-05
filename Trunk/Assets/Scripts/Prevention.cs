using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Prevention : MonoBehaviour
{
    public GameObject Caution;
    public TMP_Text textAlert;
   

    [TextArea]
    public string alertMss;
    void Start()
    {
        Caution.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            


            StartCoroutine(ActivePanel(alertMss));
        }
    }

    public IEnumerator ActivePanel(string text)
    {
        textAlert.text = text;
        Caution.SetActive(true);
        yield return new WaitForSeconds(10); Caution.SetActive(false);
    }

}
