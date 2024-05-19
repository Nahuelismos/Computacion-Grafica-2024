Shader "TexturaProcedural/Pared de Ladrillos"
{
	Properties
	{
		_Density("Density", Range(2,50)) = 30
		_Division("Division", Range(2,50)) = 2
		_v1("v1",Range(0.0,2)) = 0
		_v2("v2",Range(0.0,2)) = 0
		_v3("v3",Range(0.0,2)) = 0
		_v4("v4",Range(0.0,2)) = 0
		_Color1 ("Color1", Color) = (1, 1, 1, 1)
		_Color2 ("Color2", Color) = (1, 1, 1, 1)
		_Color3 ("Color3", Color) = (1, 1, 1, 1)
		_Color4 ("Color4", Color) = (1, 1, 1, 1)
		_Color5 ("Color1", Color) = (1, 1, 1, 1)
		_Color6 ("Color2", Color) = (1, 1, 1, 1)
		_Color7 ("Color3", Color) = (1, 1, 1, 1)
		_Color8 ("Color4", Color) = (1, 1, 1, 1)
		_Color9 ("Color1", Color) = (1, 1, 1, 1)
		_Color10 ("Color2", Color) = (1, 1, 1, 1)
		_Color11 ("Color3", Color) = (1, 1, 1, 1)
		_Color12 ("Color4", Color) = (1, 1, 1, 1)
		_Color13 ("Color1", Color) = (1, 1, 1, 1)
		_Color14 ("Color2", Color) = (1, 1, 1, 1)
		_Color15 ("Color3", Color) = (1, 1, 1, 1)
		_Color16 ("Color4", Color) = (1, 1, 1, 1)
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
			float _v1, _v2, _v3, _v4;
			float4 _Color1, _Color2, _Color3, _Color4;
			float4 _Color5, _Color6, _Color7, _Color8;
			float4 _Color9, _Color10, _Color11, _Color12;
			float4 _Color13, _Color14, _Color15, _Color16;
			v2f vert(float4 pos : POSITION, float2 uv : TEXCOORD0)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(pos);
				o.uv = uv * _Density;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				
				fixed4 fragColor = 0;
				float M = _Division;
				float N = _Density;
				float G = 1.0 / M;
				float F = 1.0 / N;
				float x = fmod(i.uv.x, M) / M;
				float y = fmod(i.uv.y, M) / M;
				float2 c = i.uv;
				c = floor(c);
				float varx1 = smoothstep(0, 0.1, x);
				float vary1 = smoothstep(1, 1.3, 2*y);
				float varx2 = 1-smoothstep(0.5, 0.55, x)+smoothstep(0.55,0.6,x);
				float vary2 = smoothstep(0, 0.15, y);
				if(floor(c.y)%2 != 0){
					fragColor.x =  varx1;
					fragColor.y = vary1;
				}else{
					fragColor.x = varx2;
					fragColor.y = vary2;
				}
				if(fragColor.x == varx1) && (fragColor.x == varx2) && (fragColor.y == vary1) && (fragColor.y == vary2)){
					fragColor = _Color1; //x1x2y1y2
				} else if(fragColor.x == varx1) && (fragColor.x == varx2) && (fragColor.y == vary1) && (fragColor.y != vary2)){
					fragColor = _Color2; //x1x2y1y2
				} else if(fragColor.x == varx1) && (fragColor.x == varx2) && (fragColor.y != vary1) && (fragColor.y == vary2)){
					fragColor = _Color3; //x1x2y1y2
				} else if(fragColor.x == varx1) && (fragColor.x == varx2) && (fragColor.y != vary1) && (fragColor.y != vary2)){
					fragColor = _Color4; //x1x2y1y2
				} else if(fragColor.x == varx1) && (fragColor.x != varx2) && (fragColor.y == vary1) && (fragColor.y == vary2)){
					fragColor = _Color5; //x1x2y1y2
				} else if(fragColor.x == varx1) && (fragColor.x != varx2) && (fragColor.y == vary1) && (fragColor.y != vary2)){
					fragColor = _Color6; //x1x2y1y2
				} else if(fragColor.x == varx1) && (fragColor.x != varx2) && (fragColor.y != vary1) && (fragColor.y == vary2)){
					fragColor = _Color7; //x1x2y1y2
				} else if(fragColor.x == varx1) && (fragColor.x != varx2) && (fragColor.y != vary1) && (fragColor.y != vary2)){
					fragColor = _Color8; //x1x2y1y2
				} else if(fragColor.x != varx1) && (fragColor.x == varx2) && (fragColor.y == vary1) && (fragColor.y == vary2)){
					fragColor = _Color9; //x1x2y1y2
				} else if(fragColor.x != varx1) && (fragColor.x == varx2) && (fragColor.y == vary1) && (fragColor.y != vary2)){
					fragColor = _Color10; //x1x2y1y2
				} else if(fragColor.x != varx1) && (fragColor.x == varx2) && (fragColor.y != vary1) && (fragColor.y == vary2)){
					fragColor = _Color11; //x1x2y1y2
				} else if(fragColor.x != varx1) && (fragColor.x == varx2) && (fragColor.y != vary1) && (fragColor.y != vary2)){
					fragColor = _Color12; //x1x2y1y2
				} else if(fragColor.x != varx1) && (fragColor.x != varx2) && (fragColor.y == vary1) && (fragColor.y == vary2)){
					fragColor = _Color13; //x1x2y1y2
				} else if(fragColor.x != varx1) && (fragColor.x != varx2) && (fragColor.y == vary1) && (fragColor.y != vary2)){
					fragColor = _Color14; //x1x2y1y2
				} else if(fragColor.x != varx1) && (fragColor.x != varx2) && (fragColor.y != vary1) && (fragColor.y == vary2)){
					fragColor = _Color15; //x1x2y1y2
				} else if(fragColor.x != varx1) && (fragColor.x != varx2) && (fragColor.y != vary1) && (fragColor.y != vary2)){
					fragColor = _Color16; //x1x2y1y2
				}
				/*if(fragColor.x == varx1 && fragColor.y == vary1 && fragColor.y != vary2){
					fragColor = _Color2;
				}else{
					fragColor = _Color1;
				} else 
				if(fragColor.x == varx2 && fragColor.y != vary1 && fragColor.y == vary2)
					fragColor = _Color3;*/
				return fragColor;
			}
			ENDCG
		}
	}
}