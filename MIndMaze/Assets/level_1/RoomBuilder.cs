using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class RoomBuilder : MonoBehaviour
{
#if UNITY_EDITOR
    [ContextMenu("Build Room")]
#endif
    public void BuildRoom()
    {
        // الارضية
        CreateCube("Floor", new Vector3(0, 0, 0), new Vector3(5, 0.1f, 5));

        // الحيطان - الاوضة 5x5x3
        CreateCube("Wall_Back", new Vector3(0, 1.5f, -2.5f), new Vector3(5, 3, 0.1f));
        CreateCube("Wall_Front", new Vector3(0, 1.5f, 2.5f), new Vector3(5, 3, 0.1f));
        CreateCube("Wall_Left", new Vector3(-2.5f, 1.5f, 0), new Vector3(0.1f, 3, 5));
        CreateCube("Wall_Right", new Vector3(2.5f, 1.5f, 0), new Vector3(0.1f, 3, 5));
        CreateCube("Ceiling", new Vector3(0, 3, 0), new Vector3(5, 0.1f, 5));

        // الكوريدور - عرضه 3 متر
        CreateCube("Corridor_Floor", new Vector3(0, 0, 5), new Vector3(3, 0.1f, 6));
        CreateCube("Corridor_Left", new Vector3(-1.5f, 1.5f, 5), new Vector3(0.1f, 3, 6));
        CreateCube("Corridor_Right", new Vector3(1.5f, 1.5f, 5), new Vector3(0.1f, 3, 6));
        CreateCube("Corridor_Ceil", new Vector3(0, 3, 5), new Vector3(3, 0.1f, 6));

        // اغراض اللغز
        CreateCube("Calendar", new Vector3(-2, 2, -2.4f), new Vector3(0.5f, 0.7f, 0.05f));
        CreateCube("Photo", new Vector3(1, 1.2f, -2.4f), new Vector3(0.4f, 0.5f, 0.05f));
        CreateCube("LockedBox", new Vector3(2, 1.5f, -2.4f), new Vector3(0.4f, 0.3f, 0.3f));
        CreateCube("Diary", new Vector3(0, 1f, -2.4f), new Vector3(0.5f, 0.05f, 0.4f));

        // سفيرز صفرا - اماكن التفاعل
        CreateSphere("Trigger_Calendar", new Vector3(-2, 2, -2f), Color.yellow);
        CreateSphere("Trigger_Photo", new Vector3(1, 1.2f, -2f), Color.yellow);
        CreateSphere("Trigger_LockedBox", new Vector3(2, 1.5f, -2f), Color.yellow);
        CreateSphere("Trigger_Diary", new Vector3(0, 1f, -2f), Color.yellow);

        // نقطة بداية ايلياس - خضرا
        CreateSphere("EliasSPAWN", new Vector3(0, 0.1f, 7), Color.green);
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