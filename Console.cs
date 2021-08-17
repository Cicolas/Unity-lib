using UnityEngine;

namespace Anna.Console
{
    public class Console : MonoBehaviour {
        public KeyCode keyCode = KeyCode.BackQuote;
        
        private void Update() {
            if (Input.GetKeyDown(keyCode))
            {
                Time.timeScale = (Time.timeScale == 0)?1.0f:0.0f;
            }
        }

        public void SetConsoleKey(KeyCode key){
            keyCode = key;
        }
    }
}