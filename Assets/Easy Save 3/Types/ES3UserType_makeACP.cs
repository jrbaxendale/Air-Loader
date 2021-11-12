using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("ADSscript", "LOGSscript", "Weight1", "Dest1", "ACPID", "InputField", "Maincanvas", "ACPprefab", "enabled", "name")]
	public class ES3UserType_makeACP : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_makeACP() : base(typeof(makeACP)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (makeACP)obj;
			
			writer.WritePropertyByRef("ADSscript", instance.ADSscript);
			writer.WritePropertyByRef("LOGSscript", instance.LOGSscript);
			writer.WritePropertyByRef("Weight1", instance.Weight1);
			writer.WritePropertyByRef("Dest1", instance.Dest1);
			writer.WritePropertyByRef("ACPID", instance.ACPID);
			writer.WritePropertyByRef("InputField", instance.InputField);
			writer.WritePropertyByRef("Maincanvas", instance.Maincanvas);
			writer.WritePropertyByRef("ACPprefab", instance.ACPprefab);
			writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (makeACP)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "ADSscript":
						instance.ADSscript = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "LOGSscript":
						instance.LOGSscript = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Weight1":
						instance.Weight1 = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Dest1":
						instance.Dest1 = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "ACPID":
						instance.ACPID = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "InputField":
						instance.InputField = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Maincanvas":
						instance.Maincanvas = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "ACPprefab":
						instance.ACPprefab = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
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


	public class ES3UserType_makeACPArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_makeACPArray() : base(typeof(makeACP[]), ES3UserType_makeACP.Instance)
		{
			Instance = this;
		}
	}
}