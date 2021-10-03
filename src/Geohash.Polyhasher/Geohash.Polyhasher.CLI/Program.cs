using CommandLine;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Geohash.Polyhasher.CLI
{
    /// <summary>
    /// A simple class to host this program
    /// </summary>
    public static class Program
    {
        static int exitCode = 0;

        static Lazy<IPolyhasher> Polyhasher = new Lazy<IPolyhasher>(() => new Polyhasher());
        static Lazy<Geohasher> Geohasher = new Lazy<Geohasher>((() => new Geohasher()));

        static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<CommandLineOptions>(args)
                .WithParsed(o =>
                {
                    ValidateArguments(o);

                    if (exitCode > 0) { return; }

                    var reader = GetInputReader(o);

                    ValidateReader(reader);

                    var geometry = ReadGeometry(reader);

                    var sw = new Stopwatch();
                    sw.Start();

                    var geohashes = GeometryToGeohash(geometry, o.Precision, o.Mode);

                    sw.Stop();
                    OutputGeohashes(o, geohashes);
                });
        }

        /// <summary>
        /// Generates the actual geohashes from a given geometry
        /// </summary>
        /// <param name="geom"></param>
        /// <param name="precision"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private static HashSet<string> GeometryToGeohash(Geometry geom, int precision, PolyhasherMode mode)
        {
            return Polyhasher.Value.Encode(geom, precision, mode);
        }

        /// <summary>
        /// Outputs compressed geohashes to standard output
        /// </summary>
        /// <param name="o"></param>
        /// <param name="compressed"></param>
        private static void OutputGeohashes(CommandLineOptions o, HashSet<string> compressed)
        {
            var outputGeometry = o.OutputGeometry.HasValue && o.OutputGeometry.Value;

            if (outputGeometry && o.AddHeaders == true)
            {
                Console.WriteLine("geohash" + o.Separator + "geometry");
            }
            foreach (var g in compressed)
            {
                if (outputGeometry)
                {
                    var geometry = BoundingBox(g);
                    Console.WriteLine(g + o.Separator + geometry.AsText());

                }
                else
                {
                    Console.WriteLine(g);
                }
            }
        }

        /// <summary>
        /// Converts a valid geohash to its corresponding bounding box
        /// </summary>
        /// <param name="geohash"></param>
        /// <returns></returns>
        private static Polygon BoundingBox(string geohash)
        {
            var bb = Geohasher.Value.GetBoundingBox(geohash);

            var coordinates = new List<Coordinate>();
            coordinates.Add(new Coordinate(bb[3], bb[0]));
            coordinates.Add(new Coordinate(bb[3], bb[1]));
            coordinates.Add(new Coordinate(bb[2], bb[1]));
            coordinates.Add(new Coordinate(bb[2], bb[0]));
            coordinates.Add(new Coordinate(bb[3], bb[0]));

            var linearRing = new LinearRing(coordinates.ToArray());
            var polygon = new Polygon(linearRing);
            return polygon;
        }

        /// <summary>
        /// Reads a single polygon from a TextReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static Geometry ReadGeometry(TextReader reader)
        {
            return new WKTReader().Read(reader);
        }

        /// <summary>
        /// Validates the arguments specified by the user
        /// </summary>
        /// <param name="o"></param>
        private static void ValidateArguments(CommandLineOptions o)
        {
            if (!string.IsNullOrWhiteSpace(o.InputFile) && !File.Exists(o.InputFile))
            {
                WriteError("Input file does not exist");
                exitCode = 1;
            }
        }

        /// <summary>
        /// Writes an error message to stderr
        /// </summary>
        /// <param name="message"></param>
        private static void WriteError(string message)
        {
            Console.Error.WriteLine("Error: " + message);
        }

        /// <summary>
        /// Returns an input reader based on whether the user has specified an input file or not
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        private static TextReader GetInputReader(CommandLineOptions o)
        {
            TextReader reader;
            if (!string.IsNullOrWhiteSpace(o.InputFile))
            {

                reader = File.OpenText(o.InputFile);
            }
            else
            {
                reader = Console.In;
            }

            return reader;
        }

        /// <summary>
        /// Validate that there is input on the reader
        /// </summary>
        /// <param name="reader"></param>
        private static void ValidateReader(TextReader reader)
        {
            if (reader == null)
            {
                WriteError("Unable to read input, exiting");
                exitCode = 1;
            }
            else if (reader.Peek() == -1)
            {
                WriteError("No input detected");
                exitCode = 1;
            }
        }
    }
}
