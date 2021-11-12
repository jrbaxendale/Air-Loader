using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("hasPopInstruction", "materialCount", "popMaterialCount", "cullTransparentMesh", "cull", "clippingSoftness", "name")]
	public class ES3UserType_CanvasRenderer : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_CanvasRenderer() : base(typeof(UnityEngine.CanvasRenderer)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.CanvasRenderer)obj;
			
			writer.WriteProperty("hasPopInstruction", instance.hasPopInstruction, ES3Type_bool.Instance);
			writer.WriteProperty("materialCount", instance.materialCount, ES3Type_int.Instance);
			writer.WriteProperty("popMaterialCount", instance.popMaterialCount, ES3Type_int.Instance);
			writer.WriteProperty("cullTransparentMesh", instance.cullTransparentMesh, ES3Type_bool.Instance);
			writer.WriteProperty("cull", instance.cull, ES3Type_bool.Instance);
			writer.WriteProperty("clippingSoftness", instance.clippingSoftness, ES3Type_Vector2.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.CanvasRenderer)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "hasPopInstruction":
						instance.hasPopInstruction = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "materialCount":
						instance.materialCount = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "popMaterialCount":
						instance.popMaterialCount = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "cullTransparentMesh":
						instance.cullTransparentMesh = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "cull":
						instance.cull = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					case "clippingSoftness":
						instance.clippingSoftness = reader.Read<UnityEngine.Vector2>(ES3Type_Vector2.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_CanvasRendererArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CanvasRendererArray() : base(typeof(UnityEngine.CanvasRenderer[]), ES3UserType_CanvasRenderer.Instance)
		{
			Instance = this;
		}
	}
}