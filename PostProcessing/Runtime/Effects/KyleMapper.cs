using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(KyleMapperRenderer), PostProcessEvent.AfterStack, "Hidden/KyleMapper")]
public sealed class KyleMapper : PostProcessEffectSettings
{
    // HPD
    //[Range(0f, 15f)]
    //public FloatParameter _A = new FloatParameter { value = 1f };
    //[Range(0f, 15f)]
    //public FloatParameter _B = new FloatParameter { value = 0.33f };
    //[Range(0f, 15f)]
    //public FloatParameter _C = new FloatParameter { value = 0.02f };
    //[Range(0f, 15f)]
    //public FloatParameter _D = new FloatParameter { value = 2.26f };
    //[Range(0f, 15f)]
    //public FloatParameter _E = new FloatParameter { value = 0.69f };
    //[Range(0f, 15f)]
    //public FloatParameter _F = new FloatParameter { value = 0.2f };
    //[Range(0f, 15f)]
    //public FloatParameter _G = new FloatParameter { value = 0.1f };
    //[Range(0f, 15f)]
    //public FloatParameter _H = new FloatParameter { value = 1.52f };

    //ACES
    [Range(0f, 15f)]
    public FloatParameter _a = new FloatParameter { value = 1.25f };
    [Range(0f, 15f)]
    public FloatParameter _b = new FloatParameter { value = 2.88f };
    [Range(0f, 15f)]
    public FloatParameter _c = new FloatParameter { value = 9f };
    [Range(0f, 15f)]
    public FloatParameter _d = new FloatParameter { value = 6.6f };
    [Range(0f, 15f)]
    public FloatParameter _e = new FloatParameter { value = 4.46f };

    // SPHERICAL TONEMAP
    //[Range(0f, 15f)]
    //public FloatParameter sphericalAmount = new FloatParameter { value = 0f };

    // EXTRA
    [Range(0f, 15f)]
    public FloatParameter contrast = new FloatParameter { value = 0f };
    [Range(0f, 25f)]
    public FloatParameter exposure = new FloatParameter { value = 10.87f };
    [Range(0f, 15f)]
    public FloatParameter saturation = new FloatParameter { value = 0f };

    public override bool IsEnabledAndSupported(PostProcessRenderContext context)
    {
        return enabled.value && exposure > 0f;
    }
}

public sealed class KyleMapperRenderer : PostProcessEffectRenderer<KyleMapper>
{
    public override void Render(PostProcessRenderContext context)
    {
        var sheet = context.propertySheets.Get(Shader.Find("Hidden/KyleMapper"));

        //sheet.properties.SetFloat("A", settings._A);
        //sheet.properties.SetFloat("B", settings._B);
        //sheet.properties.SetFloat("C", settings._C);
        //sheet.properties.SetFloat("D", settings._D);
        //sheet.properties.SetFloat("E", settings._E);
        //sheet.properties.SetFloat("F", settings._F);
        //sheet.properties.SetFloat("G", settings._G);
        //sheet.properties.SetFloat("H", settings._H);

        sheet.properties.SetFloat("a", settings._a);
        sheet.properties.SetFloat("b", settings._b);
        sheet.properties.SetFloat("c", settings._c);
        sheet.properties.SetFloat("d", settings._d);
        sheet.properties.SetFloat("e", settings._e);

        //sheet.properties.SetFloat("SphericalAmount", settings.sphericalAmount);
        sheet.properties.SetFloat("Contrast", settings.contrast);
        sheet.properties.SetFloat("Exposure", settings.exposure);
        sheet.properties.SetFloat("Saturation", settings.saturation);

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}