using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerController : MonoBehaviour {

    public Image powerBar;
    public int currentPower;
    bool goDown = false;
    bool goUp = true;
    public bool stopMeter = true;
    public GameObject ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("Ball");
	}
	
	// Update is called once per frame
	void Update () {

        if (!stopMeter)
        {
            if (powerBar.fillAmount >= 1)
            {
                goDown = true;
                goUp = false;
            }
            if (powerBar.fillAmount <= 0)
            {
                goUp = true;
                goDown = false;
            }

            if (goUp)
            {
                powerBar.fillAmount += Time.deltaTime * 0.5f;
            }
            if (goDown)
            {
                powerBar.fillAmount -= Time.deltaTime * 0.5f;
            }

            if (Input.GetKey(KeyCode.Return))
            {
                stopMeter = true;
                ball.GetComponent<Ball>().powerScale = powerBar.fillAmount;
                GameObject.Find("Golfer(Clone)").GetComponent<Golfer>().anim.SetBool("isPutting", true);
                Debug.Log(GameObject.Find("Golfer(Clone)").GetComponent<Golfer>().isRotating);
            }
        }
	}
}
