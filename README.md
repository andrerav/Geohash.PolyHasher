# Geohash.PolyHasher

# Introduction
Geohash.Polyhasher is a .NET library and command line tool that converts geometries such as polygons and linestrings to optimized sets of geohashes.

# Download
| Package | Link | Description |
| ------- | ---- | ----------- |
| Geohash.Polyhasher | [![image](https://img.shields.io/nuget/v/Geohash.Polyhasher.svg)](https://www.nuget.org/packages/Geohash.Polyhasher/) | Use this package to install Polyhasher as a library in your C#/.NET project. |
| Geohash.GeoRaptor.CLI | [![image](https://img.shields.io/nuget/v/Geohash.Polyhasher.CLI.svg)](https://www.nuget.org/packages/Geohash.Polyhasher.CLI/) | Use this package to install Polyhasher as a dotnet command line tool (see [CLI quickstart](#command-line-quickstart) below). You can install this tool using the command `dotnet tool install --global Geohash.Polyhasher.CLI`. |

# Description
Geohash.Polyhasher is a tool that can convert geometries such as linestrings, polygons, multipolygons and more to well-optimized sets of geohashes. If you are not familiar with the concept of geohashing, then you may want to familiarize yourself with the concept of geohashes first, and then come back here.

To understand what this library does, please look at this illustration that shows the input and output from this library:

_TODO_

# What can you do with Polyhasher?
This library is useful if you are working with spatial data and need to make computations such as finding all points within a polygon, but without using a spatial database and still retaining excellent performance. By encoding geometries as geohashes and using a prefix tree for lookup, you can achieve performance that is on par or better than using geospatial databases. 

# API Quickstart

The following example can be pasted directly into Program.cs in a .NET 6.0 or newer console application:

```csharp
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
```

Also see the provided [example project](https://github.com/andrerav/Geohash.PolyHasher/tree/main/src/Geohash.Polyhasher/Geohash.Polyhasher.Example).


## API documentation

[The full API documentation is available here](https://github.com/andrerav/Geohash.PolyHasher/tree/main/src/Geohash.Polyhasher/Geohash.Polyhasher)

# Command line quickstart

_TODO_
