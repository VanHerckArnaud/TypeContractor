using System.Text.RegularExpressions;

namespace TypeContractor.Helpers;

internal static partial class LineEndingHelpers
{
	[GeneratedRegex(@"\r\n|\r|\n")]
	private static partial Regex LineBreakRegex();

	public static string ToNewLine(this LineEndings lineEndings) => lineEndings switch
	{
		LineEndings.Crlf => "\r\n",
		LineEndings.Lf => "\n",
		_ => throw new ArgumentOutOfRangeException(nameof(lineEndings), lineEndings, "Unknown line ending"),
	};

	/// <summary>
	/// Replaces every line break in <paramref name="input"/> with the configured line ending,
	/// so generated files are identical regardless of the OS TypeContractor runs on.
	/// </summary>
	public static string NormalizeLineEndings(string input, LineEndings lineEndings) =>
		LineBreakRegex().Replace(input, lineEndings.ToNewLine());
}
