using NetTopologySuite.Geometries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Geohash.Polyhasher
{
    public interface IPolyhasher
    {
        HashSet<string> Encode(Geometry geom, int precision, PolyhasherMode mode);
    }
}