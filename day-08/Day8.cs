using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Day8 {

    private static readonly int WIDTH = 50;
    private static readonly int HEIGHT = 6;

    private static int[,] grid = new int[ WIDTH, HEIGHT ];

    public static string Part1( string input ) {

        grid.Initialize();

        var rectRegex = new Regex( @"rect (\d+)x(\d+)" );
        var columnRegex = new Regex( @"rotate column x=(\d+) by (\d+)" );
        var rowRegex = new Regex( @"rotate row y=(\d+) by (\d+)" );

        foreach ( string line in input.ReadLines() ) {

            var rectMatch = rectRegex.Match( line );
            var columnMatch = columnRegex.Match( line );
            var rowMatch = rowRegex.Match( line );

            if ( rectMatch.Success ) {
                Rect( Int32.Parse( rectMatch.Groups[ 1 ].Value ), Int32.Parse( rectMatch.Groups[ 2 ].Value ) );
            } else if ( columnMatch.Success ) {
                RotateColumn( Int32.Parse( columnMatch.Groups[ 1 ].Value ), Int32.Parse( columnMatch.Groups[ 2 ].Value ) );
            } else if ( rowMatch.Success ) {
                RotateRow( Int32.Parse( rowMatch.Groups[ 1 ].Value ), Int32.Parse( rowMatch.Groups[ 2 ].Value ) );
            } else {
                Console.WriteLine( line );
            }
        }

        return Aggregate().ToString();
    }

    public static string Part2( string input ) {

        Part1( input );

        for ( var y = 0; y < HEIGHT; y++ ) {

            var builder = new StringBuilder();

            for ( var x = 0; x < WIDTH; x++ ) {
                builder.Append( grid[ x, y ] == 1 ? "#" : " " );
            }

            Console.WriteLine( builder.ToString() );
        }

        return "";
    }

    private static int Aggregate() {
        var count = 0;

        foreach ( int number in grid ) count += number;

        return count;
    }

    private static void Rect( int width, int height ) {
        for ( var x = 0; x < width; x++ ) {
            for ( var y = 0; y < height; y++ ) {
                grid[ x, y ] = 1;
            }
        }
    }

    private static void RotateColumn( int column, int bits ) {
        var copy = new int[ HEIGHT ];

        for ( var i = 0; i < HEIGHT; i++ ) {
            copy[ i ] = grid[ column, i ];
        }

        for ( var i = 0; i < HEIGHT; i++ ) {
            grid[ column, ( i + bits ) % HEIGHT ] = copy[ i ];
        }
    }

    private static void RotateRow( int row, int bits ) {

        var copy = new int[ WIDTH ];

        for ( var i = 0; i < WIDTH; i++ ) {
            copy[ i ] = grid[ i, row ];
        }

        for ( var i = 0; i < WIDTH; i++ ) {
            grid[ ( i + bits ) % WIDTH, row ] = copy[ i ];
        }
    }
}