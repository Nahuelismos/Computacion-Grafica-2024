Shader "ShaderCook-Torrance"
{
    Properties
    {//Luz descartivar en negro la intensidad
        _LightIntensity("Intensidad luz", Color) = (1,1,1,1)
        _LightPosition_W("Posicion luz_W", Vector) = (0,0,0,1)
        _AmbientLight("Luz ambiente", Color) = (1,1,1,1)

        _MaterialKa("Ka Material", Vector) = (0,0,0,0)
        _MaterialKd("Kd Material", Vector) = (0,0,0,0)
        _Fresnel("Reflectancia de Fresnel", color) = (0,0,0)
        _Rugosidad("Rugosidad", Range(0,1)) = 0
    }

    SubShader// textura 
    {
       Pass{
            CGPROGRAM
            #pragma vertex vertexShader
            #pragma fragment fragmentShader
            #include "UnityCG.cginc"

            //Estructura de un vertice
            struct vertice{
                float4 position : POSITION;// Posicion en coordenas homogeneas (x,y,z,w)
                float3 normal : NORMAL; //normal del vertice
            };

            //Estructura que toma vertices y los va a pasar a las coordenas del mundo
            struct v2f{
                float4 vertex : SV_POSITION;
                float4 position_w : TEXCOORD1;
                float3 normal_w : TEXCOORD2;
            };

            //Declaro las variables de propiedad:
            float4 _LightIntensity, _LightPosition_W, _AmbientLight;
            float4 _MaterialKd, _MaterialKa;
            fixed3 _Fresnel;
            float _Rugosidad;

            float3 aproxFresnel_Smith(float3 V, float3 H)
            {
                float3 F0 = _Fresnel;
                return F0 + (1 - F0) * pow(1.0 -  max(0, dot(V,H)) , 5);
            }

            float distribucionNormalesGGX(float3 N, float3 H)
            {
                const float PI = 3.14159265;
                float alpha = pow(_Rugosidad, 2);
                float denominador = PI * pow(pow(max( 0 , dot(N,H) ), 2) * (alpha - 1) +1, 2 ) ;
                return alpha / denominador;
            }

            float aproximacionSchlickGGX(float3 M, float3 N)
            {
                float alpha = pow(_Rugosidad, 2);
                float k = alpha / 2;
                float cosMN = max(0, dot(M,N));

                float denominador = (cosMN * (1 - k)) + k;

                return cosMN / denominador;
            }

            float enmascaradoSombras_Smith(float3 L, float3 V, float3 N)
            {
                float G1L = aproximacionSchlickGGX(L, N);
                float G1V = aproximacionSchlickGGX(V, N);
                return G1L*G1V;
            }


            //Se encarga de dar coordenadas del mundo
            v2f vertexShader(vertice v){
                float4 position_w = mul(unity_ObjectToWorld, v.position); //Paso las coordenas del vertice a coordenas del mundo.
                float3 normal_w = UnityObjectToWorldNormal(v.normal); //Normalizo para facilitar cuentas la normal y la paso a coordenadas del mundo.

                v2f output;
                output.vertex = UnityObjectToClipPos(v.position);
                output.position_w = position_w;
                output.normal_w = normal_w;

                return output;
            }

            fixed4 fragmentShader (v2f f) : SV_Target{
                fixed4 fragColor = 0;
                float3 N = normalize(f.normal_w);//Vector normal al fragmento
                float3 L = normalize(_LightPosition_W.xyz - f.position_w.xyz);//Vector luz como llega al fragmento
                float3 V = normalize(_WorldSpaceCameraPos - f.position_w); //Vector desde donde miro hasta el fragmento a iluminar 
                float3 H = (L + V) / 2;

                //-------------------------------------------//
                //           Factor ambiente                 //
                //-------------------------------------------//
                float3 ambiente = _AmbientLight.xyz * _MaterialKa;

                //-------------------------------------------//
                //             Factor difuso                 //
                //-------------------------------------------//
                //Para este utilizo el de Phong y lo divido por PI:
                float3 luzDifusa = 1 * _LightIntensity.xyz;
                float3 reflexionDifusa = _MaterialKd * ( max(0,dot(N,L)) );

                float3 difuso = (luzDifusa * reflexionDifusa)/3.14159265 ;

                //-------------------------------------------//
                //             Factor especular              //
                //-------------------------------------------//
                //Reflectancia de Fresnel F(V,H):
                float3 F = aproxFresnel_Smith(V,H);
                
                //Funcion distribucion de normales D(h) usando GGX:
                float D = distribucionNormalesGGX(N,H);

                //Funcion de Geometria GSmith  
                float G = enmascaradoSombras_Smith(L,V,N);

                float3 especular = F*D*G/(4 * max(0,dot(N,L)) * max(0, dot(N,V)));

                fragColor.rgb = ambiente + (difuso + especular) * dot(N,L) ;

                return fragColor;
            }

            ENDCG
       }
    }
    FallBack "Diffuse"
}

