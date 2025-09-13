using System.Collections.Generic;
using UnityEngine;

public class DartsResetter : MonoBehaviour
{
    private static List<(Transform objTransform, Vector3 startPosition, Quaternion startRotation, GameObject objGameObject)> objectsData = new();

    [SerializeField] private string dartTag = "Dart";

    private void Awake()
    {
        FindAllPickableObjects();
    }

   
    private void FindAllPickableObjects()
    {
        objectsData.Clear(); // Clear old data
        GameObject[] dartGameobjcts = GameObject.FindGameObjectsWithTag(dartTag);

        foreach (GameObject obj in dartGameobjcts)
        {
            objectsData.Add((obj.transform, obj.transform.position, obj.transform.rotation, obj));
        }
    }

   
    public static void ResetAllObjects()
    {
        foreach (var data in objectsData)
        {
            data.objTransform.position = data.startPosition;
            data.objTransform.rotation = data.startRotation;
            data.objGameObject.SetActive(true);
        }
    }
}
