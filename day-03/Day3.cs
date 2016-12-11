using System;
using System.Linq;

public class Day3 {

    public static string Part1( string input ) {

        var count = 0;

        foreach ( string line in input.ReadLines() ) {
            if ( TestValues( GetSides( line ) ) ) count++;
        }

        return count.ToString();
    }

    public static string Part2( string input ) {

        var count = 0;
        var sets = 0;
        var pillars = new int[ 3 ][];

        foreach ( string line in input.ReadLines() ) {
            var sides = GetSides( line );

            if ( sets == 0 ) {
                for ( int j = 0; j < 3; j++ ) pillars[ j ] = new int[ 3 ];
            }

            pillars[ 0 ][ sets ] = sides[ 0 ];
            pillars[ 1 ][ sets ] = sides[ 1 ];
            pillars[ 2 ][ sets ] = sides[ 2 ];

            sets++;

            if ( sets == 3 ) {
                for ( int i = 0; i < 3; i++ ) {
                    if ( TestValues( pillars[ i ] ) ) count++;
                }

                sets = 0;
            }
        }

        return count.ToString();

    }

    private static int[] GetSides( string line ) {
        return line
            .Trim()
            .Split( new string[] { " " }, StringSplitOptions.RemoveEmptyEntries )
            .Select( value => Int32.Parse( value ) )
            .ToArray();
    }

    private static bool TestValues( int[] values ) {
        return TestTriangle( values[ 0 ], values[ 1 ], values[ 2 ] ) &&
            TestTriangle( values[ 1 ], values[ 2 ], values[ 0 ] ) &&
            TestTriangle( values[ 0 ], values[ 2 ], values[ 1 ] );
    }

    private static bool TestTriangle( int a, int b, int c ) {
        return a + b > c;
    }
}