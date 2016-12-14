using System;
using System.Linq;
using System.Reflection;
using System.IO;

public static class AdventOfCode {

    public static void Main( string[] args ) {

        if ( args.Length == 2 ) {
            RunSpecific( Int32.Parse( args[ 0 ] ), Int32.Parse( args[ 1 ] ) );
            return;
        }

        Console.WriteLine( "Wrong number of arguments. Two arguments needed: <day> <part>" );
    }

    private static void RunSpecific( int day, int part ) {

        string input = ReadInput( "day-" + day.ToString().PadLeft( 2, '0' ) + "/input.txt" );

        var assembly = Assembly.GetEntryAssembly();
        var type = assembly.GetTypes().First( t => t.Name == "Day" + day );
        var result = type.GetMethod( "Part" + part ).Invoke( type, new [] { input } );

        Console.WriteLine( result );
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