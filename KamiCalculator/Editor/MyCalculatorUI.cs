using UnityEditor;
using UnityEngine;

public class MyCalculatorUI : EditorWindow
{
    [MenuItem("test/MyCalculatorUI #g", false, 1)]   //加入了快捷键激活 # shift % ctrl & alt  加入了menu排序
    private static void ShowWindow()
    {
        var window = EditorWindow.GetWindow(typeof(MyCalculatorUI));
        window.maximized = true;   //引出属性的get set
        // window.minSize = new UnityEngine.Vector2(100, 300);
        Texture pic_icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Kami_CSharp_Study/KamiCalculator/Editor/UI_icon/cat.png");
        window.titleContent = new UnityEngine.GUIContent("kami cal", pic_icon);
        window.Show();
    }

    //打开UI验证
    [MenuItem("test/MyCalculatorUI #g", true)]
    private static bool ShowValidate()
    {
        if (Selection.activeGameObject != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    [MenuItem("test/twoTool #g", false, 0)]   //加入了快捷键激活 # shift % ctrl & alt
    private static void ShowtwoTool()
    {
        var window = EditorWindow.GetWindow(typeof(MyCalculatorUI));
        window.Show();
    }

    private void OnGUI()
    {
    }
}
