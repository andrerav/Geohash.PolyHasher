using NetTopologySuite.Geometries;
using NetTopologySuite.Geometries.Prepared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geohash.Polyhasher
{
    /// <summary>
    /// The Geohash.Polyhasher class encodes polygons (and some other geometries) as geohashes
    /// at a desired level of precision. This implementation uses a fast recursive algorithm 
    /// which will seamlessly optimize the output to save space. The output can be optimized further by using [GeoRaptor](https://github.com/andrerav/Geohash.GeoRaptor).
    /// </summary>
    public class Polyhasher : IPolyhasher
    {

        private static Lazy<Geohasher> Geohasher = new Lazy<Geohasher>(() => new Geohasher());

        /// <summary>
        /// Creates a set of geohashes based on the input geometry.
        /// </summary>
        /// <param name="geom">The geometry that will be encoded</param>
        /// <param name="precision">The desired level of precision which will determine the resolution of the result</param>
        /// <param name="mode">Can be one of PolyhasherMode.Intersects or PolyhasherMode.Contains. Default is Intersects. Use Contains if it is a requirement that the resulting geohashes are fully contained by the geometry (not valid for geometries that are not closed)</param>
        /// <returns>A set of distinct geohashes that represents the input geometry</returns>
        public HashSet<string> Encode(Geometry geom, int precision, PolyhasherMode mode)
        {
            var hasher = Geohasher.Value;
            var containingHash = LongestCommonPrefix(geom.Envelope.Coordinates.Select(coord => hasher.Encode(coord.Y, coord.X, precision)).ToArray());
            var inside = new HashSet<string>();
            var result = new HashSet<string>();
            var prepared = PreparedGeometryFactory.Prepare(geom);

            result = ProcessChildren(result, containingHash, prepared, precision, inside, mode);
            result.UnionWith(inside);

            return result;
        }

        private HashSet<string> ProcessChildren(HashSet<string> result, string containingHash, 
            IPreparedGeometry geom, int desiredPrecision,
            HashSet<string> inside, PolyhasherMode mode)
        {
            var children = GetCombinations(containingHash);

            foreach(var child in children)
            {
                var currentPrecision = child.Length;
                var childGeom = BoundingBox(child);

                if (geom.Contains(childGeom))
                {
                    inside.Add(child);
                }
                else if (geom.Intersects(childGeom))
                {
                    if (currentPrecision == desiredPrecision)
                    {
                        if (mode == PolyhasherMode.Intersects)
                        {
                            result.Add(child);
                        }
                    }
                    else
                    {
                        ProcessChildren(result, child, geom, desiredPrecision, inside, mode);
                    }
                }
                else
                {
                    // Entirely outside (or possibly inbetween incase of a multipolygon)
                }
            }

            return result;
        }

        // TODO: Test and benchmark different algorithms
        private static string LongestCommonPrefix(string[] strings)
        {
            if (strings.Length == 0)
            {
                return "";
            }
            var pre = strings[0];
            var match = pre.Length - 1;
            for (var i = 1; i < strings.Length; i++)
            {
                var cur = strings[i];
                int j, k;
                for (j = 0, k = 0; j <= match && k < cur.Length; j++, k++)
                {
                    if (pre[j] != cur[k])
                        break;
                }
                match = j - 1;
                if (match == -1)
                    return "";
            }
            return pre.Substring(0, match + 1);
        }

        // TODO: Benchmark this vs. Geohasher.GetSubhashes(). Most likely little to no difference.
        private static List<string> GetCombinations(string str)
        {
            var base32 = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "b", "c", "d", "e", "f", "g",
                                            "h", "j", "k", "m", "n", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            return (from i in base32
                    select (str + $"{i}")).ToList();
        }

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
    }
}
