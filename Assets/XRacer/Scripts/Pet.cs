using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pet : MonoBehaviour
{

    private struct PointInSpace
    {
        public Vector3 Position;
        public float Time;
    }

    [SerializeField]
    public Vector3 target;
    [SerializeField]
    public Vector3 offset;


    [SerializeField]
    private float delay = 0.5f;

    [SerializeField]

    private float speed = 5;

    private Queue<PointInSpace> pointsInSpace = new Queue<PointInSpace>();

    public Camera testCam;
    public Transform camMain;
    public Vector3 tesst;
    public PlayerControl player;

    private void Start()
    {

        tesst = new Vector3();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {




            target = testCam.ScreenToWorldPoint(Input.mousePosition);

            //camMain.transform.position = new Vector3(target.x, camMain.transform.position.y, camMain.transform.position.z);
             //transform.position = target;
            // tesst = new Vector3();
            // Add the current target position to the list of positions
            pointsInSpace.Enqueue(new PointInSpace() { Position = new Vector2(target.x, target.y), Time = Time.time });
            // Move the camera to the position of the target X seconds ago 
            //while (pointsInSpace.Count > 0 && pointsInSpace.Peek().Time <= Time.time - 5 + Mathf.Epsilon)
            //{
            //    tesst = Vector3.Lerp(transform.position, pointsInSpace.Dequeue().Position + offset, Time.deltaTime * speed);
            //}

            while (pointsInSpace.Count > 0 && pointsInSpace.Peek().Time <= Time.time - delay + Mathf.Epsilon)
            {
                transform.position = Vector3.Lerp(transform.position, pointsInSpace.Dequeue().Position + offset, Time.deltaTime * speed);
                tesst = transform.position;



            }

           

            //player.shipModel.transform.eulerAngles = Vector3.Lerp(transform.position, pointsInSpace.Dequeue().Position + offset, Time.deltaTime * speed);


            camMain.transform.position = new Vector3(tesst.x, camMain.transform.position.y, camMain.transform.position.z);









        }



        _Rotate();
    }
    [SerializeField] float speedRotate;

    public Vector3 post;
    public bool wasDrag;
    public Vector3 postDown;
    float xBegin = 0;
    Vector3 rotBegin = Vector3.zero;
    

    public void _Rotate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            postDown = testCam.ScreenToViewportPoint(Input.mousePosition);
            xBegin = postDown.x;
            rotBegin = player.shipModel.transform.eulerAngles;
           

        }

        if (Input.GetMouseButton(0))
        {
            post = testCam.ScreenToViewportPoint(Input.mousePosition);
            if ( post != postDown)
            {
                player.shipModel.transform.eulerAngles = rotBegin - new Vector3(0, 0, post.x - xBegin) * speedRotate;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            player.shipModel.transform.eulerAngles = Vector3.zero;
        }

        //SoundManager.Play("");
    }

}
public enum NameOfPet
{
    Bug = 0,
    Bat = 1,
    Cat = 2,
    None,

}

public enum TypeOfPet
{
    Standing,
    Flying,
    Running



}