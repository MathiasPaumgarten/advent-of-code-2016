using System;
using System.Linq;
using System.Reflection;
using System.IO;

public static class AdventOfCode {

    public static void Main( string[] args ) {

        if ( args.Length > 0 ) {
            RunSpecific( Int32.Parse( args[ 0 ] ), Int32.Parse( args[ 1 ] ) );
            return;
        }

        string input;

        input = ReadInput( "day-01/input.txt" );

        PrintResult( 1, 1, Day1.Part1( input ) );
        PrintResult( 1, 2, Day1.Part2( input ) );

        input = ReadInput( "day-02/input.txt" );

        PrintResult( 2, 1, Day2.Part1( input ) );
        PrintResult( 2, 2, Day2.Part2( input ) );

        input = ReadInput( "day-03/input.txt" );

        PrintResult( 3, 1, Day3.Part1( input ) );
        PrintResult( 3, 2, Day3.Part2( input ) );

        input = ReadInput( "day-04/input.txt" );

        PrintResult( 4, 1, Day4.Part1( input ) );
        PrintResult( 4, 2, Day4.Part2( input ) );

        input = ReadInput( "day-05/input.txt" );

        PrintResult( 5, 1, Day5.Part1( input ) );
        PrintResult( 5, 2, Day5.Part2( input ) );

        input = ReadInput( "day-06/input.txt" );

        PrintResult( 6, 1, Day6.Part1( input ) );
        PrintResult( 6, 2, Day6.Part2( input ) );

        input = ReadInput( "day-07/input.txt" );

        PrintResult( 7, 1, Day7.Part1( input ) );
    }

    private static void RunSpecific( int day, int part ) {

        string input = ReadInput( "day-" + day.ToString().PadLeft( 2, '0' ) + "/input.txt" );

        var assembly = Assembly.GetEntryAssembly();
        var type = assembly.GetTypes().First( t => t.Name == "Day" + day );

        Console.WriteLine( type.GetMethod( "Part" + part ).Invoke( type, new [] { input } ) );
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