using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] float speed;
    CharacterController _charPlayer;

    [Header("Sonidos")]
    public AudioSource[] MySound;

    Vector3 inputData;
    float moveH;
    float moveV;
    public bool isMoving;

    
    void Start()
    {
        _charPlayer = GetComponent<CharacterController>();
        MySound[0].Play();
    }

    private void Update()
    {

        MovePlayer();
        RotationPlayer();
        
    }

    private void LateUpdate()
    {
        Sounds();
    }

    public void MovePlayer()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        inputData = new Vector3(moveH, 0, moveV);
        inputData = Vector3.ClampMagnitude(inputData, 1);
        _charPlayer.Move(inputData * speed * Time.deltaTime);

        if (moveH != 0 || moveV != 0) isMoving = true;
        else isMoving = false;
    }

    public void RotationPlayer()
    {
        if (moveH < 0) transform.rotation = Quaternion.Euler(0, 270, 0);
        if (moveH > 0) transform.rotation = Quaternion.Euler(0, 90, 0);
        if (moveV < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
        if (moveV > 0) transform.rotation = Quaternion.Euler(0, 0, 0);

        if (moveH < 0 && moveV > 0) transform.rotation = Quaternion.Euler(0, 315, 0);
        if (moveH > 0 && moveV > 0) transform.rotation = Quaternion.Euler(0, 45, 0);
        if (moveH < 0 && moveV < 0) transform.rotation = Quaternion.Euler(0, 225, 0);
        if (moveH > 0 && moveV < 0) transform.rotation = Quaternion.Euler(0, 135, 0);
    }

    public void Sounds()
    {
        if (isMoving) MySound[0].UnPause();
        else MySound[0].Pause();
    }
}
