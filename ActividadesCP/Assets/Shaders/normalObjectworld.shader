Shader "Lighting/normalObjectworld"{
	Properties{
		_MaterialColor ("Material Color",Color)=(0.25,0.5,0.5,1)
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
		
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			struct vertexData {
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct v2f {
				float4 vertex : SV_POSITION;
				float3 normal_w : TEXTCOORD0;  
			};

			
			v2f vert(vertexData v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.normal_w = UnityObjectToWorldNormal(v.normal);
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 fragColor = 0;
				fragColor.rgb = i.normal_w*0.5+0.5;
				return fragColor;
			}
			ENDCG
		}
	}
}