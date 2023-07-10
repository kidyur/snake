using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public List<GameObject> Body = new List<GameObject>();
    public List<string> Directions = new List<string>();
    public float Time = 0.5f;
    private string _inputDirection = "Up";

    private void Start()
    {
        StartCoroutine(Step());
    }

    private IEnumerator Step() 
    {
        while(true) 
        {
            for (int i = Body.Count-1; i > 0; i--) 
            {
                // Exchange of directions from top (head) to bottom 
                Directions[i] = Directions[i-1];

                Move(i);
            }

            // Checks for opposite directions
            if ((Directions[0] != "Up" && _inputDirection == "Down") ||
                (Directions[0] != "Down" && _inputDirection == "Up") ||
                (Directions[0] != "Left" && _inputDirection == "Right") ||
                (Directions[0] != "Right" && _inputDirection == "Left"))
            {
                Directions[0] = _inputDirection;
            }

            Move(0); 

            yield return new WaitForSeconds(Time);
        }
    }

    private void Move(int index) 
    {
        float interval = Body[index].transform.lossyScale.x + 0.1f;

        if (Directions[index] == "Up")
        {
            Body[index].transform.position += new Vector3(0, interval, 0);
        }
        else if (Directions[index] == "Down")
        {
            Body[index].transform.position += new Vector3(0, -interval, 0);
        }
        else if (Directions[index] == "Right")
        {
            Body[index].transform.position += new Vector3(interval, 0, 0);
        }
        else if (Directions[index] == "Left")
        {
            Body[index].transform.position += new Vector3(-interval, 0, 0);
        }
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _inputDirection = "Up";
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _inputDirection = "Left";
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _inputDirection = "Down";
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _inputDirection = "Right";
        }
    }
}
