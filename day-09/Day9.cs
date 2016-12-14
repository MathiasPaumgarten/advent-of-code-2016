using System;

public static class Day9 {

    public static string Part1( string input ) {
        return Parse( input ).ToString();
    }

    public static string Part2( string input ) {
        return Parse( input, true ).ToString();
    }

    private static long Parse( string input, bool recursive = false ) {
        long total = 0;

        for ( var i = 0; i < input.Length; i++ ) {

            var character = input[ i ];

            if ( character == ' ' ) continue;

            else if ( character == '(' ) {

                character = input[ ++i ];

                string amountOfLetters = "";
                string repetition = "";

                while ( character != 'x' ) {
                    amountOfLetters += character;
                    character = input[ ++i ];
                }

                character = input[ ++i ];

                while ( character != ')' ) {
                    repetition += character;
                    character = input[ ++i ];
                }

                int amount = Int32.Parse( amountOfLetters );
                string substring = input.Substring( i + 1, amount );

                long subTotal = recursive ? Parse( substring, true ) : substring.Length;

                total += subTotal * Int32.Parse( repetition );

                i += amount;
            }

            else total++;
        }

        return total;
    }
}