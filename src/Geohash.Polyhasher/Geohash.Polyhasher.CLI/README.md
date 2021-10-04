<a name='assembly'></a>
# Geohash.Polyhasher.CLI

## Contents

- [InputFormat](#T-Geohash-Polyhasher-CLI-InputFormat 'Geohash.Polyhasher.CLI.InputFormat')
  - [WKT](#F-Geohash-Polyhasher-CLI-InputFormat-WKT 'Geohash.Polyhasher.CLI.InputFormat.WKT')
- [Program](#T-Geohash-Polyhasher-CLI-Program 'Geohash.Polyhasher.CLI.Program')
  - [BoundingBox(geohash)](#M-Geohash-Polyhasher-CLI-Program-BoundingBox-System-String- 'Geohash.Polyhasher.CLI.Program.BoundingBox(System.String)')
  - [GeometryToGeohash(geom,precision,mode)](#M-Geohash-Polyhasher-CLI-Program-GeometryToGeohash-NetTopologySuite-Geometries-Geometry,System-Int32,Geohash-Polyhasher-PolyhasherMode- 'Geohash.Polyhasher.CLI.Program.GeometryToGeohash(NetTopologySuite.Geometries.Geometry,System.Int32,Geohash.Polyhasher.PolyhasherMode)')
  - [GetInputReader(o)](#M-Geohash-Polyhasher-CLI-Program-GetInputReader-Geohash-Polyhasher-CLI-CommandLineOptions- 'Geohash.Polyhasher.CLI.Program.GetInputReader(Geohash.Polyhasher.CLI.CommandLineOptions)')
  - [OutputGeohashes(o,compressed)](#M-Geohash-Polyhasher-CLI-Program-OutputGeohashes-Geohash-Polyhasher-CLI-CommandLineOptions,System-Collections-Generic-HashSet{System-String}- 'Geohash.Polyhasher.CLI.Program.OutputGeohashes(Geohash.Polyhasher.CLI.CommandLineOptions,System.Collections.Generic.HashSet{System.String})')
  - [ReadGeometry(reader)](#M-Geohash-Polyhasher-CLI-Program-ReadGeometry-System-IO-TextReader- 'Geohash.Polyhasher.CLI.Program.ReadGeometry(System.IO.TextReader)')
  - [ValidateArguments(o)](#M-Geohash-Polyhasher-CLI-Program-ValidateArguments-Geohash-Polyhasher-CLI-CommandLineOptions- 'Geohash.Polyhasher.CLI.Program.ValidateArguments(Geohash.Polyhasher.CLI.CommandLineOptions)')
  - [ValidateReader(reader)](#M-Geohash-Polyhasher-CLI-Program-ValidateReader-System-IO-TextReader- 'Geohash.Polyhasher.CLI.Program.ValidateReader(System.IO.TextReader)')
  - [WriteError(message)](#M-Geohash-Polyhasher-CLI-Program-WriteError-System-String- 'Geohash.Polyhasher.CLI.Program.WriteError(System.String)')

<a name='T-Geohash-Polyhasher-CLI-InputFormat'></a>
## InputFormat `type`

##### Namespace

Geohash.Polyhasher.CLI

##### Summary

Supported input geometry formats for this program

<a name='F-Geohash-Polyhasher-CLI-InputFormat-WKT'></a>
### WKT `constants`

##### Summary

Well-known text

<a name='T-Geohash-Polyhasher-CLI-Program'></a>
## Program `type`

##### Namespace

Geohash.Polyhasher.CLI

##### Summary

A simple class to host this program

<a name='M-Geohash-Polyhasher-CLI-Program-BoundingBox-System-String-'></a>
### BoundingBox(geohash) `method`

##### Summary

Converts a valid geohash to its corresponding bounding box

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| geohash | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |

<a name='M-Geohash-Polyhasher-CLI-Program-GeometryToGeohash-NetTopologySuite-Geometries-Geometry,System-Int32,Geohash-Polyhasher-PolyhasherMode-'></a>
### GeometryToGeohash(geom,precision,mode) `method`

##### Summary

Generates the actual geohashes from a given geometry

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| geom | [NetTopologySuite.Geometries.Geometry](#T-NetTopologySuite-Geometries-Geometry 'NetTopologySuite.Geometries.Geometry') |  |
| precision | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') |  |
| mode | [Geohash.Polyhasher.PolyhasherMode](#T-Geohash-Polyhasher-PolyhasherMode 'Geohash.Polyhasher.PolyhasherMode') |  |

<a name='M-Geohash-Polyhasher-CLI-Program-GetInputReader-Geohash-Polyhasher-CLI-CommandLineOptions-'></a>
### GetInputReader(o) `method`

##### Summary

Returns an input reader based on whether the user has specified an input file or not

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| o | [Geohash.Polyhasher.CLI.CommandLineOptions](#T-Geohash-Polyhasher-CLI-CommandLineOptions 'Geohash.Polyhasher.CLI.CommandLineOptions') |  |

<a name='M-Geohash-Polyhasher-CLI-Program-OutputGeohashes-Geohash-Polyhasher-CLI-CommandLineOptions,System-Collections-Generic-HashSet{System-String}-'></a>
### OutputGeohashes(o,compressed) `method`

##### Summary

Outputs compressed geohashes to standard output

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| o | [Geohash.Polyhasher.CLI.CommandLineOptions](#T-Geohash-Polyhasher-CLI-CommandLineOptions 'Geohash.Polyhasher.CLI.CommandLineOptions') |  |
| compressed | [System.Collections.Generic.HashSet{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.HashSet 'System.Collections.Generic.HashSet{System.String}') |  |

<a name='M-Geohash-Polyhasher-CLI-Program-ReadGeometry-System-IO-TextReader-'></a>
### ReadGeometry(reader) `method`

##### Summary

Reads a single polygon from a TextReader

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reader | [System.IO.TextReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextReader 'System.IO.TextReader') |  |

<a name='M-Geohash-Polyhasher-CLI-Program-ValidateArguments-Geohash-Polyhasher-CLI-CommandLineOptions-'></a>
### ValidateArguments(o) `method`

##### Summary

Validates the arguments specified by the user

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| o | [Geohash.Polyhasher.CLI.CommandLineOptions](#T-Geohash-Polyhasher-CLI-CommandLineOptions 'Geohash.Polyhasher.CLI.CommandLineOptions') |  |

<a name='M-Geohash-Polyhasher-CLI-Program-ValidateReader-System-IO-TextReader-'></a>
### ValidateReader(reader) `method`

##### Summary

Validate that there is input on the reader

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| reader | [System.IO.TextReader](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.IO.TextReader 'System.IO.TextReader') |  |

<a name='M-Geohash-Polyhasher-CLI-Program-WriteError-System-String-'></a>
### WriteError(message) `method`

##### Summary

Writes an error message to stderr

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') |  |
