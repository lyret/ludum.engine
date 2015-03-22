using System;
using Microsoft.Xna.Framework;

namespace LudumEngine
{
	/// <summary>
	/// The Ludum Engines Color class is a shell for the XNA
	/// color class and can be used pretty much the exact same way.
	/// </summary>
	public struct Color : IEquatable<Color>
	{
		/// <summary>
		/// The XNA color this instance represents.
		/// </summary>
		internal Microsoft.Xna.Framework.Color XnaColor;

		// Static, pre defined colors
		#region predefinitions

		public static Color AliceBlue {
			get;
			private set;
		}

		public static Color AntiqueWhite {
			get;
			private set;
		}

		public static Color Aqua {
			get;
			private set;
		}

		public static Color Aquamarine {
			get;
			private set;
		}

		public static Color Azure {
			get;
			private set;
		}

		public static Color Beige {
			get;
			private set;
		}

		public static Color Bisque {
			get;
			private set;
		}

		public static Color Black {
			get;
			private set;
		}

		public static Color BlanchedAlmond {
			get;
			private set;
		}

		public static Color Blue {
			get;
			private set;
		}

		public static Color BlueViolet {
			get;
			private set;
		}

		public static Color Brown {
			get;
			private set;
		}

		public static Color BurlyWood {
			get;
			private set;
		}

		public static Color CadetBlue {
			get;
			private set;
		}

		public static Color Chartreuse {
			get;
			private set;
		}

		public static Color Chocolate {
			get;
			private set;
		}

		public static Color Coral {
			get;
			private set;
		}

		public static Color CornflowerBlue {
			get;
			private set;
		}

		public static Color Cornsilk {
			get;
			private set;
		}

		public static Color Crimson {
			get;
			private set;
		}

		public static Color Cyan {
			get;
			private set;
		}

		public static Color DarkBlue {
			get;
			private set;
		}

		public static Color DarkCyan {
			get;
			private set;
		}

		public static Color DarkGoldenrod {
			get;
			private set;
		}

		public static Color DarkGray {
			get;
			private set;
		}

		public static Color DarkGreen {
			get;
			private set;
		}

		public static Color DarkKhaki {
			get;
			private set;
		}

		public static Color DarkMagenta {
			get;
			private set;
		}

		public static Color DarkOliveGreen {
			get;
			private set;
		}

		public static Color DarkOrange {
			get;
			private set;
		}

		public static Color DarkOrchid {
			get;
			private set;
		}

		public static Color DarkRed {
			get;
			private set;
		}

		public static Color DarkSalmon {
			get;
			private set;
		}

		public static Color DarkSeaGreen {
			get;
			private set;
		}

		public static Color DarkSlateBlue {
			get;
			private set;
		}

		public static Color DarkSlateGray {
			get;
			private set;
		}

		public static Color DarkTurquoise {
			get;
			private set;
		}

		public static Color DarkViolet {
			get;
			private set;
		}

		public static Color DeepPink {
			get;
			private set;
		}

		public static Color DeepSkyBlue {
			get;
			private set;
		}

		public static Color DimGray {
			get;
			private set;
		}

		public static Color DodgerBlue {
			get;
			private set;
		}

		public static Color Firebrick {
			get;
			private set;
		}

		public static Color FloralWhite {
			get;
			private set;
		}

		public static Color ForestGreen {
			get;
			private set;
		}

		public static Color Fuchsia {
			get;
			private set;
		}

		public static Color Gainsboro {
			get;
			private set;
		}

		public static Color GhostWhite {
			get;
			private set;
		}

		public static Color Gold {
			get;
			private set;
		}

		public static Color Goldenrod {
			get;
			private set;
		}

		public static Color Gray {
			get;
			private set;
		}

		public static Color Green {
			get;
			private set;
		}

		public static Color GreenYellow {
			get;
			private set;
		}

		public static Color Honeydew {
			get;
			private set;
		}

		public static Color HotPink {
			get;
			private set;
		}

		public static Color IndianRed {
			get;
			private set;
		}

		public static Color Indigo {
			get;
			private set;
		}

		public static Color Ivory {
			get;
			private set;
		}

		public static Color Khaki {
			get;
			private set;
		}

		public static Color Lavender {
			get;
			private set;
		}

		public static Color LavenderBlush {
			get;
			private set;
		}

		public static Color LawnGreen {
			get;
			private set;
		}

