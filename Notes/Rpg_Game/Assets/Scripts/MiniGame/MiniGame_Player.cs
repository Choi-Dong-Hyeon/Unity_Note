using UnityEngine;

public class MiniGame_Player : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position += new Vector3(Input.GetAxisRaw("Horizontal"),0,0)*3f;        
    }

}
