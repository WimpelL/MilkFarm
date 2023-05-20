Shader "TestShader/ShaderMap" 

{
    // ShaderLab
    Properties
    {
        //Створюємо текстуру в Юнити
        _MainTex ("Main texture 1", 2D) = "white" {}

        _MaskTex ("Mask texture", 2D) = "black" {}
        _MaskRed ("Mask Red", 2D) = "black" {}
        _MaskGrean ("Mask Grean", 2D) = "black" {}
        _MaskBlue ("Mask Blue", 2D) = "black" {}

    }
    // Варіант СубШейдера для разного заліза
    SubShader
    {
        // тут стврорено SJFX - cod
        CGPROGRAM
        // Ініціація шейдер структури, де surf - функція, Lambert - освітлення
        #pragma surface surf Lambert
        // Створюємо текстуру в SJFX. як що в  Properties імена SubShaderб
        // зміна з Prop... автоматично передає данні.
        sampler2D _MainTex;

        sampler2D _MaskTex;
        sampler2D _MaskRed;
        sampler2D _MaskGrean;
        sampler2D _MaskBlue;


        // створюємо структуру
        struct Input 
        {
            //створює векторну змінну у структурі, з параметрами _MainTex,MaskTex
            half2 uv_MainTex;
            half2 uv_MaskTex;
            half2 uv_MaskRed;
            half2 uv_MaskGrean;
            half2 uv_MaskBlue;

        };
        // Функція виконання, де аргумент Input - прямий, SurfaceOutput o - повертаємий
        void surf(Input IN , inout SurfaceOutput o)
        {
            // присвоюємо  SurfaceOutput o параметри текстури
            fixed3 masks = tex2D(_MaskTex, IN.uv_MaskTex);
            fixed3 colormix = tex2D(_MaskRed, IN.uv_MaskRed) * masks.r;
            colormix += tex2D(_MaskGrean, IN.uv_MaskGrean) * masks.g;
            colormix += tex2D(_MaskBlue, IN.uv_MaskBlue) * masks.b;

            //Albedo відповідає за канал rgba
            o.Albedo = colormix; 
           
        }

        ENDCG
    }


}
