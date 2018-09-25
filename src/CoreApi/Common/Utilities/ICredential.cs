﻿#region Copyright

/* * * * * * * * * * * * * * * * * * * * * * * * * */
/* Carl Zeiss IMT (IZfM Dresden)                   */
/* Softwaresystem PiWeb                            */
/* (c) Carl Zeiss 2017                             */
/* * * * * * * * * * * * * * * * * * * * * * * * * */

#endregion

namespace Zeiss.IMT.PiWeb.Api.Common.Utilities
{
	#region usings

	using System;

	#endregion

	/// <summary>
	/// Common interface for authentication credentials.
	/// </summary>
	public interface ICredential : IEquatable<ICredential>
	{
		#region properties

		/// <summary>
		/// Return a text that can be used for displaying.
		/// </summary>
		string DisplayId { get; }

		#endregion
	}
}