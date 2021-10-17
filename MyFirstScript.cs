using UnityEngine;
using System;


public class MyFirstScript : MonoBehaviour
{
    // 向量：二维
    public Vector2 testVector2;
    // 向量：三维
    public Vector3 testVector3;
    // 向量：四维
    public Vector4 testVector4;

    // 声明枚举
    public enum God
    {
        Kami,  //枚举成员其实就是 常量const
        Lisa,
        Hilo
    }
    public God God_mem;  //实例化枚举

    // 数组：不初始化参数值，只设定数组长度
    public int[] number_list = new int[4];
    // 数组：初始化参数
    public int[] number_list2 = new int[5] { 123, 545, 11, 22, 567 };
    // 数组：秩不同的数组
    public int[,] number_list3 = new int[2, 2]{
        {11,22},
        {33,44}
    };

    private void Start()
    {
        var aa = new testClass(); //变量值为类的实例，若该变量被方法传参，则称为形参
        var aa_total = testClass.param_list_add(number_list2);  // 测试不实例化，直接使用类方法
        var bb = new testStruct(777); //测试初始化结构体

        aa.Score = -85;
        Debug.LogError(aa.Score); //测试类属性的 get set
        Debug.LogError(bb.Score); //测试类属性打印结果

        //操作数组的一些常用方法 通过数组的父类array类来找到更多可操作的方法
        // Array.Reverse(number_list2);
        // Array.Clear(number_list2, 0, 2);

        Debug.LogFormat("多维数组有{0}行，{1}列", number_list3.GetLength(0), number_list3.GetLength(1));
        Debug.LogFormat("参数数组和为{0}", aa_total);

        if (God_mem == God.Hilo || (int)God_mem == 1) //两种枚举用于if的条件方法
        {
            // Debug.LogFormat("枚举的输出值为{0}", God_mem);
        }
        //swich分支配合枚举
        switch (God_mem)
        {
            case God.Hilo:
                Debug.Log(God.Hilo);
                break;
            case God.Kami:
                Debug.Log(God.Kami);
                break;
            default:
                Debug.Log("wow,wonderful~~~");
                break;
        }


        //测试命名参数
        Nameparam(12, 23f, c: "kami");

        //字符转换
        int number_1 = 22;
        float number_2 = number_1; //隐式转换 int to float
        string number_3 = "113";
        number_1 = int.Parse(number_3); //显式转换，string to int
        number_3 = number_1.ToString(); //显式转换，int to string


        //** 高级语法特性 **//
        int a_t_1 = 10;  //变量值为实际类型，若该类变量被方法传参，则称为实参
        //实参复制为的形参，因此方法计算的结果只改变形参而不影响原始实参 a_t_1 依然为10，aa因为是类的实例，实例作为形参被改写为30
        advance_test_2(a_t_1, aa);
        Debug.LogFormat("a 为 {0}， b 为 {1}", a_t_1, aa.B);

        int a_t_2 = 10;
        //原始实参被引用为形参，而不复制，因此方法计算直接作用于原始实参本身  a_t_2 被改写为 20 ，aa 则 因为本身就是类的实例 实例本身即引用参数，再次被重复引用，所以作为形参依然被改写为30
        advance_test_3(ref a_t_2, ref aa);
        Debug.LogFormat("a 为 {0}， b 为 {1}", a_t_2, aa.C);

        //对于输出参数，虽然原始传入参数有做过初始化，但输出参数内部需要重新初始化，因此最终被新的输出结果改写原始值，换言之输出参数不在意原始传入参数的值
        int a_t_3 = 10;
        advance_test_4(out a_t_3, out aa);
        Debug.LogFormat("a 为 {0}， b 为 {1}", a_t_3, aa.D);


    }

    //运行中逐帧执行的函数
    private void Update()
    {
    }

    //命名参数：样本
    private void Nameparam(int a, float b, string c)
    {
        Debug.LogFormat("a是{0}, b是{1}, c是{2}", a, b, c);
    }

    //高阶语法特性 ：类参数
    void advance_test_2(int a, testClass b)
    {
        a = a + 10;
        b.B = b.B + 10;
    }

    //高阶语法特性 ：引用参数
    void advance_test_3(ref int a, ref testClass b)
    {
        a = a + 10;
        b.C = b.C + 10;
    }

    //高阶语法特性 ： 输出参数
    void advance_test_4(out int a, out testClass b)
    {
        //输出参数必须在方法内部对参数重新初始化，且将计算结果传回传入参数本体，如果不进行初始化则无法使用
        a = 30;
        b = new testClass();
        a = a + 10;
        b.D = b.D + 10;
    }

}


//类
class testClass
{

    public const int rigid = 100; //常量，声明后不可被外部改写，存于栈
    public int B = 20;
    public int C = 20;
    public int D = 20;
    private int _score;
    //对属性成员施加奇怪的原生设置，仿佛像方法，但并不是
    public int Score
    {
        get
        {
            return _score;
        }

        set
        {
            if (value >= 0 && value < 100)
            {
                _score = value;
            }
            else
            {
                Debug.LogError("输入的数值不在0-100之间");
            }
        }
    }

    //测试参数数组
    //**如果给类方法添加static 则该方法不需要实例化亦可直接调用
    public static int param_list_add(params int[] values)
    {
        int num = 0;
        for (int i = 0; i < values.Length; i++)
        {
            num += values[i];
        }
        return num;
    }

}

//结构
struct testStruct
{
    //结构体的属性不可以直接赋值，必须在其构造函数内才能赋值，这是和类的本质区别
    //public int score = 100;  错误

    public int Score;
    public testStruct(int _score)
    {
        Score = _score;
    }
}

