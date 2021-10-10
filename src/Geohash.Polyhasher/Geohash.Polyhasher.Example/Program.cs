using Geohash.Polyhasher;
using NetTopologySuite.IO;

// Define the polygon we wish to encode
var polygon = new WKTReader().Read("MULTIPOLYGON (((40 40, 20 45, 45 30, 40 40)), " +
                                   "((20 35, 45 20, 30 5, 10 10, 10 30, 20 35), " +
                                   "(30 20, 20 25, 20 15, 30 20)))");

// Create a new polyhasher instance
var polyhasher = new Polyhasher();

// Returns a HashSet<string> of 27 geohashes which encodes the multipolygon specified above
var geohashes = polyhasher.Encode(polygon, 2, PolyhasherMode.Intersects);

