Shader "TestShader/TestB"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "black" {}
        _Cotoff ("Alpha Cotoff", Range(0,1) ) = 0.5
    }
    SubShader
    {
        Tags {
            "Queue" = "AlphaTest"
            "RenderType"="TransparentCutout"
            "IgnoreProjector" = "True" 
            }
        LOD 200
        Cull Off

        CGPROGRAM
        
        #pragma surface surf Lambert alphatest:_Cotoff

        sampler2D _MainTex;
      

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf (Input IN, inout SurfaceOutput o)
        {

            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            o.Alpha = c.b;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
