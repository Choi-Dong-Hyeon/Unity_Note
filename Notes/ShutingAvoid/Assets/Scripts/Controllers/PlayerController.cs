using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float _playerSpeed = 4;
    public Text score;
    public int count = 0;
    public Image img;

    public GameObject A;
    public GameObject S;
    

    void Update()
    {
        OnMoveEvent();

        if (transform.localScale.x <= 0.5) Restart();
        
    }

    void OnMoveEvent()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0) * Time.deltaTime * _playerSpeed;

        if (Input.GetKeyDown(KeyCode.D)) GetComponent<SpriteRenderer>().flipX = true;
        if (Input.GetKeyDown(KeyCode.A)) GetComponent<SpriteRenderer>().flipX = false;
    }

    public void OnButton()
    {
        img.gameObject.SetActive(false);
        A.SetActive(true);
        S.SetActive(true);

    }

    void Restart()
    {
        img.gameObject.SetActive(true);
        A.SetActive(false);
        S.SetActive(false);
    }

}
