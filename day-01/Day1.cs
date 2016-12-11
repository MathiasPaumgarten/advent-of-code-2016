using System;
using System.Numerics;
using System.Collections.Generic;

public static class Day1 {

    private static void RotateVector( ref Vector2 vector, double radians ) {

        Vector2 temp = new Vector2();

        temp.X = (float) Math.Round( vector.X * (float) Math.Cos( radians ) - vector.Y * (float) Math.Sin( radians ) );
        temp.Y = (float) Math.Round( vector.X * (float) Math.Sin( radians ) + vector.Y * (float) Math.Cos( radians ) );

        vector.X = temp.X;
        vector.Y = temp.Y;
    }

    private static double GetRotation( string command ) {
        return command.Trim()[ 0 ] == 'R' ? - Math.PI / 2.0 : Math.PI / 2.0;
    }

    private static int GetDistance( string command ) {
        return Int32.Parse( command.Trim().Substring( 1 ) );
    }

    private static string GetManhattanDistance( Vector2 position ) {
        return ( Math.Abs( position.X ) + Math.Abs( position.Y ) ).ToString();
    }

    public static string Part1( string input ) {
        string[] commands = input.Split( ',' );

        Vector2 direction = new Vector2( 0, 1 );
        Vector2 position = new Vector2();

        foreach ( string command in commands ) {
            double rotation = GetRotation( command );
            int distance = GetDistance( command );

            RotateVector( ref direction, rotation );

            position += direction * distance;
        }

        return GetManhattanDistance( position );
    }

    public static string Part2( string input ) {
        string[] commands = input.Split( ',' );

        Vector2 direction = new Vector2( 0, 1 );
        Vector2 position = new Vector2();

        List<Vector2> locations = new List<Vector2>();

        foreach ( string command in commands ) {
            double rotation = GetRotation( command );
            int distance = GetDistance( command );

            RotateVector( ref direction, rotation );

            bool hasBeenHere = false;

            for ( int i = 0; i < distance; i++ ) {
                position += direction;

                if ( locations.Contains( position ) ) {
                    hasBeenHere = true;
                    break;
                }

                locations.Add( position );
            }

            if ( hasBeenHere ) break;
        }

        return GetManhattanDistance( position );
    }

}
