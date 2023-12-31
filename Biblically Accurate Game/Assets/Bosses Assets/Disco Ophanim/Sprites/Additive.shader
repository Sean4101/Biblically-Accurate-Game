Shader"Unlit/ScreenBlend"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1) // Add this line for color property
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent"}
LOD 100

        Blend
OneMinusDstColor One

Zwrite Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

#include "UnityCG.cginc"

struct appdata
{
    float4 vertex : POSITION;
    float2 uv : TEXCOORD0;
};

struct v2f
{
    float2 uv : TEXCOORD0;
    float4 vertex : SV_POSITION;
    fixed4 color : COLOR; // Existing line
};

fixed4 _Color; // Color variable
sampler2D _MainTex;
float4 _MainTex_ST;

v2f vert(appdata v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
    return o;
}

fixed4 frag(v2f i) : SV_Target
{
    fixed4 col = tex2D(_MainTex, i.uv);
    col *= _Color; // Modify this line to multiply by the color parameter
    col *= _Color.a; // Add this line to multiply by the alpha of the color parameter
    return col;
}
            ENDCG
        }
    }
}
