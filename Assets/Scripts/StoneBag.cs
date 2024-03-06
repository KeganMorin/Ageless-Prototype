using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class Bags
{
    public GameObject gameObject;
    [Range(0.01f, 1f)]
    public float heightRatio;
}
public class StoneBag : MonoBehaviour
{
    private GameObject Player;
    private Vector3 _currentCamPosition;
    private Quaternion _currentCamRotation;
    public Bags[] bags;
    public int stoneCounter = 0;
    public Aging aging;
    public bool inProximity = false;
    public InputDevice targetDevice;

    [SerializeField] public GameObject throwingstone;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        InputRun();

        _currentCamPosition = Player.transform.position;
        _currentCamRotation = Player.transform.rotation;
        /*foreach(var bags in bags)
        {
            UpdateBagHeight(bags);
        }
        */
        UpdateBagInventory();
       
    }

    private void UpdateBagHeight(Bags bags)
    {
        bags.gameObject.transform.position = new Vector3(bags.gameObject.transform.position.x, _currentCamPosition.y * bags.heightRatio, bags.gameObject.transform.position.z);

    }
    private void UpdateBagInventory()
    {
        transform.position = new Vector3(_currentCamPosition.x, 0, _currentCamPosition.z);
        transform.rotation = new Quaternion(transform.rotation.x, _currentCamRotation.y, transform.rotation.z, _currentCamRotation.w);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "thrownRock" && stoneCounter < 4)
        {

            Destroy(other.gameObject);
            stoneCounter++;
            Debug.Log(stoneCounter);
        }

        if (other.gameObject.tag == "Left")
        {
            inProximity = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Left")
        {
            inProximity = false;
        }
    }

    public void InputRun()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;

        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);
        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
        targetDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool gripValue);
        if (inProximity == true && gripValue == true && stoneCounter > 0)
        {
            Instantiate(throwingstone, gameObject.transform.position + new Vector3(-0.25f, 0, 0), gameObject.transform.rotation);
            Debug.Log("GOOOOOOOOO");
            stoneCounter--;
        }

    }
}
