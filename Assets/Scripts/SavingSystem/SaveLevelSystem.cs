using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;

public static class SaveLevelSystem
{
    public const string FILE_NAME = "/levels.bin";
    public static void SaveLevels(LevelsProgress levelsProgress)
    {
        BinaryFormatter binaryFormatter= new BinaryFormatter();
        string path = Application.persistentDataPath + FILE_NAME;
        FileStream fileStream = new FileStream(path, FileMode.Create);
        Debug.Log(path);

        LevelsProgress data = new LevelsProgress(levelsProgress.isFirstLevel, levelsProgress.isSecondLevel, levelsProgress.isThirdLevel, levelsProgress.isFourthLevel);
        binaryFormatter.Serialize(fileStream, data);
        fileStream.Close();
    }

    public static LevelsProgress LoadLevels()
    {
        string path = Application.persistentDataPath + FILE_NAME;
        if(File.Exists(path))
        {
            BinaryFormatter binaryFormatter= new BinaryFormatter();
            FileStream fileStream = new FileStream(path, FileMode.Open);

            LevelsProgress levelsProgress = binaryFormatter.Deserialize(fileStream) as LevelsProgress;
            fileStream.Close();

            return levelsProgress;
        }
        else
        {
            Debug.Log("An error occured during saving");
            return null;
        }
    }
}
