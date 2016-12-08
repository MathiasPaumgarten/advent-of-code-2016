using System;
using System.IO;

public static class AdventOfCode {

    private static string ReadInput( string path ) {
        if ( File.Exists( path ) ) {
            return File.ReadAllText( path );
        }

        return "";
    }

    public static void Main() {

        string input;

        input = ReadInput( "day-01/input.txt" );

        Console.WriteLine( "Day 1 - Part 1: " + Day1.Part1( input ) );
        Console.WriteLine( "Day 1 - Part 2: " + Day1.Part2( input ) );
    }
}