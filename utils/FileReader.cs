using UnityEngine;

namespace Anna.utils
{
    /// <summary>
    /// This script can be used to easily read documents.
    /// </summary>
    public class FileReader{
        public static string Read(string filePath){
            TextAsset textAsset = Resources.Load<TextAsset>(filePath);
            return textAsset.text;
        }
    }
}