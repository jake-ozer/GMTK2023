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

        if (currentState == State.inDialogue)
        {
            playerCam.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.m_InputAxisName = "";
            playerCam.GetCinemachineComponent<CinemachinePOV>().m_VerticalAxis.m_InputAxisName = "";
            curPlayer.GetComponent<PlayerMovement>().enabled = false;
            playerCam.Priority = 0;
            dialogueCam.Priority = 5;
            Cursor.visible = true;
            crosshair.SetActive(false);
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
        }
    }

    public void SwitchCharacters()
    {
        dialogueCam.Priority = 1;
        playerCam.Priority = 1;
        curPlayer = curPlayer.GetComponent<PlayerCharacter>().partner.gameObject;
    }
}