		public static Color LemonChiffon {
			get;
			private set;
		}

		public static Color LightBlue {
			get;
			private set;
		}

		public static Color LightCoral {
			get;
			private set;
		}

		public static Color LightCyan {
			get;
			private set;
		}

		public static Color LightGoldenrodYellow {
			get;
			private set;
		}

		public static Color LightGray {
			get;
			private set;
		}

		public static Color LightGreen {
			get;
			private set;
		}

		public static Color LightPink {
			get;
			private set;
		}

		public static Color LightSalmon {
			get;
			private set;
		}

		public static Color LightSeaGreen {
			get;
			private set;
		}

		public static Color LightSkyBlue {
			get;
			private set;
		}

		public static Color LightSlateGray {
			get;
			private set;
		}

		public static Color LightSteelBlue {
			get;
			private set;
		}

		public static Color LightYellow {
			get;
			private set;
		}

		public static Color Lime {
			get;
			private set;
		}

		public static Color LimeGreen {
			get;
			private set;
		}

		public static Color Linen {
			get;
			private set;
		}

		public static Color Magenta {
			get;
			private set;
		}

		public static Color Maroon {
			get;
			private set;
		}

		public static Color MediumAquamarine {
			get;
			private set;
		}

		public static Color MediumBlue {
			get;
			private set;
		}

		public static Color MediumOrchid {
			get;
			private set;
		}

		public static Color MediumPurple {
			get;
			private set;
		}

		public static Color MediumSeaGreen {
			get;
			private set;
		}

		public static Color MediumSlateBlue {
			get;
			private set;
		}

		public static Color MediumSpringGreen {
			get;
			private set;
		}

		public static Color MediumTurquoise {
			get;
			private set;
		}

		public static Color MediumVioletRed {
			get;
			private set;
		}

		public static Color MidnightBlue {
			get;
			private set;
		}

		public static Color MintCream {
			get;
			private set;
		}

		public static Color MistyRose {
			get;
			private set;
		}

		public static Color Moccasin {
			get;
			private set;
		}

		public static Color NavajoWhite {
			get;
			private set;
		}

		public static Color Navy {
			get;
			private set;
		}

		public static Color OldLace {
			get;
			private set;
		}

		public static Color Olive {
			get;
			private set;
		}

		public static Color OliveDrab {
			get;
			private set;
		}

		public static Color Orange {
			get;
			private set;
		}

		public static Color OrangeRed {
			get;
			private set;
		}

		public static Color Orchid {
			get;
			private set;
		}

		public static Color PaleGoldenrod {
			get;
			private set;
		}

		public static Color PaleGreen {
			get;
			private set;
		}

		public static Color PaleTurquoise {
			get;
			private set;
		}

		public static Color PaleVioletRed {
			get;
			private set;
		}

		public static Color PapayaWhip {
			get;
			private set;
		}

		public static Color PeachPuff {
			get;
			private set;
		}

		public static Color Peru {
			get;
			private set;
		}

		public static Color Pink {
			get;
			private set;
		}

		public static Color Plum {
			get;
			private set;
		}

		public static Color PowderBlue {
			get;
			private set;
		}

		public static Color Purple {
			get;
			private set;
		}

		public static Color Red {
			get;
			private set;
		}

		public static Color RosyBrown {
			get;
			private set;
		}

		public static Color RoyalBlue {
			get;
			private set;
		}

		public static Color SaddleBrown {
			get;
			private set;
		}

		public static Color Salmon {
			get;
			private set;
		}

		public static Color SandyBrown {
			get;
			private set;
		}

		public static Color SeaGreen {
			get;
			private set;
		}

		public static Color SeaShell {
			get;
			private set;
		}

		public static Color Sienna {
			get;
			private set;
		}

		public static Color Silver {
			get;
			private set;
		}

		public static Color SkyBlue {
			get;
			private set;
		}

		public static Color SlateBlue {
			get;
			private set;
		}

		public static Color SlateGray {
			get;
			private set;
		}

		public static Color Snow {
			get;
			private set;
		}

		public static Color SpringGreen {
			get;
			private set;
		}

		public static Color SteelBlue {
			get;
			private set;
		}

		public static Color Tan {
			get;
			private set;
		}

		public static Color Teal {
			get;
			private set;
		}

		public static Color Thistle {
			get;
			private set;
		}

