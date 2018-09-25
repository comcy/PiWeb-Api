﻿#region copyright
// 
// /* * * * * * * * * * * * * * * * * * * * * * * * * */
// /* Carl Zeiss IMT (IZfM Dresden)                   */
// /* Softwaresystem PiWeb                            */
// /* (c) Carl Zeiss 2018                             */
// /* * * * * * * * * * * * * * * * * * * * * * * * * */
// 
#endregion

namespace Zeiss.IMT.PiWeb.Api.RawDataService.Rest
{
	using System;
	using System.Threading;
	using System.Threading.Tasks;
	using Zeiss.IMT.PiWeb.Api.Common.Client;
	using Zeiss.IMT.PiWeb.Api.Common.Data;
	using Zeiss.IMT.PiWeb.Api.RawDataService.Filter.Conditions;

	public interface IRawDataServiceRestClientBase<T> where T : RawDataServiceFeatureMatrix
	{
		#region methods

		/// <summary> 
		/// Method for fetching the <see cref="ServiceInformation"/>. This method can be used for connection checking. The call returns quickly 
		/// and does not produce any noticeable server load. 
		/// </summary>
		/// <param name="cancellationToken">A token to cancel the hronous operation.</param>
		Task<ServiceInformation> GetServiceInformation( CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Method for fetching the <see cref="InterfaceVersionRange"/>.
		/// </summary>
		/// <param name="cancellationToken">A token to cancel the hronous operation.</param>
		Task<InterfaceVersionRange> GetInterfaceInformation( CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Method for fetching the <see cref="RawDataServiceFeatureMatrix"/>
		/// </summary>
		/// <param name="cancellationToken">A token to cancel the hronous operation.</param>
		/// <returns></returns>
		Task<T> GetFeatureMatrix( CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Fetches a list of raw data information for the <paramref name="entity"/> identified by <paramref name="uuids"/> and filtered by <paramref name="filter"/>.
		/// Either <paramref name="uuids" /> or <paramref name="filter"/> must have a value.
		/// </summary>
		/// <param name="entity">The <see cref="RawDataEntity"/> the raw data information should be fetched for.</param>
		/// <param name="uuids">The list of value uuids the data information should be fetched for.</param>
		/// <param name="filter">A condition used to filter the result.</param>
		/// <param name="cancellationToken">A token to cancel the hronous operation.</param>
		/// <exception cref="InvalidOperationException">No uuids and no filter was specified.</exception>
		/// <exception cref="OperationNotSupportedOnServerException">An attribute filter for raw data is not supported by this server.</exception>
		Task<RawDataInformation[]> ListRawData( RawDataEntity entity, string[] uuids, FilterCondition filter = null, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Fetches raw data as a byte array for the raw data item identified by <paramref name="target"/> and <paramref name="rawDataKey"/>. 
		/// </summary>
		/// <param name="target">The <see cref="RawDataTargetEntity"/> that specifies the raw data object that should be fetched.</param>
		/// <param name="rawDataKey">The unique key that identifies the raw data object for the specified target.</param>
		/// <param name="expectedMd5">The md5 check sum that is expected for the result object. If this value is set, performance is better because server side round trips are reduced.</param>
		/// <param name="cancellationToken">A token to cancel the hronous operation.</param>
		Task<byte[]> GetRawData( RawDataTargetEntity target, int rawDataKey, Guid? expectedMd5 = null, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Fetches a preview image for the specified <code>info</code>. 
		/// </summary>
		/// <param name="target">The <see cref="RawDataTargetEntity"/> that specifies the raw data object that should be fetched.</param>
		/// <param name="rawDataKey">The unique key that identifies the raw data object for the specified target.</param>
		/// <returns>The preview image as byte array.</returns>
		/// <param name="cancellationToken">A token to cancel the hronous operation.</param>
		Task<byte[]> GetRawDataThumbnail( RawDataTargetEntity target, int rawDataKey, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Creates a new raw data object <paramref name="data"/> for the element specified by <paramref name="info"/>. 
		/// </summary>
		/// <param name="data">The raw data to upload.</param>
		/// <param name="info">The <see cref="RawDataInformation"/> object containing the <see cref="RawDataEntity"/> type and the uuid of the raw data that should be uploaded.</param>
		/// <param name="cancellationToken">A token to cancel the hronous operation.</param>
		/// <remarks>
		/// If key speciefied by <see cref="RawDataInformation.Key"/> is -1, a new key will be chosen by the server automatically. This is the preferred way.
		/// </remarks>
		Task CreateRawData( RawDataInformation info, byte[] data, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary> 
		/// Updates the raw data object <paramref name="data"/> for the element identified by <paramref name="info"/>. 
		/// </summary>
		/// <param name="data">The raw data to upload.</param>
		/// <param name="info">The <see cref="RawDataInformation"/> object containing the <see cref="RawDataEntity"/> type, the uuid and the key of the raw data that should be updated.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		Task UpdateRawData( RawDataInformation info, byte[] data, CancellationToken cancellationToken = default( CancellationToken ) );

		/// <summary>
		/// Deletes raw data for the element identified by <paramref name="target"/> and <paramref name="rawDataKey"/>.
		/// </summary>
		/// <param name="target">The <see cref="RawDataTargetEntity"/> object containing the <see cref="RawDataEntity"/> type and the uuid of the raw data that should be deleted.</param>
		/// <param name="rawDataKey">The key of the raw data object which should be deleted.</param>
		/// <param name="cancellationToken">A token to cancel the hronous operation.</param>
		Task DeleteRawData( RawDataTargetEntity target, int? rawDataKey = null, CancellationToken cancellationToken = default( CancellationToken ) );

		#endregion

	}
}