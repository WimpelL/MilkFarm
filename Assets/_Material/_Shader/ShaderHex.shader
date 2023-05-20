Shader "TestShader/ShaderHex"
{

    Properties
    {
        _MainTex ("Main texture", 2D) = "black" {}
        _MaskTex ("Mask texture", 2D) = "black" {}
        _Color ("Emission Color", Color) = (0.5,0,1,1)

        _MaskTexCotoff ("Mask Cotoff", 2D) = "black" {}
        _Cotoff ("Alpha Cotoff", Range(0,1) ) = 0.5

    }
    SubShader
    {
        Tags
        {
            "Queue" = "AlphaTest"
            "RenderType"="TransparentCutout"
            "IgnoreProjector" = "True" 
        }
        LOD 200
        Cull Off

        CGPROGRAM
        
        #pragma surface surf Lambert alphatest:_Cotoff
        
        sampler2D _MainTex;
        sampler2D _MaskTex;
        sampler2D _MaskTexCotoff;

         
        UNITY_INSTANCING_BUFFER_START(Props)
            UNITY_DEFINE_INSTANCED_PROP(fixed3, _Color) 
        UNITY_INSTANCING_BUFFER_END(Props)

        struct Input 
        {
            half2 uv_MainTex;
            half2 uv_MaskTex;
            half2 uv_MaskTexCotoff;

        };
        void surf(Input IN , inout SurfaceOutput o)
        {
            fixed4 masks = tex2D(_MaskTex, IN.uv_MaskTex);
            fixed4 colorMask = tex2D(_MainTex, IN.uv_MainTex) * masks;
            fixed4 maskTex =  tex2D(_MaskTexCotoff, IN.uv_MaskTexCotoff) ;
            o.Albedo = colorMask.rgb; 
            o.Emission = UNITY_ACCESS_INSTANCED_PROP(_Props, _Color); 
            o.Alpha = maskTex.b;

           
        }

        ENDCG
    }
    //Варіант СубШейдера для разного заліза
    //SubShader
    //{
    //
    //}
    
    //Кінцевий Варіант СубШейдера, коли Юніті не змогла запустити їх
    Fallback "Diffuse"

}

   
