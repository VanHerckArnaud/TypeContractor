using TypeContractor.Tool;

namespace TypeContractor.Tests.Tool
{
	public class ReflectionContextHelperTests
	{
		[Fact]
		public void GetNetCorePack_Joins_Pack_Path_Without_Backslash()
		{
			var tempRoot = Path.Combine(Path.GetTempPath(), "typecontractor-" + Guid.NewGuid());
			try
			{
				var expected = Path.Combine(tempRoot, "Microsoft.NETCore.App.Ref", "10.0.1", "ref", "net10.0");
				Directory.CreateDirectory(expected);

				var result = ReflectionContextHelper.GetNetCorePack(tempRoot, "Microsoft.NETCore.App.Ref", 10);

				result.Should().Be(expected);
			}
			finally
			{
				if (Directory.Exists(tempRoot))
					Directory.Delete(tempRoot, recursive: true);
			}
		}

		[Fact]
		public void GetDefaultPacksPath_Exists_And_Contains_NetCore_Ref_Pack()
		{
			var packsPath = ReflectionContextHelper.GetDefaultPacksPath();

			Directory.Exists(packsPath).Should().BeTrue($"expected default packs path '{packsPath}' to exist");
			Directory.Exists(Path.Combine(packsPath, "Microsoft.NETCore.App.Ref")).Should().BeTrue($"expected '{packsPath}' to contain 'Microsoft.NETCore.App.Ref'");
		}
	}
}