		public static Color Tomato {
			get;
			private set;
		}

		public static Color Transparent {
			get;
			private set;
		}

		public static Color TransparentBlack {
			get;
			private set;
		}

		public static Color Turquoise {
			get;
			private set;
		}

		public static Color Wheat {
			get;
			private set;
		}

		public static Color White {
			get;
			private set;
		}

		public static Color WhiteSmoke {
			get;
			private set;
		}

		public static Color Violet {
			get;
			private set;
		}

		public static Color Yellow {
			get;
			private set;
		}

		public static Color YellowGreen {
			get;
			private set;
		}
		
		#endregion predefinitions

		// The static constructor, creates the predefined colors.
		static Color ()
		{
			Color.TransparentBlack = new Color (0);
			Color.Transparent = new Color (0);
			Color.AliceBlue = new Color (4294965488);
			Color.AntiqueWhite = new Color (4292340730);
			Color.Aqua = new Color (4294967040);
			Color.Aquamarine = new Color (4292149119);
			Color.Azure = new Color (4294967280);
			Color.Beige = new Color (4292670965);
			Color.Bisque = new Color (4291093759);
			Color.Black = new Color (4278190080);
			Color.BlanchedAlmond = new Color (4291685375);
			Color.Blue = new Color (4294901760);
			Color.BlueViolet = new Color (4293012362);
			Color.Brown = new Color (4280953509);
			Color.BurlyWood = new Color (4287084766);
			Color.CadetBlue = new Color (4288716383);
			Color.Chartreuse = new Color (4278255487);
			Color.Chocolate = new Color (4280183250);
			Color.Coral = new Color (4283465727);
			Color.CornflowerBlue = new Color (4293760356);
			Color.Cornsilk = new Color (4292671743);
			Color.Crimson = new Color (4282127580);
			Color.Cyan = new Color (4294967040);
			Color.DarkBlue = new Color (4287299584);
			Color.DarkCyan = new Color (4287335168);
			Color.DarkGoldenrod = new Color (4278945464);
			Color.DarkGray = new Color (4289309097);
			Color.DarkGreen = new Color (4278215680);
			Color.DarkKhaki = new Color (4285249469);
			Color.DarkMagenta = new Color (4287299723);
			Color.DarkOliveGreen = new Color (4281297749);
			Color.DarkOrange = new Color (4278226175);
			Color.DarkOrchid = new Color (4291572377);
			Color.DarkRed = new Color (4278190219);
			Color.DarkSalmon = new Color (4286224105);
			Color.DarkSeaGreen = new Color (4287347855);
			Color.DarkSlateBlue = new Color (4287315272);
			Color.DarkSlateGray = new Color (4283387695);
			Color.DarkTurquoise = new Color (4291939840);
			Color.DarkViolet = new Color (4292018324);
			Color.DeepPink = new Color (4287829247);
			Color.DeepSkyBlue = new Color (4294950656);
			Color.DimGray = new Color (4285098345);
			Color.DodgerBlue = new Color (4294938654);
			Color.Firebrick = new Color (4280427186);
			Color.FloralWhite = new Color (4293982975);
			Color.ForestGreen = new Color (4280453922);
			Color.Fuchsia = new Color (4294902015);
			Color.Gainsboro = new Color (4292664540);
			Color.GhostWhite = new Color (4294965496);
			Color.Gold = new Color (4278245375);
			Color.Goldenrod = new Color (4280329690);
			Color.Gray = new Color (4286611584);
			Color.Green = new Color (4278222848);
			Color.GreenYellow = new Color (4281335725);
			Color.Honeydew = new Color (4293984240);
			Color.HotPink = new Color (4290013695);
			Color.IndianRed = new Color (4284243149);
			Color.Indigo = new Color (4286709835);
			Color.Ivory = new Color (4293984255);
			Color.Khaki = new Color (4287424240);
			Color.Lavender = new Color (4294633190);
			Color.LavenderBlush = new Color (4294308095);
			Color.LawnGreen = new Color (4278254716);
			Color.LemonChiffon = new Color (4291689215);
			Color.LightBlue = new Color (4293318829);
			Color.LightCoral = new Color (4286611696);
			Color.LightCyan = new Color (4294967264);
			Color.LightGoldenrodYellow = new Color (4292016890);
			Color.LightGray = new Color (4292072403);
			Color.LightGreen = new Color (4287688336);
			Color.LightPink = new Color (4290885375);
			Color.LightSalmon = new Color (4286226687);
			Color.LightSeaGreen = new Color (4289376800);
			Color.LightSkyBlue = new Color (4294626951);
			Color.LightSlateGray = new Color (4288252023);
			Color.LightSteelBlue = new Color (4292789424);
			Color.LightYellow = new Color (4292935679);
			Color.Lime = new Color (4278255360);
			Color.LimeGreen = new Color (4281519410);
			Color.Linen = new Color (4293325050);
			Color.Magenta = new Color (4294902015);
			Color.Maroon = new Color (4278190208);
			Color.MediumAquamarine = new Color (4289383782);
			Color.MediumBlue = new Color (4291624960);
			Color.MediumOrchid = new Color (4292040122);
			Color.MediumPurple = new Color (4292571283);
			Color.MediumSeaGreen = new Color (4285641532);
			Color.MediumSlateBlue = new Color (4293814395);
			Color.MediumSpringGreen = new Color (4288346624);
			Color.MediumTurquoise = new Color (4291613000);
			Color.MediumVioletRed = new Color (4286911943);
			Color.MidnightBlue = new Color (4285536537);
			Color.MintCream = new Color (4294639605);
			Color.MistyRose = new Color (4292994303);
			Color.Moccasin = new Color (4290110719);
			Color.NavajoWhite = new Color (4289584895);
			Color.Navy = new Color (4286578688);
			Color.OldLace = new Color (4293326333);
			Color.Olive = new Color (4278222976);
			Color.OliveDrab = new Color (4280520299);
			Color.Orange = new Color (4278232575);
			Color.OrangeRed = new Color (4278207999);
			Color.Orchid = new Color (4292243674);
			Color.PaleGoldenrod = new Color (4289390830);
			Color.PaleGreen = new Color (4288215960);
			Color.PaleTurquoise = new Color (4293848751);
			Color.PaleVioletRed = new Color (4287852763);
			Color.PapayaWhip = new Color (4292210687);
			Color.PeachPuff = new Color (4290370303);
			Color.Peru = new Color (4282353101);
			Color.Pink = new Color (4291543295);
			Color.Plum = new Color (4292714717);
			Color.PowderBlue = new Color (4293320880);
			Color.Purple = new Color (4286578816);
			Color.Red = new Color (4278190335);
			Color.RosyBrown = new Color (4287598524);
			Color.RoyalBlue = new Color (4292962625);
			Color.SaddleBrown = new Color (4279453067);
			Color.Salmon = new Color (4285694202);
			Color.SandyBrown = new Color (4284523764);
			Color.SeaGreen = new Color (4283927342);
			Color.SeaShell = new Color (4293850623);
			Color.Sienna = new Color (4281160352);
			Color.Silver = new Color (4290822336);
			Color.SkyBlue = new Color (4293643911);
			Color.SlateBlue = new Color (4291648106);
			Color.SlateGray = new Color (4287660144);
			Color.Snow = new Color (4294638335);
			Color.SpringGreen = new Color (4286578432);
			Color.SteelBlue = new Color (4290019910);
			Color.Tan = new Color (4287411410);
			Color.Teal = new Color (4286611456);
			Color.Thistle = new Color (4292394968);
			Color.Tomato = new Color (4282868735);
			Color.Turquoise = new Color (4291878976);
			Color.Violet = new Color (4293821166);
			Color.Wheat = new Color (4289978101);
			Color.White = new Color (4294967295);
			Color.WhiteSmoke = new Color (4294309365);
			Color.Yellow = new Color (4278255615);
			Color.YellowGreen = new Color (4281519514);
		}

