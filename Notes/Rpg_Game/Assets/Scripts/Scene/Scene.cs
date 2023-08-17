using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    public Slider _slider;
    public Text _text;
    public Text _loadingText;
    void Start()
    {
        StartCoroutine(SceneLoding());

    }

    void Update()
    {
        if (_slider == null) return;
        if (_slider.value == 10)
        {
            _text.gameObject.SetActive(true);
            _loadingText.gameObject.SetActive(false);
        }
    }


    IEnumerator SceneLoding()
    {
      
        while (_slider.value < 10)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            _slider.value ++;
        }
    }

    public void OnScene()
    {
        SceneManager.LoadScene((int)Define.Scene.InGame);
    }

}
