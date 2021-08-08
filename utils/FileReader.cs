using UnityEngine;

namespace Anna.utils
{
    public class FileReader{
        public static string Read(string filePath){
            TextAsset textAsset = Resources.Load<TextAsset>(filePath);
            return textAsset.text;
        }
    }
}