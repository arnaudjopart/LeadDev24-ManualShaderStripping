using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class StrippingShaders : IPreprocessShaders
{
    public int callbackOrder {  get; }

    public void OnProcessShader(Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> data)
    {
        for (var i = data.Count - 1; i >= 0; i--) 
        {
            var shaderKeyword = new ShaderKeyword(shader, "_OCCLUSIONMAP");
            if (data[i].shaderKeywordSet.IsEnabled(shaderKeyword))
            {
                Debug.Log("Removed:" + shader.name);
                data.RemoveAt(i);
            }
        
        
        }
    }

    
}
