﻿#region copyright
/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss IMT (IZfM Dresden)                   */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2015                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */
#endregion

namespace Zeiss.IMT.PiWeb.Api.Common.Data.Converter
{
	#region using

	using System;
	using Newtonsoft.Json;
	using Zeiss.IMT.PiWeb.Api.DataService.Rest;

	#endregion

	/// <summary>
	/// Specialized <see cref="Newtonsoft.Json.JsonConverter"/> for <see cref="PathInformation"/>-objects.
	/// </summary>
	public class PathInformationConverter : JsonConverter
	{
		#region members

		/// <summary>
		/// Determines whether this instance can convert the specified object type.
		/// </summary>
		public override bool CanConvert( Type objectType )
		{
			return typeof( PathInformation ) == objectType;
		}

		/// <summary>
		/// Reads the JSON representation of the object.
		/// </summary>
		public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
		{
			if( reader.TokenType == JsonToken.String )
			{
				return PathHelper.RoundtripString2PathInformation( (string)reader.Value );
			}
			return null;
		}

		/// <summary>
		/// Writes the JSON representation of the object.
		/// </summary>
		public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
		{
			writer.WriteValue( PathHelper.PathInformation2RoundtripString( (PathInformation)value ) );
		}

		#endregion
	}
}