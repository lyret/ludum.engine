using System;
using LudumEngine;

namespace BelieveInKong
{
	/// <summary>
	/// The name component holds a textual name for the entity.
	/// </summary>
	public class Name : Component
	{
		/// <summary>
		/// Initializes this component.
		/// </summary>
		public sealed override void Initialize() {}

		/// <summary>
		/// The name value.
		/// </summary>
		/// <value>The name.</value>
		public String Value {get; set;}

		/// <summary>
		/// Set the specified name.
		/// </summary>
		/// <param name="name">a name.</param>
		public void Set(string name)
		{
			Value = name;
		}
	}
}

