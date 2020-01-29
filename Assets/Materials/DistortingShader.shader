Shader "Custom/DistortingShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Blend SrcAlpha OneMinusSrcAlpha

        Tags { "RenderType"="Opaque" }
        CGPROGRAM

        // keep alpha in the lighting model
        #pragma surface surf Lambert keepalpha

        struct Input
        {
            float2 uv_MainTex;
        };

        sampler2D _MainTex;

        void surf (Input IN, inout SurfaceOutput o)
		{
			//2. move the fragment data into its own variable
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            //3. multiply the color of the fragment by the alpha value
            o.Albedo = c.rgb * c.a;
            //2. set the SurfaceOutput's alpha value
            o.Alpha = c.a;

        }
        ENDCG
    }
    FallBack "Diffuse"
}

/*float2 uv = IN.uv_MainTex + _Time.y;
            fixed4 c = tex2D (_MainTex, uv) * _Color;
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;*/
