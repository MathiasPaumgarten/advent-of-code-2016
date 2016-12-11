using System.Collections.Generic;
using System.Linq;

public static class Day6 {
    public static string Part1( string input ) {

        var name = "";
        var columns = MakeColumns( input );

        foreach ( Dictionary<char, int> column in columns ) {
            name += column.Aggregate( ( l, r ) => l.Value > r.Value ? l : r ).Key;
        }

        return name;
    }

    public static string Part2( string input ) {
        var name = "";
        var columns = MakeColumns( input );

        foreach ( Dictionary<char, int> column in columns ) {
            name += column.Aggregate( ( l, r ) => l.Value < r.Value ? l : r ).Key;
        }

        return name;
    }

    private static Dictionary<char, int>[] MakeColumns( string input ) {
        var columns = new Dictionary<char, int>[ 8 ];

        for ( var i = 0; i < 8; i++ ) {
            columns[ i ] = new Dictionary<char, int>();
        }

        foreach ( string line in input.ReadLines() ) {
            for ( var i = 0; i < 8; i++ ) {
                var character = line[ i ];

                if ( columns[ i ].ContainsKey( character ) ) {
                    columns[ i ][ character ]++;
                } else {
                    columns[ i ].Add( character, 1 );
                }
            }
        }

        return columns;
    }
}