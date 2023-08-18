using UnityEngine;

public class OneNextButton : MonoBehaviour
{
    public GameObject _next;
    public void OnClick()
    {
        gameObject.SetActive(false);
        _next.gameObject.SetActive(true);
    }
}
