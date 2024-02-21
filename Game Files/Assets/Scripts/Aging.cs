using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Aging : MonoBehaviour
{
    public Throwing throwing;
    public GameObject Player;
    public GameObject ageWall;
    public float ageNumber = 8;
    private Vector3 heightScale;
    private float heightchangeRate = 0.003f;
    public Rigidbody rockWeight;
    public InputDevice targetDevice;
    // Start is called before the first frame update
    void Start()
    {
        //var dynamicMoveProvider = FindObjectOfType<UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets.DynamicMoveProvider>();
    }

    // Update is called once per frame
    void Update()
    {

        InputRun();

        heightScale = new Vector3(0, heightchangeRate, 0);
        AgingUp();
        //ThrowingPower();



    }
    public void AgingUp()
    {// Input.GetKey(KeyCode.E
        targetDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 primary2DAxisValue);
        targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripvalue);
        if (primary2DAxisValue.y > 0 && primary2DAxisValue.x > -0.5 && primary2DAxisValue.x < 0.5 && gripvalue == false)
        {
            if (ageNumber < 60)
            {
                ageNumber += 0.15f;
                Player.gameObject.transform.localScale += heightScale;
            }
            if (ageNumber >= 60)
            {
                ageNumber += 0.35f;
                heightchangeRate = 0.005f;
                Player.gameObject.transform.localScale -= heightScale;
            }

        }

        if (primary2DAxisValue.y < 0 && primary2DAxisValue.x > -0.5 && primary2DAxisValue.x < 0.5 && gripvalue == false)
        {
            if (ageNumber < 60)
            {
                ageNumber -= 0.15f;
                heightchangeRate = 0.003f;
                Player.gameObject.transform.localScale -= heightScale;
            }

            if (ageNumber >= 60)
            {
                ageNumber -= 0.35f;
                Player.gameObject.transform.localScale += heightScale;
            }

        }

        if (ageNumber >= 80)
        {
            ageNumber = 80;
            Player.gameObject.transform.localScale = new Vector3(Player.gameObject.transform.localScale.x, 1.32f, Player.gameObject.transform.localScale.z);
        }

        if (ageNumber <= 8)
        {
            ageNumber = 8;
            Player.gameObject.transform.localScale = new Vector3(Player.gameObject.transform.localScale.x, 0.6f, Player.gameObject.transform.localScale.z);

        }
        agingWall();
    }
    private void ThrowingPower()
    {
        var movespeed = FindObjectOfType<UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets.MoveSpeed>();
        if (ageNumber <= 15)
        {
            throwing.bulletSpeed = 7;
            movespeed.movespeed = 3f;
        }
        if (ageNumber > 15 && ageNumber <= 50)
        {
            throwing.bulletSpeed = 13;
            movespeed.movespeed = 1f;
        }
        if (ageNumber > 50)
        {
            throwing.bulletSpeed = 5;
            movespeed.movespeed = 0.25f;
        }
        
    }
    private void agingWall()
    {
        {
            ageWall.transform.localScale = new Vector3(ageWall.transform.localScale.x, (ageNumber * -0.05f), ageWall.transform.localScale.z);
        }
    }
    private void InputRun()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;

        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);
            foreach (var item in devices)
            {
               //Debug.Log(item.name + item.characteristics);
            }
            if (devices.Count > 0)
            {
                targetDevice = devices[0];
            }
       

    }
}
