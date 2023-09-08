
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


        // Managers.Instance.Resource.Instantiate<GameObject>("Town");

        GameObject go = GameObject.Find("@SpawnPool");
        
        if (go == null)
            go = new GameObject { name = "@SpawnPool" };

        SpawningPool pool = go.AddComponent<SpawningPool>();
        pool.KeepMonsterCount(5);
    }

    public override void Clear()
    {
        base.Clear();
    }


}
