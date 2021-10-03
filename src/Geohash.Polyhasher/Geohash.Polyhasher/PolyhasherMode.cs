namespace Geohash.Polyhasher
{
    /// <summary>
    /// Determine which spatial relation to use when encoding the geometry
    /// </summary>
    public enum PolyhasherMode
    {
        /// <summary>
        /// The geohashes must be fully contained by the geometry
        /// </summary>
        Contains,

        /// <summary>
        /// The geohashes must either intersect or be fully contained by the geometry
        /// </summary>
        Intersects
    }
}
