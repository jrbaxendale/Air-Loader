using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("cam", "MainCam", "MainCanvas", "ExitBtn", "LoadingPanel", "locksButton", "WeightButton", "LocationButton", "DangerousGoodsBtn", "endMarker", "smoothTime", "velocity", "enabled", "name")]
	public class ES3UserType_CamMove : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_CamMove() : base(typeof(CamMove)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (CamMove)obj;
			
			writer.WritePropertyByRef("cam", instance.cam);
			writer.WritePropertyByRef("MainCam", instance.MainCam);
			writer.WritePropertyByRef("MainCanvas", instance.MainCanvas);
			writer.WritePropertyByRef("ExitBtn", instance.ExitBtn);
			writer.WritePropertyByRef("LoadingPanel", instance.LoadingPanel);
			writer.WritePropertyByRef("locksButton", instance.locksButton);
			writer.WritePropertyByRef("WeightButton", instance.WeightButton);
			writer.WritePropertyByRef("LocationButton", instance.LocationButton);
			writer.WritePropertyByRef("DangerousGoodsBtn", instance.DangerousGoodsBtn);
			writer.WritePrivateField("endMarker", instance);
			writer.WriteProperty("smoothTime", CamMove.smoothTime, ES3Type_float.Instance);
			writer.WriteProperty("velocity", CamMove.velocity, ES3Type_Vector3.Instance);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (CamMove)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "cam":
						instance.cam = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "MainCam":
						instance.MainCam = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "MainCanvas":
						instance.MainCanvas = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "ExitBtn":
						instance.ExitBtn = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "LoadingPanel":
						instance.LoadingPanel = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "locksButton":
						instance.locksButton = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "WeightButton":
						instance.WeightButton = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "LocationButton":
						instance.LocationButton = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "DangerousGoodsBtn":
						instance.DangerousGoodsBtn = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "endMarker":
					reader.SetPrivateField("endMarker", reader.Read<UnityEngine.Vector3>(), instance);
					break;
					case "smoothTime":
						CamMove.smoothTime = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "velocity":
						CamMove.velocity = reader.Read<UnityEngine.Vector3>(ES3Type_Vector3.Instance);
						break;
					case "enabled":
						instance.enabled = reader.Read<System.Boolean>(ES3Type_bool.Instance);
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_CamMoveArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CamMoveArray() : base(typeof(CamMove[]), ES3UserType_CamMove.Instance)
		{
			Instance = this;
		}
	}
}