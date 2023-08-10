using System;
using System.Collections.Generic;
using ET.Client.Common;
using FairyGUI;
using UnityEngine;

namespace ET.Client
{
    public static class TipsHelp
    {
        private static List<FUI_BigTipPanel> _bigTipsList = new List<FUI_BigTipPanel>();
        
        public static void ShowTips(string msg)
        {
            if (_bigTipsList.Count > 1)
            {
                FUI_BigTipPanel topNode = _bigTipsList[_bigTipsList.Count - 1];
                _bigTipsList.RemoveAt(_bigTipsList.Count - 1);
                topNode.msg.text = msg;
                SetTip(topNode).Coroutine();
            }
            else
            {
                FUI_BigTipPanel tip = FUI_BigTipPanel.CreateInstance();
                tip.msg.text = msg;
                SetTip(tip).Coroutine();
            }
            
        }

        private static async ETTask SetTip(FUI_BigTipPanel tipPanel)
        {
            GlobalComponent.Instance.PopUpGRoot.AddChild(tipPanel);
            tipPanel.width = GRoot.inst.width;
            tipPanel.pivot = new Vector2(0.5f, 0.5f);
            tipPanel.alpha = 0;
            tipPanel.scale = new Vector2(1f, 0.1f);
            var stageHeight = GRoot.inst.height;
            tipPanel.xy = new Vector2(GRoot.inst.width*0.5f, stageHeight * 0.5f);

            tipPanel.TweenFade(1, 0.1f);
            tipPanel.TweenScale(Vector2.one, 0.2f).SetEase(EaseType.BackOut);
            tipPanel.TweenMoveY(-stageHeight * 0.1f + Math.Min(_bigTipsList.Count, 15) * 20f, 1.2f).SetEase(EaseType.SineOut).SetDelay(0.3f);
            tipPanel.TweenFade(0, 0.2f).SetDelay(1.5f);
            await TimerComponent.Instance.WaitAsync(1700);
            _bigTipsList.Add(tipPanel);
        }
        
    }
}

