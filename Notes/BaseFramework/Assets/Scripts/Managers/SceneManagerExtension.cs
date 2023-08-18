using UnityEngine.SceneManagement;

public class SceneManagerExtension
{
    public void LoadScene(Define.Scene type)
    {
        SceneManager.LoadScene((int)type);
    }
}
