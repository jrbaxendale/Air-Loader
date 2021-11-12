using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("TheWeight", "TheNewWeight", "TheTestObject", "TheNewTestObject", "TheOtherTransform", "Cube", "ACP1", "enabled", "name")]
	public class ES3UserType_Testing : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Testing() : base(typeof(Testing)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Testing)obj;
			
			writer.WritePropertyByRef("TheWeight", instance.TheWeight);
			writer.WritePropertyByRef("TheNewWeight", instance.TheNewWeight);
			writer.WritePropertyByRef("TheTestObject", instance.TheTestObject);
			writer.WritePropertyByRef("TheNewTestObject", instance.TheNewTestObject);
			writer.WritePropertyByRef("TheOtherTransform", instance.TheOtherTransform);
			writer.WritePropertyByRef("Cube", instance.Cube);
			writer.WritePropertyByRef("ACP1", instance.ACP1);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Testing)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "TheWeight":
						instance.TheWeight = reader.Read<TMPro.TMP_Text>();
						break;
					case "TheNewWeight":
						instance.TheNewWeight = reader.Read<TMPro.TMP_Text>();
						break;
					case "TheTestObject":
						instance.TheTestObject = reader.Read<UnityEngine.GameObject>(ES3UserType_GameObject.Instance);
						break;
					case "TheNewTestObject":
						instance.TheNewTestObject = reader.Read<UnityEngine.GameObject>(ES3UserType_GameObject.Instance);
						break;
					case "TheOtherTransform":
						instance.TheOtherTransform = reader.Read<UnityEngine.Transform>(ES3UserType_Transform.Instance);
						break;
					case "Cube":
						instance.Cube = reader.Read<UnityEngine.GameObject>(ES3UserType_GameObject.Instance);
						break;
					case "ACP1":
						instance.ACP1 = reader.Read<UnityEngine.GameObject>(ES3UserType_GameObject.Instance);
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


	public class ES3UserType_TestingArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_TestingArray() : base(typeof(Testing[]), ES3UserType_Testing.Instance)
		{
			Instance = this;
		}
	}
}