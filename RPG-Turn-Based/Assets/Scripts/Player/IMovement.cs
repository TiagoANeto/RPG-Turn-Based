using UnityEngine;

public interface IMovement
{
    public CharacterController cc {get; set;}
    public float movSpeed {get; set;}

    void Movement(){}
}
