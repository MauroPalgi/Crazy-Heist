using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [SerializeField] private GameObject player;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    public GameObject SpawnPlayer()
    {
        if (player != null)
        {
            Vector3 pos = new Vector3(0, 1, 0);
            var currentTarget = Instantiate(player, pos, Quaternion.identity);
            virtualCamera.Follow = currentTarget.transform;
            return currentTarget;
        }
        return null;
    }
}
