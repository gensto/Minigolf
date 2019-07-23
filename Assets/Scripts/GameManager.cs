using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject golfer;
    public GameObject ball;

    public GameObject golferObj;
    bool hasScored = false;

	// Use this for initialization
	void Start ()
    {
        createGolfer();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!ball.GetComponent<Ball>().hasScored)
        {
            if (ball.GetComponent<Ball>().isHit && (ball.GetComponent<Ball>().rb.velocity.x == 0 && ball.GetComponent<Ball>().rb.velocity.y == 0 && ball.GetComponent<Ball>().rb.velocity.z == 0))
            {
                Debug.Log(ball.GetComponent<Ball>().hasScored);
                resetValues();
            }
        }
	}

    void createGolfer()
    {
        golferObj = Instantiate(golfer);
    }

    void resetValues()
    {
        ball.GetComponent<Ball>().isHit = false;
        ball.transform.eulerAngles = new Vector3(0, 0, 0);
        golferObj.GetComponent<Golfer>().repositionGolfer();
        golferObj.GetComponent<Golfer>().isRotating = true;
        GameObject.Find("Power").GetComponent<PowerController>().powerBar.fillAmount = 0.0f;
        GameObject.Find("Main Camera").GetComponent<CameraFollower>().resetCamera();
        GameObject.Find("AngleInstructions").GetComponent<Text>().enabled = true;
        GameObject.Find("PowerMeterInstructions").GetComponent<Text>().enabled = false;

    }
}
