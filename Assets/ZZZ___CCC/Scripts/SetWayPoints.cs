using System.Collections.Generic;
using UnityEngine;

public class SetWayPoints : MonoBehaviour
{
    public static SetWayPoints Instance;

    public Granny grannyController;

    public List<Transform> waypointsInKitchen = new ();
    public List<Transform> wayPointsInLivingRoom = new();
    public List<Transform> wayPointsInSecondFloor1= new();
    public List<Transform> wayPointsInSecondFloorAll= new();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Debug.LogWarning("Another instance available on " + gameObject.name);
    }
    public void ToKitchen()
    {
        UpdateEnemyWayPoints(waypointsInKitchen);
    }
    public void ToLivingRoom()
    {
        UpdateEnemyWayPoints(wayPointsInLivingRoom);
    }
    public void ToSecondFloorHalf()
    {
        UpdateEnemyWayPoints(wayPointsInSecondFloor1);
    }
    public void ToSecondFloorFull()
    {
        UpdateEnemyWayPoints(wayPointsInSecondFloorAll);
    }

    void UpdateEnemyWayPoints(List<Transform> wayPoints)
    {
        if (grannyController == null)
        {
            Debug.LogWarning("Granny reference is missing!");
            return;
        }

        if (grannyController.wayPoints.Count > 0)
        {
            grannyController.wayPoints.Clear();
        }
        Debug.Log("enemy points updated");
        grannyController.wayPoints.AddRange(wayPoints);
    }
}
