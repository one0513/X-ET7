using ET.Client.Main;
using UnityEngine;

namespace ET.Client
{
    public static class LineHelp
    {
        private static FUI_Line line;


        public static void ShowLine(Vector2 starPos,Vector2 endPos)
        {
            if (line == null)
            {
                line = FUI_Line.CreateInstance();
                GlobalComponent.Instance.PopUpGRoot.AddChild(line);
            }

            line.xy = starPos;
        }
    

        private static void SetStartPoint(Vector2 pos)
        {

        }
    }
}

