Shader "TexturaProcedural/Pared de Ladrillos"
{
	Properties
	{
		_Density("Density", Range(2,50)) = 30
		_Division("Division", Range(2,50)) = 2
		_Intensity("Intensity", Range(2,50)) = 2
		_v1("v1",Range(0.0,1)) = 0
		_v2("v2",Range(0.0,1)) = 0
		_v3("v3",Range(0.0,1)) = 0
		_Color1 ("Color1", Color) = (1, 1, 1, 1)
	}
		SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			float _Density;
			float _Division;
			float _Intensity;
			float _v1, _v2, _v3;
			float4 _Color1;
			v2f vert(float4 pos : POSITION, float2 uv : TEXCOORD0)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(pos);
				o.uv = uv * _Density;
				return o;
			}
			float random (float2 uv) {
                return frac(sin(dot(uv,float2(12.9898,78.233)))*43758.5453123);
            }
			fixed4 frag(v2f i) : SV_Target{
				fixed4 fragColor = 0;
				float M = _Division;
				float N = _Density;
				float G = 1.0 / M;
				float F = 1.0 / N;
				float x = fmod(i.uv.x, M) / M;
				float y = fmod(i.uv.y, M) / M;
				float2 c1 = i.uv;
				float2 c = floor(c1);
				float r1 = random(c1);
				float r = random(c);
				if(floor(c.y)%2 != 0){
					fragColor.x = smoothstep(0, 0.1, x);
					fragColor.y = _Intensity*(1-smoothstep(2, 1.3, 2*y));
				}else{
					fragColor.x = 1-smoothstep(0.5, 0.55, x)+smoothstep(0.55,0.6,x);
					fragColor.y = _Intensity*(1-smoothstep(0.85, 0.0, y));
				}
				//fragColor.rgb= float3 (fragColor.x+_v1,fragColor.y+_v2,_v3)*_Color1*r; 
				//baño
				fragColor.rgb= float3(fragColor.x*_v1+r1/2, fragColor.y*_v2, _v3)*_Color1; 
				//ladrillo

				return fragColor;
			}
			ENDCG
		}
	}
}