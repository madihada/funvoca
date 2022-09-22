using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class python_manager : MonoBehaviour
{

    void Start()
    {
        GameManager.OnMonsterDie += RunPythonScript;
    }
    public void RunPythonScript()
    {
        string path = Application.dataPath + "/08.Python/log_names.py";
        PythonRunner.RunFile(path);
        Debug.Log(GameManager.instance.pythonResult);
    }
}
