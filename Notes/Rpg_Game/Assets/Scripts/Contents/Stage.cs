using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour
{
    public Text _stageText;

    private void OnTriggerEnter(Collider other)
    {
        _stageText.gameObject.SetActive(true);
        _stageText.text = "�� �� �� �� �� ��";
        StartCoroutine(StageText());
    }

    IEnumerator StageText()
    {
        yield return new WaitForSecondsRealtime(2);
        _stageText.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

}
