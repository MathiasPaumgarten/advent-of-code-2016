using System;
using System.IO;

public static class AdventOfCode {

    public static void Main( string[] args ) {

        string input;

        input = ReadInput( "day-01/input.txt" );

        PrintResult( 1, 1, Day1.Part1( input ) );
        PrintResult( 1, 2, Day1.Part2( input ) );

        input = ReadInput( "day-02/input.txt" );

        PrintResult( 2, 1, Day2.Part1( input ) );
        PrintResult( 2, 2, Day2.Part2( input ) );

    }

    private static string ReadInput( string path ) {
        if ( File.Exists( path ) ) {
            return File.ReadAllText( path );
        }

        return "";
    }


    private static void PrintResult( int day, int part, string result ) {
        Console.WriteLine( "Day " + day + " - Part " + part + ": " + result );

        if ( part == 2 ) Console.WriteLine();
    }
}