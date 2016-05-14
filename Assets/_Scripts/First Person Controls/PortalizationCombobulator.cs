/*---------------------------------------------------------
File Name: PortalizationCombobulator.cs
Purpose: To move the player between portals
Authors: Heath Parkes (gargit@gargit.net), Liam Ellis (liam.ellis37@gmail.com)
Modified: 19/4/2016
-----------------------------------------------------------
Copyright 2016 LE/HP
---------------------------------------------------------*/

using UnityEngine;
using System.Collections;

public class PortalizationCombobulator : MonoBehaviour {

    public GameObject m_TargetPortal;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = m_TargetPortal.transform.position;
        }
    }
}
