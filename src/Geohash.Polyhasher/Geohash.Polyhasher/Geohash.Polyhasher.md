<a name='assembly'></a>
# Geohash.Polyhasher

## Contents

- [Polyhasher](#T-Geohash-Polyhasher-Polyhasher 'Geohash.Polyhasher.Polyhasher')
  - [Encode(geom,precision,mode)](#M-Geohash-Polyhasher-Polyhasher-Encode-NetTopologySuite-Geometries-Geometry,System-Int32,Geohash-Polyhasher-PolyhasherMode- 'Geohash.Polyhasher.Polyhasher.Encode(NetTopologySuite.Geometries.Geometry,System.Int32,Geohash.Polyhasher.PolyhasherMode)')
- [PolyhasherMode](#T-Geohash-Polyhasher-PolyhasherMode 'Geohash.Polyhasher.PolyhasherMode')
  - [Contains](#F-Geohash-Polyhasher-PolyhasherMode-Contains 'Geohash.Polyhasher.PolyhasherMode.Contains')
  - [Intersects](#F-Geohash-Polyhasher-PolyhasherMode-Intersects 'Geohash.Polyhasher.PolyhasherMode.Intersects')

<a name='T-Geohash-Polyhasher-Polyhasher'></a>
## Polyhasher `type`

##### Namespace

Geohash.Polyhasher

##### Summary

The Geohash.Polyhasher class encodes polygons (and some other geometries) as geohashes
at a desired level of precision. This implementation uses a fast recursive algorithm 
which will seamlessly optimize the output to save space. The output can be optimized further by using [GeoRaptor](https://github.com/andrerav/Geohash.GeoRaptor).

<a name='M-Geohash-Polyhasher-Polyhasher-Encode-NetTopologySuite-Geometries-Geometry,System-Int32,Geohash-Polyhasher-PolyhasherMode-'></a>
### Encode(geom,precision,mode) `method`

##### Summary

Creates a set of geohashes based on the input geometry.

##### Returns

A set of distinct geohashes that represents the input geometry

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| geom | [NetTopologySuite.Geometries.Geometry](#T-NetTopologySuite-Geometries-Geometry 'NetTopologySuite.Geometries.Geometry') | The geometry that will be encoded |
| precision | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The desired level of precision which will determine the resolution of the result |
| mode | [Geohash.Polyhasher.PolyhasherMode](#T-Geohash-Polyhasher-PolyhasherMode 'Geohash.Polyhasher.PolyhasherMode') | Can be one of PolyhasherMode.Intersects or PolyhasherMode.Contains. Default is Intersects. Use Contains if it is a requirement that the resulting geohashes are fully contained by the geometry (not valid for geometries that are not closed) |

<a name='T-Geohash-Polyhasher-PolyhasherMode'></a>
## PolyhasherMode `type`

##### Namespace

Geohash.Polyhasher

##### Summary

Determine which spatial relation to use when encoding the geometry

<a name='F-Geohash-Polyhasher-PolyhasherMode-Contains'></a>
### Contains `constants`

##### Summary

The geohashes must be fully contained by the geometry

<a name='F-Geohash-Polyhasher-PolyhasherMode-Intersects'></a>
### Intersects `constants`

##### Summary

The geohashes must either intersect or be fully contained by the geometry
