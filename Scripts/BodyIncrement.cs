using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyIncrement : MonoBehaviour
{
    [SerializeField] GameObject bodyPart;

    private Movement _playerStats;

    private void Start()
    {
        _playerStats = GameObject.Find("Head").GetComponent<Movement>();
    }

    private void OnTriggerEnter2D(Collider2D body) 
    {
        if (body.name == "Head") 
        {
            AddBodyPart();
            GameObject.Find("Canvas").GetComponent<RaiseScore>().IncreaseScore();
        }
        
        var playground = GameObject.FindGameObjectWithTag("Ground");
        playground.GetComponent<StartPoint>().SpawnPoint();
        Destroy(this.gameObject);
    }

    private void AddBodyPart() 
    {
        var body = _playerStats.Body;
        var directions = _playerStats.Directions;

        Vector3 partPosition = body[body.Count-1].transform.position;
        float interval = body[0].transform.lossyScale.x + 0.1f;

        if (directions[body.Count-1] == "Up")
        {
            partPosition += new Vector3(0, -interval, 0);
        }
        else if (directions[body.Count-1] == "Down")
        {
            partPosition += new Vector3(0, interval, 0);
        }
        else if (directions[body.Count-1] == "Right")
        {
            partPosition += new Vector3(-interval, 0, 0);
        }
        else if (directions[body.Count-1] == "Left")
        {
            partPosition += new Vector3(interval, 0, 0);
        }
        
        var bodyPartClone = Instantiate(bodyPart, partPosition, Quaternion.identity);
        body.Add(bodyPartClone);
        directions.Add(directions[directions.Count-1]);
    }

    private void IncreaseSpeed() 
    {
        _playerStats.Time *= 0.8f;
    }
}
