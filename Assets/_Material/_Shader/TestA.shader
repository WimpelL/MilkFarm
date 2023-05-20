Shader "TestShader/TestA"
{
    // ShaderLab
    Properties
    {
        //Створюємо текстуру в Юнити
        _MainTex1 ("Main texture 1", 2D) = "white" {}
        _MainTex2 ("Main texture 2", 2D) = "white" {}
        _MainTex3 ("Main texture 3", 2D) = "white" {}
        _MaskTex ("Mask texture", 2D) = "black" {}
        //Створюємо колір в Юнити
        _Color ("Emission Color", Color) = (0.5,0,1,1)
        //Створюємо вектор в Юнити
        _VectorParam("Vector Parametr", Vector) = (1.0,1.0,1.0,1.0)
        //Створюємо ползунок в Юнити
        _RangeParm("Intensivity", Range(0,1)) = 1
        //Створюємо pvsye в Юнити
        _FloatParn("Float Parameter ", Float) = 1.0
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
        sampler2D _MainTex1;
        sampler2D _MainTex2;
        sampler2D _MainTex3;
        sampler2D _MaskTex;

        fixed3 _Color;


        // створюємо структуру
        struct Input 
        {
            //створює векторну змінну у структурі, з параметрами _MainTex,MaskTex
            half2 uv_MainTex1;
            half2 uv_MaskTex;
        };
        // Функція виконання, де аргумент Input - прямий, SurfaceOutput o - повертаємий
        void surf(Input IN , inout SurfaceOutput o)
        {
            // присвоюємо  SurfaceOutput o параметри текстури
            fixed3 masks = tex2D(_MaskTex, IN.uv_MaskTex);
            fixed3 colormix = tex2D(_MainTex1, IN.uv_MainTex1) * masks.r;
            colormix += tex2D(_MainTex2, IN.uv_MainTex1) * masks.g;
            colormix += tex2D(_MainTex3, IN.uv_MainTex1) * masks.b;
            //Albedo відповідає за канал rgba
            o.Albedo = colormix; 
            //Emission відповідає за світло
            o.Emission = _Color; 

           
        }

        ENDCG
    }
    //Варіант СубШейдера для разного заліза
    //SubShader
    //{
    //
    //}
    
    //Кінцевий Варіант СубШейдера, коли Юніті не змогла запустити їх
    Fallback off

}