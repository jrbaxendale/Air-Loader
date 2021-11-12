using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute()]
	public class ES3UserType_ACPpayload : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ACPpayload() : base(typeof(ACPpayload)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ACPpayload)obj;
			
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ACPpayload)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ACPpayloadArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ACPpayloadArray() : base(typeof(ACPpayload[]), ES3UserType_ACPpayload.Instance)
		{
			Instance = this;
		}
	}
}