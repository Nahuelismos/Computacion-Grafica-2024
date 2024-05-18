Shader "TexturaProcedural/MarmolComun"
{
	Properties
	{
		_ku("ku", Range(2,500)) = 30
		_kv("kv", Range(2,500)) = 30
		_Density("Density", Range(2,500)) = 30
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
			float _ku;
			float _kv;

			float2 random2(float2 st) {
				st = float2(dot(st, float2(127.1, 311.7)),
					dot(st, float2(269.5, 183.3)));
				return -1.0 + 2.0 * frac(sin(st) * 43758.5453123);
			}

			float noise(float2 st) {
				float2 i = floor(st);
				float2 f = frac(st);

				float2 u = f * f * f * (f * (f * 6. - 15.) + 10.);
				return lerp(lerp(dot(random2(i + float2(0.0, 0.0)), f - float2(0.0, 0.0)),
					dot(random2(i + float2(1.0, 0.0)), f - float2(1.0, 0.0)), u.x),
					lerp(dot(random2(i + float2(0.0, 1.0)), f - float2(0.0, 1.0)),
						dot(random2(i + float2(1.0, 1.0)), f - float2(1.0, 1.0)), u.x), u.y);
			}

			float marble(float u, float v)
			{
				float f = 0.0;
				f = noise(float2(u, v));
				//f = 0.5 + 0.5 * f;
				return sin(_ku * u + _kv * v+ _Density*f);
			}

			v2f vert(float4 pos : POSITION, float2 uv : TEXCOORD0)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(pos);
				o.uv = uv;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 fragColor = 0;
				float c=marble(i.uv.x,i.uv.y);
				fragColor = fixed4(c,c,c, 1.0);

				return fragColor;
			}
			ENDCG
		}
	}
}