		// Internal constructor, creates a new color from a real XNA color.
		internal Color (Microsoft.Xna.Framework.Color color)
		{
			this.XnaColor = color;
		}

		// Private constructor, creates a new color from a packed color value.
		private Color (uint packedValue)
		{
			this.XnaColor = Microsoft.Xna.Framework.Color.Black;
			this.XnaColor.PackedValue = packedValue;
		}

		// Public Constructors
		#region constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.Color"/> struct using
		/// RGB and a alpha values between 0 and 1.
		/// </summary>
		/// <param name="r">The red value.</param>
		/// <param name="g">The green value.</param>
		/// <param name="b">The blue value.</param>
		/// <param name="alpha">the alpha value.</param>
		public Color (float r, float g, float b, float alpha)
		{
			this.XnaColor = new Microsoft.Xna.Framework.Color(r,g,b,alpha);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.Color"/> struct using
		/// RGB and alpha values between 0 and 255.
		/// </summary>
		/// <param name="r">The red value.</param>
		/// <param name="g">The green value.</param>
		/// <param name="b">The blue value.</param>
		/// <param name="alpha">the alpha value.</param>
		public Color (int r, int g, int b, int alpha)
		{
			this.XnaColor = new Microsoft.Xna.Framework.Color(r,g,b,alpha);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.Color"/> struct using
		/// RGB values between 0 and 255 and full opacity.
		/// </summary>
		/// <param name="r">The red value.</param>
		/// <param name="g">The green value.</param>
		/// <param name="b">The blue value.</param>
		public Color (int r, int g, int b)
		{
			this.XnaColor = new Microsoft.Xna.Framework.Color(r,g,b);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="LudumEngine.Color"/> struct using
		/// RGB values between 0 and 1 and full opacity.
		/// </summary>
		/// <param name="r">The red value.</param>
		/// <param name="g">The green value.</param>
		/// <param name="b">The blue value.</param>
		public Color (float r, float g, float b)
		{
			this.XnaColor = new Microsoft.Xna.Framework.Color(r,g,b);
		}

		#endregion constructors

		// Public Properties
		#region properties

		/// <summary>
		/// Alpha value of this color.
		/// </summary>
		/// <value>a byte value.</value>
		public byte A {
			get {
				return this.XnaColor.A;
			}
			set {
				this.XnaColor.A = value;
			}
		}

		/// <summary>
		/// Blue color value of this color.
		/// </summary>
		/// <value>a byte value.</value>
		public byte B {
			get {
				return this.XnaColor.B;
			}
			set {
				this.XnaColor.B = value;
			}

		}

		/// <summary>
		/// Green color value of this color.
		/// </summary>
		/// <value>a byte value.</value>
		public byte G {
			get {
				return this.XnaColor.G;
			}
			set {
				this.XnaColor.G = value;
			}

		}

		/// <summary>
		/// Red color value of this color.
		/// </summary>
		/// <value>a byte value.</value>
		public byte R {
			get {
				return this.XnaColor.R;
			}
			set {
				this.XnaColor.R = value;
			}

		}

		#endregion properties

		// Public Methods
		#region methods

		/// <summary>
		/// Determines whether the specified <see cref="LudumEngine.Color"/> is equal to the current <see cref="LudumEngine.Color"/>.
		/// </summary>
		/// <param name="other">The <see cref="LudumEngine.Color"/> to compare with the current <see cref="LudumEngine.Color"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="LudumEngine.Color"/> is equal to the current
		/// <see cref="LudumEngine.Color"/>; otherwise, <c>false</c>.</returns>
		public bool Equals (Color other)
		{
			return this.XnaColor.PackedValue == other.XnaColor.PackedValue;
		}

		/// <summary>
		/// Determines whether the specified <see cref="System.Object"/> is equal to the current <see cref="LudumEngine.Color"/>.
		/// </summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="LudumEngine.Color"/>.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current <see cref="LudumEngine.Color"/>;
		/// otherwise, <c>false</c>.</returns>
		public override bool Equals (object obj)
		{
			return obj is Color && this.Equals ((Color)obj);
		}

		/// <summary>
		/// Serves as a hash function for a <see cref="LudumEngine.Color"/> object.
		/// </summary>
		/// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures such as a hash table.</returns>
		public override int GetHashCode ()
		{
			return this.XnaColor.GetHashCode();
		}

		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="LudumEngine.Color"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="LudumEngine.Color"/>.</returns>
		public override string ToString ()
		{
			return this.XnaColor.ToString();
		}

		#endregion methods

		// Public Operators
		#region operators

		public static bool operator == (Color a, Color b)
		{
			return a.A == b.A && a.R == b.R && a.G == b.G && a.B == b.B;
		}

		public static bool operator != (Color a, Color b)
		{
			return !(a == b);
		}

		public static Color operator * (Color value, float scale)
		{
			return new Color ((int)((float)value.R * scale), (int)((float)value.G * scale), (int)((float)value.B * scale), (int)((float)value.A * scale));
		}

		#endregion operators
	}
}
