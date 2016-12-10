using System.IO;
using System.Collections;
using System.Numerics;

public static class Day2 {

    private static int[,] grid = new int[ 3, 3 ] {
        { 1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 9 }
    };

    private static char[,] diamondGrid = new char[ 5, 5 ] {
        { '0', '0', '1', '0', '0' },
        { '0', '2', '3', '4', '0' },
        { '5', '6', '7', '8', '9' },
        { '0', 'A', 'B', 'C', '0' },
        { '0', '0', 'D', '0', '0' }
    };

    public static string Part1( string input ) {

        string result = "";

        foreach ( string line in input.ReadLines() ) {

            var position = new Vector2( 1, 1 );

            foreach ( char character in line ) {
                switch ( character ) {
                    case 'U': position.Y = Clamp( (int) position.Y - 1, 0, 2 ); break;
                    case 'D': position.Y = Clamp( (int) position.Y + 1, 0, 2 ); break;
                    case 'L': position.X = Clamp( (int) position.X - 1, 0, 2 ); break;
                    case 'R': position.X = Clamp( (int) position.X + 1, 0, 2 ); break;
                }
            }

            result += grid.Get( position ).ToString();
        }

        return result;
    }

    public static string Part2( string input ) {

        string result = "";

        foreach ( string line in input.ReadLines() ) {

            var position = new Vector2( 2, 2 );

            foreach ( char character in line ) {
                switch ( character ) {
                    case 'U': MoveIfSave( ref position, 0, -1 ); break;
                    case 'D': MoveIfSave( ref position, 0, 1 ); break;
                    case 'L': MoveIfSave( ref position, -1, 0 ); break;
                    case 'R': MoveIfSave( ref position, 1, 0 ); break;
                }
            }

            result += diamondGrid.Get( position );

        }

        return result;
    }

    internal static IEnumerable ReadLines( this string value ) {
        string line;

        using ( var reader = new StringReader( value ) ) {
            while( ( line = reader.ReadLine() ) != null ) {
                yield return line;
            }
        }
    }

    internal static T Get<T>( this T[,] array, Vector2 position ) {
        return array[ (int) position.Y, (int) position.X ];
    }

    private static void MoveIfSave( ref Vector2 position, int x, int y ) {
        position.X += x;
        if ( ! ValidMove( ref position ) ) position.X -= x;

        position.Y += y;
        if ( ! ValidMove( ref position ) ) position.Y -= y;
    }

    private static bool ValidMove( ref Vector2 position ) {
        if ( ! InBetween( position.X, 5 ) || ! InBetween( position.Y, 5 ) ) return false;
        if ( diamondGrid.Get( position ) == '0' ) return false;

        return true;
    }

    private static bool InBetween( float number, int length ) {
        return ( number >= 0 && number < length );
    }

    private static int Clamp ( int value, int min, int max ) {
        return ( value < min ) ? min : ( value > max ) ? max : value;
    }

}