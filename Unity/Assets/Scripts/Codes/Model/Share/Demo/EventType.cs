﻿namespace ET
{
    namespace EventType
    {
        public struct SceneChangeStart
        {
        }
        
        public struct SceneChangeFinish
        {
        }
        
        public struct AfterCreateClientScene
        {
        }
        
        public struct AfterCreateCurrentScene
        {
        }

        public struct AppStartInitFinish
        {
        }

        public struct LoginFinish
        {
        }

        public struct EnterMapFinish
        {
        }

        public struct AfterUnitCreate
        {
            public Unit Unit;
        }
        
        public struct PlaySound
        {
            public string Path;
        }
        
        public struct AddEffect
        {
            public int EffectId;
            public Unit Unit;
            public Entity Parent;
        }
    }
}