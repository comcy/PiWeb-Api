﻿#region copyright
/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss IMT (IZfM Dresden)                   */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2015                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */
#endregion

using Zeiss.IMT.PiWeb.Api.DataService.Rest;

namespace Zeiss.IMT.PiWeb.Api.Common.Data
{
	/// <summary>
	/// Static class with constants that are used by <see cref="ServiceInformation.FeatureList"/>
	/// to indicate the availability of certain server features.
	/// </summary>
	public static class WellKnownServerFeatures
	{
		/// <summary>Server supports server side querying of merged measurements (like a primary key for measurement search).</summary>
		public const string MergeAttributes = "MergeAttributes";

		/// <summary>Server supports defining conditions ('MergeCondition' + 'MergeMasterPart')
		/// for server side querying of merged measurements (like a primary key for measurement search).</summary>
		public const string MergeConditions = "MergeConditions";

		/// <summary>Server supports the measurement aggregation feature.</summary>
		public const string MeasurementAggregation = "MeasurementAggregation";

		/// <summary>Server supports the distinct search for specific attribute values.</summary>
		public const string DistinctMeasurementSearch = "DistinctMeasurementSearch";

		/// <summary>The server database is readonly and cannot be modified.</summary>
		public const string ReadOnlyDatabase = "ReadOnlyDB";

		/// <summary>The server does not support jobs.</summary>
		public const string JobEngineNotSupported = "JobEngineNotSupported";

		/// <summary>The server supports characteristics below the root part and messurements attached to the root part.</summary>
		public const string CharacteristicsBelowRoot = "CharacteristicsBelowRoot";

		/// <summary>The server supports the modification of catalog attributes without data loss
		/// (without this feature the only possibility is to delete and recreated the catalog).</summary>
		public const string CatalogAttributesUpdate = "CatalogAttributesUpdate";

		/// <summary>The server supports the ignore search filter flag for users and groups.</summary>
		public const string IgnoreSearchFilterSupport = "IgnoreSearchFilterSupport";

		/// <summary>The server supports measurement filter attributes with a LastN value greater than <see cref="short.MaxValue"/>.</summary>
		public const string MeasurementLimitResultInt32 = "MeasurementLimitResultInt32";
	}
}