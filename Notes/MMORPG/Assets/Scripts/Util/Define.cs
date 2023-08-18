public class Define
{
    public enum CameraMode
    {
        QuaterView,
        ColliderView,
    }

    public enum MouseEvent
    {
        Press,
        Click
    }

    public enum PlayerState
    {
        Die,
        Idle,
        Moving,
        Attack,
    }

    public enum Scene
    {
        Login,
        InGame,
        Lobby,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }

    public enum Layer
    {
        Ground=6,
        Monster,
        Wall,
        Block,
    }

    public enum WorldObject
    {
        UnKnow,
        Player,
        Monster,
    }
}
