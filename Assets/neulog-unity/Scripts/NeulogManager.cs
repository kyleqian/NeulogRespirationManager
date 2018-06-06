using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class NeulogData
{
    public int[] GetSensorValue;

    public static int Parse(string jsonString)
    {
        return JsonUtility.FromJson<NeulogData>(jsonString).GetSensorValue[0];
    }
}

public class NeulogManager : MonoBehaviour
{
    // Singleton reference
    public static NeulogManager Instance;

    public float BreathReading { get; private set; }
    [SerializeField] int requestsPerSecond;
    const string NEULOG_API_URL = "http://localhost:22002/NeuLogAPI?GetSensorValue:[Respiration],[1]";

    void Awake()
    {
        Instance = this;

        // Set off method to periodically ping Neulog API
        InvokeRepeating("QueryNeulog", 0, 1.0f / requestsPerSecond);
    }

    void QueryNeulog()
    {
        UnityWebRequest req = UnityWebRequest.Get(NEULOG_API_URL);
        StartCoroutine(HandleNeulog(req));
    }

    IEnumerator HandleNeulog(UnityWebRequest req)
    {
        yield return req.SendWebRequest();

        if (req.isNetworkError || req.isHttpError)
        {
            Debug.LogWarning(req.error);
        }
        else
        {
            BreathReading = NeulogData.Parse(req.downloadHandler.text);
        }
    }
}
