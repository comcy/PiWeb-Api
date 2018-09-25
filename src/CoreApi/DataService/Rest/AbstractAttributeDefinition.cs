﻿#region copyright
/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss IMT (IZfM Dresden)                   */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2015                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */
#endregion

namespace Zeiss.IMT.PiWeb.Api.DataService.Rest
{

	/// <summary>
	/// Abstract base class of <see cref="CatalogAttributeDefinition"/> ans <see cref="AttributeDefinition"/>.
	/// It holds attribute's base properties key and description.
	/// </summary>
	[Newtonsoft.Json.JsonConverter( typeof( Common.Data.Converter.AttributeDefinitionConverter ) )]
	public abstract class AbstractAttributeDefinition
	{
		#region constructor

		/// <summary>
		/// Constructor.
		/// </summary>
		protected AbstractAttributeDefinition()
		{ }

		/// <summary>
		/// Constructor. Initializes a new definition using the specified key and value.
		/// </summary>
		/// <param name="key">The unique key for this attribute</param>
		/// <param name="description">The attribute description</param>
		/// <param name="queryEfficient"><code>true</code> if this attribute is efficient for filtering operations</param>
		protected AbstractAttributeDefinition( ushort key, string description, bool queryEfficient )
		{
			Key = key;
			QueryEfficient = queryEfficient;
			Description = description;
		}

		#endregion

		#region properties

		/// <summary>
		/// Gets or sets the key for this attribute definition.
		/// The key is the attribute's unique identifier.
		/// </summary>
		public ushort Key { get; set; }

		/// <summary>
		/// Gets or sets the name of this attribute definition.
		/// The attribute's name which is displayed in UI.
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Determines whether this attribute is efficient for filtering operations.
		/// </summary>
		/// <remarks>
		/// This flag is currently unused. This may be used in future web service versions.
		/// </remarks>
		public bool QueryEfficient { get; set; }

		#endregion

		#region methods

		/// <summary>
		/// Overridden <see cref="System.Object.ToString"/> method.
		/// </summary>
		public override string ToString()
		{
			return Description;
		}

		#endregion
	}
}