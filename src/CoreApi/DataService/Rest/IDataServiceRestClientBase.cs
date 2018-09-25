﻿#region copyright
// 
// /* * * * * * * * * * * * * * * * * * * * * * * * * */
// /* Carl Zeiss IMT (IZfM Dresden)                   */
// /* Softwaresystem PiWeb                            */
// /* (c) Carl Zeiss 2018                             */
// /* * * * * * * * * * * * * * * * * * * * * * * * * */
// 
#endregion

namespace Zeiss.IMT.PiWeb.Api.DataService.Rest
{
	using System;
	using System.Collections.Generic;
	using System.Threading;
	using System.Threading.Tasks;
	using PiWebApi.Annotations;
	using Zeiss.IMT.PiWeb.Api.Common.Client;
	using Zeiss.IMT.PiWeb.Api.Common.Data;

	public interface IDataServiceRestClientBase<T> where T : DataServiceFeatureMatrix
	{
		#region methods

		/// <summary> 
		/// Method for fetching the <see cref="ServiceInformation"/>. This method can be used for connection checking. The call returns quickly 
		/// and does not produce any noticeable server load. 
		/// </summary>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task<ServiceInformation> GetServiceInformation( CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Method for fetching the <see cref="InterfaceVersionRange"/>.
		/// </summary>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task<InterfaceVersionRange> GetInterfaceInformation( CancellationToken cancellationToken = default( CancellationToken ) );

