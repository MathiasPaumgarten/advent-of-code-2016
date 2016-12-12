using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class Day7 {

    public static string Part1( string input ) {

        var count = 0;

        var regex = new Regex( @"([a-z])(?!\1)([a-z])\2\1" );
        var negativeRegex = new Regex( @"\[[a-z]*([a-z])(?!\1)([a-z])\2\1[a-z]*\]" );

        foreach ( string line in input.ReadLines() ) {

            if ( regex.Match( line ).Success && ! negativeRegex.Match( line ).Success ) {
                count++;
            }
        }

        return count.ToString();
    }

    public static string Part2( string input ) {

        var count = 0;

        foreach ( string line in input.ReadLines() ) {

            var inHypernet = line[ 0 ] == '[';
            var aba = new Dictionary<string, bool>();
            var bab = new Dictionary<string, bool>();

            for ( int i = 1, length = line.Length - 1; i < length; i++ ) {

                var character = line[ i ];

                if ( character == '[' ) {
                    inHypernet = true;
                    continue;
                }

                if ( character == ']' ) {
                    inHypernet = false;
                    continue;
                }

                var previousCharacter = line[ i - 1 ];
                var nextCharacter = line[ i + 1 ];

                if ( character != nextCharacter && nextCharacter == previousCharacter ) {
                    var combo = previousCharacter.ToString() + character + nextCharacter;
                    var inverse = character.ToString() + previousCharacter + character;

                    var tester = inHypernet ? aba : bab;

                    if ( tester.ContainsKey( inverse ) ) {
                        count++;
                        break;
                    }

                    var storage = inHypernet ? bab : aba;

                    if ( ! storage.ContainsKey( combo ) ) storage.Add( combo, true );
                }
            }

        }

        return count.ToString();
    }
}
