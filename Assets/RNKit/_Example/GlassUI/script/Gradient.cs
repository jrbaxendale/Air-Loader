﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Gradient : BaseMeshEffect  
{
    public Color top = Color.white;
    public Color bottom = Color.white;
    
    public override void ModifyMesh(VertexHelper vh)
    {
        if (!this.IsActive())
            return;
            
        List<UIVertex> vertexList = new List<UIVertex>();
        vh.GetUIVertexStream(vertexList);

        ModifyVertices(vertexList);

        vh.Clear();
        vh.AddUIVertexTriangleStream(vertexList);
    }
    
    public void ModifyVertices(List<UIVertex> vertexList)
    {
        if (!IsActive() || vertexList.Count < 4)
        {
            return;
        }
        if (vertexList.Count == 6)
        {    
            SetVertexColor(vertexList, 0, bottom);
            SetVertexColor(vertexList, 1, top);
            SetVertexColor(vertexList, 2, top);
            SetVertexColor(vertexList, 3, top);
            SetVertexColor(vertexList, 4, bottom);
            SetVertexColor(vertexList, 5, bottom);
        }
        else
        {
            float bottomPos = vertexList[vertexList.Count - 1].position.y;
            float topPos =vertexList[0].position.y;

            float height = topPos - bottomPos;

            for (int i = 0; i < vertexList.Count; i++)
            {
                UIVertex v = vertexList[i];
                v.color *= Color.Lerp(top, bottom, ((v.position.y) - bottomPos) / height);
                vertexList[i] = v;
            }
        }
    }

    private void SetVertexColor(List<UIVertex> vertexList, int index, Color color)
    {
        UIVertex v = vertexList[index];
        v.color = color;
        vertexList[index] = v;
    }
}
