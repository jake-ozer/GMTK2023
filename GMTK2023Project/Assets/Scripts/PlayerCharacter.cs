using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public PlayerCharacter partner;
    private float startingY;

    private void Start()
    {
        startingY = transform.localPosition.y;
    }

    private void Update()
    {
        transform.localPosition = new Vector3(transform.position.x, startingY, transform.position.z);
    }
}
