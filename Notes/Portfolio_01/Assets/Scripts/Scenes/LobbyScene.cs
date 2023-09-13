using System.Collections;
using UnityEngine;

public class LobbyScene : BaseScene
{
    protected override void Init()
    {
        base.Init();
        Managers.Instance.Resource.Instantiate<GameObject>("Players/LobbyPlayer/Player_01");
        Managers.Instance.Resource.Instantiate<GameObject>("Players/LobbyPlayer/Player_02");
        Managers.Instance.UI.ShowSceneUI<LobbyBG_UI>("LobbyBG_UI");
    }

    LayerMask _mask = 1 << (int)Define.LobbyPlayer.Player1 | (int)Define.LobbyPlayer.Player2;
    RaycastHit _hit;
    Vector3 _hitPoint;

    void Update()
    {
        Vector3 cam = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Vector3 camDir = cam - Camera.main.transform.position;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.transform.position, camDir, out _hit, 100f, _mask))
            {
                _hitPoint = _hit.point;

                if (_hit.collider.gameObject.CompareTag((Define.LobbyPlayer.Player1).ToString()))
                {
                    StartCoroutine(LobbyPlayerAction());
                }
                if (_hit.collider.gameObject.CompareTag((Define.LobbyPlayer.Player2).ToString()))
                {
                    StartCoroutine(LobbyPlayerAction());
                }
            }
        }
    }

    IEnumerator LobbyPlayerAction()
    {
        Animator playerAnim = _hit.collider.gameObject.GetComponent<Animator>();
        playerAnim.Play("Attack");
        yield return new WaitForSeconds(3);
        Managers.Instance.Resource.Destroy(playerAnim.gameObject);
        Managers.Instance.Clear();
        Managers.Instance.Scene.LoadScene(Define.Scene.GameScene);
    }
}
