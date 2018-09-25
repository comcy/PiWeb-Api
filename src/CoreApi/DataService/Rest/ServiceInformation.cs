﻿#region copyright
/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss IMT (IZfM Dresden)                   */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2015                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */
#endregion

namespace Zeiss.IMT.PiWeb.Api.DataService.Rest
{
	#region using

	using System;
	using Newtonsoft.Json;

	#endregion

	/// <summary>
	/// This class contains general information about the DataService like the server name, server version etc.
	/// </summary>
	public class ServiceInformation
	{
		#region properties

		/// <summary>
		/// Gets or sets the server name.
		/// </summary>
		[JsonProperty( "serverName" )]
		public string ServerName { get; set; }

		/// <summary>
		/// Gets or sets the server version.
		/// </summary>
		[JsonProperty( "version" )]
		public string Version { get; set; }

		/// <summary>
		/// Gets or sets whether the server has security enabled.
		/// </summary>
		[JsonProperty( "securityEnabled" )]
		public bool SecurityEnabled { get; set; }

		/// <summary>
		/// Gets or sets the servers edition.
		/// </summary>
		[JsonProperty( "edition" )]
		public string Edition { get; set; }

		/// <summary>
		/// Gets or sets of the <see cref="Edition"/> contains a values.
		/// </summary>
		public bool EditionSpecified;

		/// <summary>
		/// Gets or sets the web service major interface version.
		/// </summary>
		[JsonProperty( "versionWsdlMajor" )]
		public string VersionWsdlMajor { get; set; }

		/// <summary>
		/// Gets or sets the minor web service interface version.
		/// </summary>
		[JsonProperty( "versionWsdlMinor" )]
		public string VersionWsdlMinor { get; set; }

		/// <summary>
		/// Gets or sets the number of parts that currently exist in the server. This number is just an approximation.
		/// </summary>
		[JsonProperty( "partCount" )]
		public int PartCount { get; set; }

		/// <summary>
		/// Gets or sets the number of characteristics that currently exist in the server. This number is just an approximation.
		/// </summary>
		[JsonProperty( "characteristicCount" )]
		public int CharacteristicCount { get; set; }

		/// <summary>
		/// Gets or sets the number of measurements that currently exist in the server. This number is just an approximation.
		/// </summary>
		[JsonProperty( "measurementCount" )]
		public int MeasurementCount { get; set; }

		/// <summary>
		/// Gets or sets the number of values that currently exist in the server. This number is just an approximation.
		/// </summary>
		[JsonProperty( "valueCount" )]
		public int ValueCount { get; set; }

		/// <summary>
		/// Gets or sets a list of features that are supported by the server.
		/// </summary>
		[JsonProperty( "featureList" )]
		public string[] FeatureList { get; set; }

		/// <summary>
		/// Gets or sets the timestamp of the last inspection plan modification accross the whole server.
		/// </summary>
		[JsonProperty( "inspectionPlanTimestamp" )]
		public DateTime InspectionPlanTimestamp { get; set; }

		/// <summary>
		/// Gets or sets of the <see cref="InspectionPlanTimestamp"/> contains a values.
		/// </summary>
		[JsonIgnore]
		public bool InspectionPlanTimestampSpecified;

		/// <summary>
		/// Gets or sets the timestamp of the last structure modification accross the whole server.
		/// </summary>
		[JsonProperty( "structureTimestamp" )]
		public DateTime StructureTimestamp { get; set; }

		/// <summary>
		/// Gets or sets of the <see cref="StructureTimestamp"/> contains a values.
		/// </summary>
		[JsonIgnore]
		public bool StructureTimestampSpecified;

		/// <summary>
		/// Gets or sets the timestamp of the last measurement modification accross the whole server.
		/// </summary>
		[JsonProperty( "measurementTimestamp" )]
		public DateTime MeasurementTimestamp { get; set; }

		/// <summary>
		/// Gets or sets of the <see cref="MeasurementTimestamp"/> contains a values.
		/// </summary>
		[JsonIgnore]
		public bool MeasurementTimestampSpecified;

		/// <summary>
		/// Gets or sets the timestamp for the last modification of the server configuration.
		/// </summary>
		[JsonProperty( "configurationTimestamp" )]
		public DateTime ConfigurationTimestamp { get; set; }

		/// <summary>
		/// Gets or sets of the <see cref="ConfigurationTimestamp"/> contains a values.
		/// </summary>
		[JsonIgnore]
		public bool ConfigurationTimestampSpecified;

		/// <summary>
		/// Gets or sets the timestamp for the last modification of the catalogs.
		/// </summary>
		[JsonProperty( "catalogTimestamp" )]
		public DateTime CatalogTimestamp { get; set; }

		/// <summary>
		/// Gets or sets of the <see cref="CatalogTimestamp"/> contains a values.
		/// </summary>
		[JsonIgnore]
		public bool CatalogTimestampSpecified;

		/// <summary>
		/// Convenience property that combines <see cref="VersionWsdlMajor"/> and <see cref="VersionWsdlMinor"/>.
		/// </summary>
		[JsonIgnore]
		public Version WsdlVersion
		{
			get 
			{
				if( !string.IsNullOrEmpty( VersionWsdlMajor ) && !string.IsNullOrEmpty( VersionWsdlMinor ) )
					return new Version( VersionWsdlMajor + "." + VersionWsdlMinor );

				return new Version( 0, 0 );
			}
		}

		[JsonProperty( "requestHeaderSize" )]
		public int RequestHeaderSize { get; set; }

		#endregion

		#region methods

		/// <summary>
		/// Overridden <see cref="System.Object.ToString"/> method.
		/// </summary>
		public override string ToString()
		{
			if( Version == null )
				return "";

			var result = EditionSpecified ? Edition + " Edition" : "QDB" + ", Version " + Version;
			if( !string.IsNullOrEmpty( VersionWsdlMajor ) )
				result += " (WSDL: " + VersionWsdlMajor + "." + VersionWsdlMinor + ")";

			return result;
		}

		#endregion
	}
}