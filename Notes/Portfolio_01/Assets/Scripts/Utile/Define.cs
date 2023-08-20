public class Define
{
    public enum State
    {
        Idle,
        Run,
        Attack,
        Die,
    }

    public enum Layer
    {
        Ground = 6,
        Block,
        Monster,
        Item,
        Npc,
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

    public enum ItemType
    {
        Use,
        Equipment,
    }

}
