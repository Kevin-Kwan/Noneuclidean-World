using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{

    public CharacterController player;
    public Transform block;
    public Transform block2;
    public Transform reciever;

    private bool playerIsOverlapping = false;
    private bool blockIsOverlapping = false;
    private bool block2IsOverlapping = false;
    private static float lastTeleportationTime;
    private static float blocklastTeleportationTime;
    private static float block2lastTeleportationTime;
    // Update is called once per frame
    void Update()
    {
        if (playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            // If this is true: The player has moved across the portal
            if (dotProduct < 0f)
            {
                // Teleport him!
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.transform.Rotate(Vector3.up, rotationDiff);
                //Keep the player's rotation orientation
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                
                player.transform.position = reciever.position + portalToPlayer;
                

                playerIsOverlapping = false;
            }
        }
        if (blockIsOverlapping)
        {
            Vector3 portalToBlock = block.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToBlock);

            // If this is true: The block has moved across the portal
            if (dotProduct < 0f)
            {
                // Teleport him!
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                block.transform.Rotate(Vector3.up, rotationDiff);
                //Keep the block's rotation orientation
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToBlock;

                block.transform.position = reciever.position + portalToBlock;


                blockIsOverlapping = false;
            }
        }
        if (block2IsOverlapping)
        {
            Vector3 portalToBlock2 = block2.transform.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToBlock2);

            // If this is true: The block2 has moved across the portal
            if (dotProduct < 0f)
            {
                // Teleport him!
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                block2.transform.Rotate(Vector3.up, rotationDiff);
                //Keep the block2's rotation orientation
                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToBlock2;

                block2.transform.position = reciever.position + portalToBlock2;


                block2IsOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Time.time - lastTeleportationTime < 0.25) // Delay of 5 seconds to prevent infinite loops
                return;
            playerIsOverlapping = true;
        }
        lastTeleportationTime = Time.time;
        if (other.tag == "Block")
        {
            if (Time.time - blocklastTeleportationTime < 0.25) // Delay of 5 seconds to prevent infinite loops
                return;
            blockIsOverlapping = true;
        }
        blocklastTeleportationTime = Time.time;
        if (other.tag == "Block2")
        {
            if (Time.time - block2lastTeleportationTime < 0.25) // Delay of 5 seconds to prevent infinite loops
                return;
            block2IsOverlapping = true;
        }
        block2lastTeleportationTime = Time.time;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
        if (other.tag == "Block")
        {
            blockIsOverlapping = false;
        }
        if (other.tag == "Block2")
        {
            block2IsOverlapping = false;
        }
    }
}