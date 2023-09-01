using ET.Client.Main;
using FairyGUI;
using UnityEngine;
using Spine.Unity;

namespace ET.Client
{
    public static class LineHelp
    {
        private static FUI_Line line;

        private static Vector2 star;
        

        public static void ShowLine(Vector2 starPos,Vector2 endPos)
        {
            if (line == null)
            {
                line = FUI_Line.CreateInstance();
                line.SetSize(0,0);
                GlobalComponent.Instance.PopUpGRoot.AddChild(line);

            }

            if (starPos != Vector2.zero)
            {
                line.xy = starPos;
                star = starPos;
            }

            if (endPos != Vector2.zero)
            {
                SetPointPos(endPos);
            }
            
            line.visible = true;
        }
        
        public static void HideLine()
        {
            if (line != null)
            {
                line.visible = false;
            }
        }
    

        private static void SetPointPos(Vector2 endPoint)
        {
            var midPoint = Vector2.zero;
            midPoint.x = star.x;
            midPoint.y = (star.y + endPoint.y) * 0.5f;
            
            for (int i = 0; i < line.numChildren; i++)
            {
                float progress = i / (float)(line.numChildren - 1) < 1? i / (float)(line.numChildren - 1) : 0.95f;
                line.GetChildAt(i).xy = line.GlobalToLocal(GetBezier(star,midPoint,endPoint,progress));
            }

            for (int i = 0; i < line.numChildren; i++)
            {
                line.GetChildAt(i).rotation = i < line.numChildren - 1? CalcRotationOfSingleArrow(line.GetChildAt(i).xy, line.GetChildAt(i + 1).xy)
                        : CalcRotationOfSingleArrow(line.GetChildAt(i).xy,line.GlobalToLocal(endPoint));
            }
        }
        
        private static float CalcRotationOfSingleArrow(Vector2 startPoint, Vector2 endPoint)
        {
            Vector2 dir = (endPoint - startPoint).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return angle + 90;
        }
        
        private static Vector2 GetBezier(Vector2 start, Vector2 mid, Vector2 end, float t)
        {
            return (1f - t) * (1f - t) * start + 2 * t * (1f - t) * mid + t * t * end;
        }
        
        
    }
}

