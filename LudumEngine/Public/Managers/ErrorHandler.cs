using System;

namespace LudumEngine
{
	/// <summary>
	/// The GeneralError class extends the standard system exception. It exists
	/// as a future extension point for furthering the error handeling of the game engine.
	/// </summary>
	public class GeneralError : Exception {

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.GeneralError"/> class.
		/// </summary>
		/// <param name="explatnation">Explatnation.</param>
		internal GeneralError(string explanation) : base(explanation) {}
	}

	/// <summary>
	/// An IgnorableError will as the name suggest be ignored in the standard error handling.
	/// </summary>
	public class IgnorableError : Exception {

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.IgnorableError"/> class.
		/// </summary>
		/// <param name="explatnation">Explatnation.</param>
		internal IgnorableError(string explanation) : base(explanation) {}
	}

	/// <summary>
	/// The Error Handler keeps track of a few variables for handeling exceptions and errors
	/// constitently across the engine. It contains methods for throwing new exceptions
	/// that should be caught in the game loop.
	/// </summary>
	public class ErrorHandler
	{
		#region settings

		internal bool Ignore = false;

		#endregion

		/// <summary>
		/// Initializes a new instance of the class.
		/// </summary>
		public ErrorHandler() {}

		/// <summary>
		/// Uhs the oh. <-- awesome automatic comment from Mono Develop.
		/// Throws a new exception on errors, or ignores it depending on the game settings.
		/// Can be extended to include logging.
		/// </summary>
		/// <param name="explanation">What error occured.</param>
		/// <param name="exception">an optional exception, if specified the error can not be ignored.</param>
		public Exception General(String explanation = "", Exception exception = null)
		{
			Console.WriteLine ("General Error: " + explanation);

			if (exception != null) {
				Console.WriteLine("Program Exception" + exception.Message);
			}

			if (exception != null) {
				explanation += " | " + exception.Message;
			}

			if (Ignore)
			{
				return new IgnorableError(explanation);
			}
			else
			{
				return new GeneralError(explanation);
			}
		}
	}
}