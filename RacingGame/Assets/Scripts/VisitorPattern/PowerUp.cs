using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "EnginePowerUp", menuName = "Engine PowerUp")]
public class PowerUp : ScriptableObject, IVisitor
{
  //  public float defaultSpeed;
    public PlayerController playerController;
    public float boost=400.0f;
    public float duration = 3.0f;
    public void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
      // defaultSpeed = playerController.driveAccel;

    }
    public void Visit(CarEngine carEngine)
    {

        playerController = FindAnyObjectByType<PlayerController>();
        playerController.driveAccel += boost;
        Debug.Log(" car engine is being boosted " + playerController.driveAccel);
        carEngine.StartCoroutine(DecreaseSpeedAfterDelay(carEngine));


    }


    private IEnumerator DecreaseSpeedAfterDelay(CarEngine carEngine)
    {
       
        yield return new WaitForSeconds(duration);

       
        playerController.driveAccel -= boost;
        Debug.Log("Speed boost duration ended. Default speed restored: " + playerController.driveAccel);
    }
}
