using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Loding : MonoBehaviour
{
    public Text _text;

    void Start()
    {
        StartCoroutine(LodingBar());
    }

    private void Update()
    {
        if (GetComponent<Slider>().value >= 100) _text.text = $"<Color=Yellow>( Á¢ ¼Ó )</Color> Touch";
        
    }

    IEnumerator LodingBar()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(0.3f);
            GetComponent<Slider>().value += 10;
        }
    }


}
