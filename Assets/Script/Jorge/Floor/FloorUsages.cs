using Unity.AI.Navigation;
using UnityEngine;

public class FloorUsages : MonoBehaviour
{
    public static GameObject plane;
    public GameObject[] level2;
    public GameObject[] level3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plane = gameObject;
    }
    public static void resetPlane()
    {
        NavMeshSurface surface = plane.GetComponent<NavMeshSurface>();
        surface.navMeshData = null;
        surface.BuildNavMesh();
    }

    public static void resetPlaneWithDestroyGameObject(GameObject gameObject)
    {
        Destroy(gameObject);
        NavMeshSurface surface = plane.GetComponent<NavMeshSurface>();
        surface.navMeshData = null;
        surface.BuildNavMesh();
    }

    public static void activateLevel2()
    {

    }

    public static void activateLevel3()
    {

    }

}
