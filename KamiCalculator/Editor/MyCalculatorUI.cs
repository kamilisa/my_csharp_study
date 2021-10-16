using UnityEditor;
using UnityEngine;

public class MyCalculatorUI : EditorWindow
{

    [MenuItem("test/MyCalculatorUI #g", false, 0)]   //加入了快捷键激活 # shift % ctrl & alt  加入了menu排序
    private static void ShowWindow()
    {
        var window = EditorWindow.GetWindow(typeof(MyCalculatorUI));
        window.maximized = true;   //引出属性的get set
        window.minSize = new UnityEngine.Vector2(214, 180);
        // window.maxSize = new UnityEngine.Vector2(214, 180);

        Texture pic_icon = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Kami_CSharp_Study/my_csharp_study/KamiCalculator/Editor/UI_icon/cat.png");
        window.titleContent = new UnityEngine.GUIContent("简易计算器", pic_icon);
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

    //第二个工具的menu测试
    [MenuItem("test/twoTool", false, 1)]
    private static void ShowtwoTool()
    {
        var window = EditorWindow.GetWindow(typeof(MyCalculatorUI));
        window.Show();
    }


    //如果要使用GUIskin作为风格定义，可以通过 EditorGUIUtility.Load 加载guiskin文件，但默认是作为unity object，所以需要在通过强制转换符，转为GUISkin类型
    //将guiskin加载写到OnGui外可优化程序执行效率，避免逐帧调用load 
    //** 必须添加static 否则返回类型被调用会报错
    // private static GUISkin cal_gui_skin = (GUISkin)EditorGUIUtility.Load("Assets/Kami_CSharp_Study/my_csharp_study/KamiCalculator/Editor/GUI_style_file/calculator.guiskin");
    private string number_label = "0";
    private string num1, num2, op;

    //工具运行代码
    private void OnGUI()
    {
        var cal_gui_skin = (GUISkin)EditorGUIUtility.Load("Assets/Kami_CSharp_Study/my_csharp_study/KamiCalculator/Editor/GUI_style_file/calculator.guiskin");

        GUIContent layout_output = new GUIContent("content number");
        // EditorGUILayout.LabelField(layout_output);  函数重载的另一种

        //实例化一个新的GUIstyle 变量,可以自其他style继承，这里选用了编辑器自己的style风格之一
        GUIStyle _laberstyle = new GUIStyle(EditorStyles.textField);
        _laberstyle.fontSize = 25;
        //设置文字大小后让整个布局能被大小影响
        _laberstyle.wordWrap = true;

        // EditorGUILayout.LabelField("number output", _laberstyle);
        EditorGUILayout.LabelField(number_label, cal_gui_skin.textField);
        EditorGUILayout.BeginHorizontal();
        {
            //添加一个editor自己的style，这个style自带一个不错的描边
            EditorGUILayout.BeginVertical(cal_gui_skin.box);
            {

                EditorGUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("7", cal_gui_skin.button))
                    {
                        number_label = number_label == "0" ? "7" : number_label += "7";
                    }
                    if (GUILayout.Button("8", cal_gui_skin.button))
                    {
                        number_label = number_label == "0" ? "8" : number_label += "8";
                    }
                    if (GUILayout.Button("9", cal_gui_skin.button))
                    {
                        number_label = number_label == "0" ? "9" : number_label += "9";
                    }
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("4", cal_gui_skin.button))
                    {
                        number_label = number_label == "0" ? "4" : number_label += "4";
                    }
                    if (GUILayout.Button("5", cal_gui_skin.button))
                    {
                        number_label = number_label == "0" ? "5" : number_label += "5";
                    }
                    if (GUILayout.Button("6", cal_gui_skin.button))
                    {
                        number_label = number_label == "0" ? "6" : number_label += "6";
                    }
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("1", cal_gui_skin.button))
                    {
                        number_label = number_label == "0" ? "1" : number_label += "1";
                    }
                    if (GUILayout.Button("2", cal_gui_skin.button))
                    {
                        number_label = number_label == "0" ? "2" : number_label += "2";
                    }
                    if (GUILayout.Button("3", cal_gui_skin.button))
                    {
                        number_label = number_label == "0" ? "3" : number_label += "3";
                    }
                }
                EditorGUILayout.EndHorizontal();

                EditorGUILayout.BeginHorizontal();
                {
                    if (GUILayout.Button("0", cal_gui_skin.button))
                    {
                        number_label = number_label == "0" ? "0" : number_label += "0";
                    }
                    if (GUILayout.Button("C", cal_gui_skin.button))
                    {
                        number_label = "0";
                    }

                    //等于运算
                    if (GUILayout.Button("=", cal_gui_skin.button))
                    {
                        num2 = number_label;
                        if (op == "+")
                        {
                            number_label = num1 + num2;
                        }
                        else if (op == "-")
                        {

                        }
                        else if (op == "x")
                        {

                        }
                        else if (op == "/")
                        {

                        }
                    }
                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(cal_gui_skin.box);
            {
                if (GUILayout.Button("+", cal_gui_skin.button))
                {
                    num1 = number_label;
                    number_label = "0";
                    op = "+";
                }
                if (GUILayout.Button("-", cal_gui_skin.button))
                {
                    num1 = number_label;
                    number_label = "0";
                    op = "-";
                }
                if (GUILayout.Button("x", cal_gui_skin.button))
                {
                    num1 = number_label;
                    number_label = "0";
                    op = "x";
                }
                if (GUILayout.Button("/", cal_gui_skin.button))
                {
                    num1 = number_label;
                    number_label = "0";
                    op = "/";
                }
            }
            EditorGUILayout.EndVertical();
        }
        EditorGUILayout.EndHorizontal();
    }
}
