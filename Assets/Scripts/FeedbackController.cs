/*
Original code taken from: https://github.com/luisqtr/exciteometer/blob/main/EoM/EoM_DataReceiver.cs

Modified by:
Andres Pinilla 08/2023
University of Sydney
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;

using TMPro;
using ExciteOMeter;

public class FeedbackController : MonoBehaviour
{

    // Create the text variable to store the excitement rate
    public TMP_Text rmssd;

    void Awake()
    {
        // Subscribe to events
        EoM_Events.OnDataReceived += ExciteOMeterDataReceived;
    }

    // Retrive EoM data
    private void ExciteOMeterDataReceived(DataType type, float timestamp, float value)
    {

        switch (type)
        {
            // If the data type received is EOM (Excite-O-Meter), display the value. Othewise, ignore it and continue.
            case DataType.NONE:
                break;
            case DataType.RMSSD:
                Debug.Log($"Received calculated feature RMSSD with timestamp {timestamp}, value {value}");
                rmssd.text = value.ToString();
                break;
            default:
                break;
        }
    }

}