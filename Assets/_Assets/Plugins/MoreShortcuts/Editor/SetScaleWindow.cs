using UnityEngine;
using UnityEditor;

public class SetScaleWindow : EditorWindow
{
    public static SetScaleWindow Instance = null;
    string ScaleSize = "";
    [MenuItem("MoreShortcuts/SetObjectScale #_s")]
    static void Init()
    {
        SetScaleWindow window = (SetScaleWindow)EditorWindow.GetWindow(typeof(SetScaleWindow));
        window.Show();
    }
    public SetScaleWindow()
    {
        Instance = this;
    }
    void OnGUI()
    {

        ScaleSize = EditorGUILayout.TextField("Scale Size", ScaleSize);
        Instance.Focus();
       // GUIUtility.keyboardControl = 1;
        if (GUILayout.Button("Set Object Scale")) {
            ScaleInp(float.Parse(ScaleSize));
            Close();
            //GUIUtility.keyboardControl = 0;
        }
/*        if (Input.GetKeyDown(KeyCode.KeypadEnter) | Input.GetKeyDown(KeyCode.Return))
        {
            if (ScaleSize != null)
            {
                ScaleInp(float.Parse(ScaleSize));
                Close();
            }
            else
            {
                Close();
            }
        }*/
    }
    public static void ScaleInp(float ScaleValue)
    {
        
        GameObject[] selection = Selection.gameObjects;
            foreach (GameObject go in selection)
        {
            Transform transform = go.transform;
            Undo.RecordObject(transform, "Object Scale");
            go.transform.localScale = new Vector3(ScaleValue, ScaleValue, ScaleValue);
        }
        scene.ShowNotification(new GUIContent("Objects Scale set to " + ScaleValue));

    }
    static SceneView scene = EditorWindow.GetWindow<SceneView>();

}
