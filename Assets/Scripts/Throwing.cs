using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Throwing : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject Camera;
    public GameObject rightController;
    public Aging aging;
    public StoneBag stonebag;
    public float bulletSpeed = 10f;
    private float cooldown = 0.5f;
    private float nextFire = 0f;
    //public SignPuzzle helpbox;
    public InputDevice targetDevice;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        InputRun();


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("log") && aging.ageNumber > 30 && aging.ageNumber < 60 && Input.GetKeyDown(KeyCode.F))
        {
            other.gameObject.AddComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().AddForce(-200f, 0, 0);
        }
        if (other.gameObject.CompareTag("log") && aging.ageNumber < 30)
        {
            //helpbox.helptips.text = "I bet I could move this if I was older";
            Destroy(other.gameObject.GetComponent<Rigidbody>());
        }
        if (other.gameObject.CompareTag("log") && aging.ageNumber >60)
        {
            //helpbox.helptips.text = "I bet I could move this if I was an adult";
            
        }
    }
    private void ProcessBulletSpwan()
    {
        if (Time.time > nextFire && stonebag.stoneCounter > 0)
        {
            firePoint.rotation = rightController.transform.rotation;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, (firePoint.rotation));
            Rigidbody re = bullet.GetComponent<Rigidbody>();
            re.velocity = firePoint.forward * bulletSpeed;
            nextFire = Time.time + cooldown;
            stonebag.stoneCounter--;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //helpbox.helptips.text = "";
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
      /*  aging.targetDevice.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue);
        if (triggerValue == true)
        {
            ProcessBulletSpwan();

        }
        */
    }
}