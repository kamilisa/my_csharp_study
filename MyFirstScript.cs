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
        var aa = new testClass();
        var aa_total = testClass.param_list_add(number_list2);
        var bb = new testStruct(777);

        aa.Score = -85;
        Debug.LogError(aa.Score);
        Debug.LogError(bb.Score);

        //操作数组的一些常用方法 通过数组的父类array类来找到更多可操作的方法
        // Array.Reverse(number_list2);
        // Array.Clear(number_list2, 0, 2);

        Debug.LogFormat("多维数组有{0}行，{1}列", number_list3.GetLength(0), number_list3.GetLength(1));
        Debug.LogFormat("参数数组和为{0}", aa_total);
        Nameparam(12, 23f, c: "kami");
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
}


//类
class testClass
{
    //对属性施加奇怪的原生设置，仿佛像方法，但并不是

    public int testnum = 100;
    private int _score;
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
    //**如果给类方法添加static静态 则该方法不需要实例化亦可直接调用
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

