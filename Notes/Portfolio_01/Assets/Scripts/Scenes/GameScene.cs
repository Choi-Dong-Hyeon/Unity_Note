
using UnityEngine;

public class GameScene : BaseScene
{

    protected override void Init()
    {
        base.Init();
        _scene = Define.Scene.GameScene;

        CursorController cursor = GetComponent<CursorController>();
        if (cursor == null)
            gameObject.AddComponent<CursorController>();

        GameObject player = Managers.Instance.Game.Spawn(Define.WorldObjects.Player, "Player");
        Camera.main.GetComponent<CameraController>().SetPlayer(player);

        //Managers.Instance.Game.Spawn(Define.WorldObjects.Monster, "Monster_Bear");
        //   GameObject go = Managers.Instance.Game.Spawn(Define.WorldObjects.Monster, "Monster_Bear");
        //  go.transform.position = new Vector3(10, 0, -7);
        //Managers.Instance.Game.Spawn(Define.WorldObjects.Monster, "Monster_Bear");

        //   Managers.Instance.Resource.Instantiate<GameObject>("Town");

        GameObject go = new GameObject { name = "SpawnPool" };
        SpawningPool pool = go.AddComponent<SpawningPool>();
        pool.KeepMonsterCount(3);

    }

    public override void Clear()
    {
        base.Clear();
    }


}
