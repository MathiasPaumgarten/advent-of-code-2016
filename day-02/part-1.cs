using System.IO;
using System.Collections;
using System.Numerics;

public static class Day2 {

    public static int[,] grid = new int[ 3, 3 ] {
        { 1, 2, 3 },
        { 4, 5, 6 },
        { 7, 8, 9 }
    };

    public static string Part1( string input ) {

        string result = "";

        foreach( string line in input.ReadLines() ) {

            var position = new Vector2( 1, 1 );

            foreach( char character in line ) {
                Move( ref position, character );
            }

            result += ( grid[ (int) position.Y, (int) position.X ] ).ToString();
        }

        return result;
    }

    public static string Part2( string input ) {

        string result = "";

        foreach( string line in input.ReadLines() ) {

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

    private static void Move( ref Vector2 position, char direction ) {
        switch ( direction ) {
            case 'U':
                position.Y = Clamp( (int) position.Y - 1, 0, 2 );
                break;
            case 'D':
                position.Y = Clamp( (int) position.Y + 1, 0, 2 );
                break;
            case 'L':
                position.X = Clamp( (int) position.X - 1, 0, 2 );
                break;
            case 'R':
                position.X = Clamp( (int) position.X + 1, 0, 2 );
                break;
        }
    }

    private static int Clamp ( int value, int min, int max ) {
        return ( value < min ) ? min : ( value > max ) ? max : value;
    }

}