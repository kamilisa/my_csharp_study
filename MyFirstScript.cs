using UnityEngine;

public class MyFirstScript : MonoBehaviour
{
    public Vector2 testVector2;
    public Vector3 testVector3;
    public Vector4 testVector4;

    private void Start()
    {
        var aa = new testClass();
        var bb = new testStruct();
        var cc = new testVector();
        aa.Score = -85;
        Debug.LogError(aa.Score);
        Debug.LogError(bb.Score);
    }

    private void Update()
    {

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
                _score = 1314;
            }
        }
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

class testVector
{
    public Vector2 myVector2;
    public Vector3 myVector3;
    public Vector4 myVector4;
}