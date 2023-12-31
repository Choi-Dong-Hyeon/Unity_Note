public class Define
{
    public enum State
    {
        Idle,
        Run,
        Attack,
        Die,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        Count,
    }

    public enum Layer
    {
        Ground = 6,
        Wall,
        Block,
        Monster,
    }

    public enum MouseEvent
    {
        Click,
        Press,
    }

    public enum CameraMode
    {
        Normal,
        QuaterView,
    }

    public enum Scene
    {
        LoginScene,
        GameScene,
        UnKnown,
        LobbyScene,
    }

    public enum ItemType
    {
        Use,
        Equipment,
    }

    public enum CursorType
    {
        Base,
        Attack,
    }

    public enum WorldObjects
    {
        UnKnown,
        Player,
        Monster,
    }

    public enum LobbyPlayer
    {
        Player1,
        Player2,
    }

}
