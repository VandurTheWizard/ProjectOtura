using Unity.AI.Navigation;
using UnityEngine;

public class FloorUsages : MonoBehaviour
{
    public static GameObject plane;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plane = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
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


}
