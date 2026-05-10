using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlaygroundBuilder : MonoBehaviour
{
#if UNITY_EDITOR
    [ContextMenu("Build Playground")]
#endif
    public void BuildPlayground()
    {
        // الارضية - 20x20
        CreateCube("Floor", new Vector3(0, 0, 0), new Vector3(20, 0.1f, 20));

        // السور حوالين الملعب
        CreateCube("Fence_Back", new Vector3(0, 1, -10), new Vector3(20, 2, 0.1f));
        CreateCube("Fence_Front", new Vector3(0, 1, 10), new Vector3(20, 2, 0.1f));
        CreateCube("Fence_Left", new Vector3(-10, 1, 0), new Vector3(0.1f, 2, 20));
        CreateCube("Fence_Right", new Vector3(10, 1, 0), new Vector3(0.1f, 2, 20));

        // اغراض الملعب
        CreateCube("Swings", new Vector3(-6, 1, -6), new Vector3(3, 2, 0.1f));
        CreateCube("Slide", new Vector3(6, 0.5f, -6), new Vector3(1, 1, 3));
        CreateCube("Roundabout", new Vector3(0, 0.1f, 6), new Vector3(3, 0.2f, 3));
        CreateCube("Gate", new Vector3(0, 1, 10), new Vector3(3, 2, 0.1f));

        // 4 اوراق ممزقة - صفرا
        CreateSphere("Page_1", new Vector3(-6, 0.3f, -4), Color.yellow);
        CreateSphere("Page_2", new Vector3(6, 0.3f, -4), Color.yellow);
        CreateSphere("Page_3", new Vector3(-6, 0.3f, 4), Color.yellow);
        CreateSphere("Page_4", new Vector3(6, 0.3f, 4), Color.yellow);

        // 4 waypoints للظل - حمرا
        CreateSphere("Shadow_WP1", new Vector3(-8, 0.3f, -8), Color.red);
        CreateSphere("Shadow_WP2", new Vector3(8, 0.3f, -8), Color.red);
        CreateSphere("Shadow_WP3", new Vector3(8, 0.3f, 8), Color.red);
        CreateSphere("Shadow_WP4", new Vector3(-8, 0.3f, 8), Color.red);

        // بداية ايلياس - خضرا
        CreateSphere("EliasSPAWN", new Vector3(0, 0.3f, -8), Color.green);

        // مكان ظل ليلى - ازرق
        CreateSphere("LaylaSilhouette", new Vector3(0, 0.3f, 9), Color.cyan);
    }

    void CreateCube(string name, Vector3 position, Vector3 scale)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = name;
        cube.transform.position = position;
        cube.transform.localScale = scale;
    }

    void CreateSphere(string name, Vector3 position, Color color)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.name = name;
        sphere.transform.position = position;
        sphere.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);

        Material mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        mat.color = color;
        sphere.GetComponent<Renderer>().material = mat;
    }
}