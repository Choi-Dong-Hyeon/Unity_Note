using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionButton : MonoBehaviour
{
 public void OnClick()
    {
        SceneManager.LoadScene(0);
    }
}
