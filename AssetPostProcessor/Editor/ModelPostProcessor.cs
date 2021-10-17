
using UnityEngine;
using UnityEditor;

public class ModelPostProcessor : AssetPostprocessor  //资源导入判定相关的继承类
{
    const string Path = "Assets/Kami_CSharp_Study/my_csharp_study/Arts/Model/";
    void OnPreprocessModel()  //发生于导入模型执行前的事件监听
    {
        if (assetPath.Contains(Path) == false) //判断是否包含指定文件夹路径
        {
            return;
        }
        ModelImporter importer = (ModelImporter)assetImporter;  //将Unity顶级导入器类转换为子级模型导入器类，进而方便调用
        importer.globalScale = 1.0f;
        importer.useFileUnits = true;
        importer.importBlendShapes = true;
        importer.isReadable = false; //导入的模型是否只读，否
        importer.meshCompression = ModelImporterMeshCompression.Off; //枚举类
        Debug.Log("okokok");
    }
}
