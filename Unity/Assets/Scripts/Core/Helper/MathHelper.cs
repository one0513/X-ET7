using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Unity.Mathematics;

namespace ET
{
	public static class MathHelper
	{

		public static float SqrMagnitude(this float2 self)
		{
			return (float) ((double) self.x * (double) self.x + (double) self.y * (double) self.y);
		}
		
		public static float SqrMagnitude(this float3 self)
		{
			return (float) ((double) self.x * (double) self.x + (double) self.y * (double) self.y + (double) self.z * (double) self.z);
		}

		
	}
}