		Task<T> GetFeatureMatrix( CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Method for fetching the <see cref="Configuration"/>. The <see cref="Configuration"/> contains the 
		/// attribute definitions for parts, characteristics, measurements and values etc.
		/// </summary>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task<Configuration> GetConfiguration( CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Adds new attribute definitions to the database configuration for the specified <paramref name="entity"/>.
		/// </summary>
		/// <param name="entity">The entity the attribute definitions should be added to.</param>
		/// <param name="definitions">The attribute definitions to add.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task CreateAttributeDefinitions( Entity entity, AbstractAttributeDefinition[] definitions, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Updates / replaces the attribute definitions for the specified <paramref name="entity"/>. If the definition
		/// does not exist yet, it will be replaced otherwise it will be updated.
		/// </summary>
		/// <param name="entity">The entity the attribute definitions should be replaced for.</param>
		/// <param name="definitions">The attribute definitions to update.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task UpdateAttributeDefinitions( Entity entity, AbstractAttributeDefinition[] definitions, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Deletes the attribute definitions from the database configuration for the specified <paramref name="entity"/>. If the key
		/// list is empty, all definitions for the entity are deleted.
		/// </summary>
		/// <param name="entity">The entity the attribute definitions should be deleted from.</param>
		/// <param name="keys">The keys that specify the definitions.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task DeleteAttributeDefinitions( Entity entity, ushort[] keys = null, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Deletes all attribute definitions from the database configuration.
		/// </summary>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task DeleteAllAttributeDefinitions( CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Method checks if there is any entry for attribute <paramref name="attributeKey"/> with value <paramref name="value
		/// "/>
		/// </summary>
		/// <param name="attributeKey">The attribute key which should be checked.</param>
		/// <param name="value">The value which schould be checked.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		/// <returns></returns>
		Task<bool> CheckAttributeUsage( ushort attributeKey, string value, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Method checks if there is any entry for attribute <paramref name="attributeKey"/> and catalog entry with index <paramref name="catalogEntryIndex"/>
		/// </summary>
		/// <param name="attributeKey">The attribute key which should be checked.</param>
		/// <param name="catalogEntryIndex">The index of the catalog entry which should be checked.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		/// <returns></returns>
		Task<bool> CheckCatalogEntryUsage( ushort attributeKey, int catalogEntryIndex, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Method for fetching all <see cref="Catalog"/>s.  The catalogs contain the definition and the catalog entries.
		/// </summary>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task<Catalog[]> GetAllCatalogs( CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Method for fetching the <see cref="Catalog"/>.  The catalogs contain the definition and the catalog entries.
		/// </summary>
		/// <param name="catalogUuid">The uuid of the catalog to be rteurned.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task<Catalog> GetCatalog( Guid catalogUuid, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Adds the specified catalogs to the database. If the catalog contains entries, the entries will be added too.
		/// </summary>
		/// <param name="catalogs">The catalogs to add.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task CreateCatalogs( Catalog[] catalogs, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Updates the specified catalogs. If the catalog contains entries, the entries will be updated too.
		/// </summary>
		/// <param name="catalogs">The catalogs to update.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task UpdateCatalogs( Catalog[] catalogs, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Deletes the specified catalogs including their entries from the database. If the parameter <paramref name="catalogUuids"/>
		/// is empty, all catalogs will be deleted.
		/// </summary>
		/// <param name="catalogUuids">The catalog uuids to delete.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task DeleteCatalogs( Guid[] catalogUuids = null, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Adds the specified catalog entries to the catalog with uuid <paramref name="catalogUuid"/>. If the key <see cref="CatalogEntry.Key"/>
		/// is <code>-1</code>, the server will generate a new unique key for that entry.
		/// </summary>
		/// <param name="catalogUuid">The uuid of the catalog to add the entries to.</param>
		/// <param name="entries">The catalog entries to add.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task CreateCatalogEntries( Guid catalogUuid, CatalogEntry[] entries, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Removes the catalog entries with the specified <paramref name="keys"/> from the catalog <paramref name="catalogUuid"/>. If the list of keys
		/// is empty, all catalog entries will be removed.
		/// </summary>
		/// <param name="catalogUuid">The uuid of the catalog to remove the entries from.</param>
		/// <param name="keys">The keys of the catalog entries to delete.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task DeleteCatalogEntries( Guid catalogUuid, short[] keys = null, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Fetches a list of parts below <paramref name="partPath"/>. The result list always contains the specified parent part too. If the parent part
		/// is <code>null</code>, a server wide search is performed. If the <see paramref="depth"/> is <code>0</code>, only the specified part will be returned.
		/// </summary>
		/// <param name="partPath">The parent part to fetch the children for.</param> 
		/// <param name="withHistory">Determines whether to return the version history for each part.</param>
		/// <param name="depth">The depth for the inspection plan search.</param>
		/// <param name="partUuids">The list of part uuids to restrict the search to.</param>
		/// <param name="requestedPartAttributes">The attribute selector to determine which attributes to return.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		[NotNull]
		Task<IEnumerable<InspectionPlanPart>> GetParts( PathInformation partPath = null, Guid[] partUuids = null, ushort? depth = null, AttributeSelector requestedPartAttributes = null, bool withHistory = false, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Fetches a single part by its uuid.
		/// </summary>
		/// <param name="partUuid">The part's uuid</param>
		/// <param name="withHistory">Determines whether to return the version history for the part.</param>
		/// <param name="requestedPartAttributes">The attribute selector to determine which attributes to return.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		[NotNull]
		Task<InspectionPlanPart> GetPartByUuid( Guid partUuid, AttributeSelector requestedPartAttributes = null, bool withHistory = false, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Adds the specified parts to the database.
		/// </summary>
		/// <param name="parts">The parts to add.</param>
		/// <param name="versioningEnabled">Specifies whether to create a new inspection plan version entry. </param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task CreateParts( InspectionPlanPart[] parts, bool versioningEnabled = false, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Updates the specified parts in the database.
		/// </summary>
		/// <param name="parts">The parts to update.</param>
		/// <param name="versioningEnabled">Specifies whether to create a new inspection plan version entry. </param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task UpdateParts( InspectionPlanPart[] parts, bool versioningEnabled = false, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Deletes all parts and child parts below <paramref name="partPath"/> from the database. Since parts act as the parent 
		/// of characteristics and measurements, this call will delete all characteristics and measurements including the measurement 
		/// values that are a child of the specified parent part.
		/// </summary>
		/// <param name="partPath">The parent part for the delete operation.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task DeleteParts( PathInformation partPath, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Deletes all parts and child parts below the parts specified by <paramref name="partUuids"/> from the database. Since parts act as the parent 
		/// of characteristics and measurements, this call will delete all characteristics and measurements including the measurement 
		/// values that are a child of the specified parent part.
		/// </summary>
		/// <param name="partUuids">The uuid list of the parent part for the delete operation.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task DeleteParts( Guid[] partUuids, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Fetches a list of characteristics below <paramref name="partPath"/>. Parts below <paramref name="partPath"/> are ignored.
		/// If the parent part is <code>null</code> the characteristics below the root part will be returned.
		/// The search can be restricted using the various filter parameters.
		/// If the <see paramref="depth"/> is <code>0</code>, an empty list will be returned.
		/// </summary>
		/// <param name="partPath">The parent part to fetch the children for.</param>
		/// <param name="withHistory">Determines whether to return the version history for each characteristic.</param>
		/// <param name="depth">The depth for the inspection plan search.</param>
		/// <param name="requestedCharacteristicAttributes">The attribute selector to determine which attributes to return.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		[NotNull]
		Task<IEnumerable<InspectionPlanCharacteristic>> GetCharacteristics( PathInformation partPath = null, ushort? depth = null, AttributeSelector requestedCharacteristicAttributes = null, bool withHistory = false, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Fetches characteristics based on their <paramref name="charUuids"/>.
		/// </summary>
		/// <param name="charUuids">Uuids of the cherectersitics to be fetched</param>
		/// <param name="requestedCharacteristicAttributes">The attribute selector to determine which attributes to return.</param>
		/// <param name="withHistory">Determines whether to return the version history for each characteristic.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		/// <returns></returns>
		[NotNull]
		Task<IEnumerable<InspectionPlanCharacteristic>> GetCharacteristicsByUuids( Guid[] charUuids, AttributeSelector requestedCharacteristicAttributes = null, bool withHistory = false, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Fetches a single characteristic by its uuid.
		/// </summary>
		/// <param name="charUuid">The characteristic's uuid</param>
		/// <param name="withHistory">Determines whether to return the version history for the characteristic.</param>
		/// <param name="requestedCharacteristicAttributes">The attribute selector to determine which attributes to return.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		[NotNull]
		Task<InspectionPlanCharacteristic> GetCharacteristicByUuid( Guid charUuid, AttributeSelector requestedCharacteristicAttributes = null, bool withHistory = false, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Adds the specified characteristics to the database.
		/// </summary>
		/// <param name="characteristics">The characteristics to add.</param>
		/// <param name="versioningEnabled">Specifies whether to create a new inspection plan version entry.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task CreateCharacteristics( InspectionPlanCharacteristic[] characteristics, bool versioningEnabled = false, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Updates the specified characteristics in the database.
		/// </summary>
		/// <param name="characteristics">characteristics parts to update.</param>
		/// <param name="versioningEnabled">Specifies whether to create a new inspection plan version entry.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task UpdateCharacteristics( InspectionPlanCharacteristic[] characteristics, bool versioningEnabled = false, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Deletes the characteristic <paramref name="charPath"/> and its sub characteristics from the database. 
		/// </summary>
		/// <param name="charPath">The characteristic path for the delete operation.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task DeleteCharacteristics( PathInformation charPath, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Deletes the characteristics <paramref name="charUuid"/> and their sub characteristics from the database. 
		/// </summary>
		/// <param name="charUuid">The characteristic uuid list for the delete operation.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task DeleteCharacteristics( Guid[] charUuid, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Fetches a list of measurements for the <paramref name="partPath"/>. The search operation can be parameterized using the specified 
		/// <paramref name="filter"/>. If the filter is empty, all measurements for the specified part will be fetched.
		/// </summary>
		/// <param name="partPath">The part path to fetch the measurements for.</param>
		/// <param name="filter">A filter that can be used to further restrict the search operation.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		[NotNull]
		Task<SimpleMeasurement[]> GetMeasurements( PathInformation partPath = null, MeasurementFilterAttributes filter = null, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Fetches a list of measurement attribute values of the attribute <paramref name="key" /> for the <paramref name="partPath" />. The search operation can be parameterized using the specified
		/// <paramref name="filter" />. If the filter is empty, all values for the specified key will be fetched.
		/// </summary>
		/// <param name="key">The key for which to fetch distinct attribute values.</param>
		/// <param name="partPath">The part path to fetch the measurements for.</param>
		/// <param name="filter">A filter that can be used to further restrict the search operation.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		/// <returns></returns>
		[NotNull]
		Task<string[]> GetDistinctMeasurementAttributeValues( ushort key, PathInformation partPath = null, DistinctMeasurementFilterAttributes filter = null, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Adds the measurements parts to the database.
		/// </summary>
		/// <param name="measurements">The measurements to add.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task CreateMeasurements( SimpleMeasurement[] measurements, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Updates the specified measurements in the database.
		/// </summary>
		/// <param name="measurements">The measurements to update.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task UpdateMeasurements( SimpleMeasurement[] measurements, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Deletes the measurements including the measurement values for part <paramref name="partPath"/>. The <paramref name="filter"/> can be used 
		/// to restrict the measurements. If the filter is empty, all measurements for the specified part will be deleted. If the partPath is empty,
		/// all measurements from the whole database will be deleted.
		/// </summary>
		/// <param name="partPath">The part path to delete the measurements from.</param>
		/// <param name="filter">A filter to restrict the delete operation.</param>
		/// <param name="aggregation">Specifies what types of measurements will be deleted (normal/aggregated measurements or both).</param>
		/// <param name="deep">Specifies if measurements of <paramref name="partPath"/> only or also measurements of sub parts will be deleted.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task DeleteMeasurementsByPartPath( PathInformation partPath = null, GenericSearchCondition filter = null, AggregationMeasurementSelection aggregation = AggregationMeasurementSelection.Default, MeasurementDeleteBehavior deep = MeasurementDeleteBehavior.DeleteForCurrentPartOnly, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Deletes the measurements including the measurement values for parts that uuids are within <paramref name="partUuids"/> list. The <paramref name="filter"/> can be used 
		/// to restrict the measurements. If the filter is empty, all measurements for the specified parts will be deleted. If the partPath is empty,
		/// all measurements from the whole database will be deleted. 
		/// </summary>
		/// <param name="partUuids">The Uuids of the parts which measurements should be deleted.</param>
		/// <param name="filter">A filter to restrict the delete operation.</param>
		/// <param name="aggregation">Specifies what types of measurements will be deleted (normal/aggregated measurements or both).</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task DeleteMeasurementsByPartUuids( Guid[] partUuids, GenericSearchCondition filter = null, AggregationMeasurementSelection aggregation = AggregationMeasurementSelection.Default, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Deletes the measurements that are part of the <paramref name="measurementUuids"/> list.
		/// </summary>
		/// <param name="measurementUuids">The list of uuids of the measurements to delete.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task DeleteMeasurementsByUuid( Guid[] measurementUuids, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Fetches a list of measurements and measurement values for the <paramref name="partPath"/>. The search operation 
		/// can be parameterized using the specified <paramref name="filter"/>. If the filter is empty, all measurements for 
		/// the specified part will be fetched.
		/// <remarks>The <see cref="DataCharacteristic"/> objects within the returned measurements does not include the characteristics' paths due to perform issues.</remarks>
		/// </summary>
		/// <param name="partPath">The part path to fetch the measurements and values for.</param>
		/// <param name="filter">A filter that can be used to further restrict the search operation.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		[NotNull]
		Task<DataMeasurement[]> GetMeasurementValues( PathInformation partPath = null, MeasurementValueFilterAttributes filter = null, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Adds the measurements and measurement values parts to the database. Please note that no single values can be inserted or updated. Whole
		/// measurements with all values can be created or updated only.
		/// </summary>
		/// <param name="values">The measurements and values to add.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task CreateMeasurementValues( DataMeasurement[] values, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Updates the measurements and measurement values parts to the database. Please note that no single values can be inserted or updated. Whole
		/// measurements with all values can be created or updated only.
		/// </summary>
		/// <param name="values">The measurements and values to update.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task UpdateMeasurementValues( DataMeasurement[] values, CancellationToken cancellationToken = default( CancellationToken ) );

		#endregion
	}
}