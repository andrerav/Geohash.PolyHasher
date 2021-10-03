using CommandLine;

namespace Geohash.Polyhasher.CLI
{
    internal class CommandLineOptions
	{
		[Option('f', "input-file", Required = false, HelpText = "Path to input file")]
		public string InputFile { get; set; }

		[Option('F', "format", Required = false, HelpText = "Input format. Supported formats are: WKT. Default value: WKT", Default = InputFormat.WKT)]
		public InputFormat Format { get; set; }

		[Option('p', "precision", Required = false, HelpText = "The geohash precision level to use when hashing the geometries. Default value: 6", Default = 6)]
		public int Precision { get; set; }

		[Option('m', "mode", Required = false, HelpText = "Which mode to use. Supported modes are: Intersect, Contains. Default: Intersect", Default = PolyhasherMode.Intersects)]
		public PolyhasherMode Mode { get; set; }

		[Option('g', "output-geometry", Required = false, HelpText = "Enable this to output the result as CSV with WKB geometries added for individual hashes. Default value: false", Default = false)]
		public bool? OutputGeometry { get; set; }

		[Option('h', "headers", Required = false, HelpText = "If output-geometry is enabled, then enable this to add CSV headers to the output. Default value: false", Default = false)]
		public bool? AddHeaders { get; set; }

		[Option('s', "separator", Required = false, HelpText = "If output-geometry is enabled, this option can be used to customize the column separator", Default = ";")]
		public string Separator { get; set; }
	}
}
