using UnityEngine;

public class Define : MonoBehaviour
{
    public enum State
    {
        Idle,
        Run,
        Attack,
        Attack_Tum,
        Attack_Kick,
        Die,
    }

    public enum Layer
    {
        Ground=6,
        Monster,
        Wall,
        Block
    }

    public enum Scene
    {
        Lobby,
        InGame,
    }

    public enum Camera
    {
        Normal,
        QuarterView,
    }
    
    public enum ItemType
    {
        Use,
        UnKnown
    }

}
