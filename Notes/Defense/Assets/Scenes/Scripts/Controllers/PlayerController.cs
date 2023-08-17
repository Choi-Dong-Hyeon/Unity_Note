using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    float _speed = 3f;
    bool isTrue = false;

   public int count = 1;
    public Text score;
    public static PlayerController _player;
    public Slider slider;

    public GameObject gameOver;
    public GameObject Monsters;
    void Start()
    {
        _player = this;
    }
    Vector3 cam;
    GameObject go;
    void Update()
    {
        if (transform.position.x >= -7.2) transform.position += Vector3.left * Time.deltaTime * _speed;

        if (slider.value <= 0)
        {
            gameOver.SetActive(true);
            Monsters.SetActive(false);
        }


        cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

        if (Input.GetMouseButtonDown(0))
        {
            go = Instantiate(Resources.Load<GameObject>("Prefabs/Attac"), cam, Quaternion.identity);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Destroy(go);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTrue = !isTrue;
        gameObject.GetComponent<SpriteRenderer>().flipX = isTrue;
        _speed *= -1;
    }

   public void OnButton()
    {
        gameOver.SetActive(false);
        Monsters.SetActive(true);
    }

}
