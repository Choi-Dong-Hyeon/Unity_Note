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
    }

    public enum Scene
    {
        UnKnown,
        LoginScene,
        LobbyScene,
        GameScene,
    }

    public enum ItemType
    {
        Use,
        Equipment,
    }

}
