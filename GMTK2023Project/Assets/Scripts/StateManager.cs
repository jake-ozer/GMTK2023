using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StateManager : MonoBehaviour
{
    public enum State {freeRoam, inDialogue}
    public State currentState;
    [SerializeField] public GameObject curPlayer;
    private GameObject crosshair;
    private CinemachineVirtualCamera playerCam;
    private CinemachineVirtualCamera dialogueCam;
    public GameObject partnerPivot;
    public bool rotateCharacters = true;

    private void Start()
    {
        currentState = State.freeRoam;
        crosshair = GameObject.Find("Crosshair");
    }

    private void Update()
    {
        //Debug.Log(curPlayer);
        playerCam = curPlayer.transform.GetChild(2).GetComponent<CinemachineVirtualCamera>();
        dialogueCam = curPlayer.transform.GetChild(1).GetComponent<CinemachineVirtualCamera>();

        var partner = curPlayer.GetComponent<PlayerCharacter>().partner;
        partnerPivot = partner.transform.GetChild(3).gameObject;

        if (currentState == State.inDialogue)
        {
            playerCam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "";
            playerCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "";
            curPlayer.GetComponent<PlayerMovement>().enabled = false;
            playerCam.Priority = 0;
            dialogueCam.Priority = 5;
            Cursor.visible = true;
            crosshair.SetActive(false);
            curPlayer.transform.GetChild(3).gameObject.SetActive(true);

            if (rotateCharacters)
            {
                //rotate player towards partner
                curPlayer.transform.GetChild(3).gameObject.GetComponent<RotateWithCam>().RotateToFront();
                //rotate partner towards player
                partnerPivot.GetComponent<RotateWithCam>().enabled = true;
                partnerPivot.GetComponent<RotateWithCam>().RotateToPartner();
            }
        }
        else
        {
            playerCam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "Mouse X";
            playerCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "Mouse Y";
            curPlayer.GetComponent<PlayerMovement>().enabled = true;
            playerCam.Priority = 5;
            dialogueCam.Priority = 0;
            Cursor.visible = false;
            crosshair.SetActive(true);
            curPlayer.transform.GetChild(3).gameObject.SetActive(false);
            partnerPivot.GetComponent<RotateWithCam>().enabled = false;
        }
    }

    public void SwitchCharacters()
    {
        dialogueCam.Priority = 1;
        playerCam.Priority = 1;
        curPlayer = curPlayer.GetComponent<PlayerCharacter>().partner.gameObject;
    }

/*    private IEnumerator LockRot()
    {
        yield return new WaitForSeconds(1.5f);
        
    }*/
}
