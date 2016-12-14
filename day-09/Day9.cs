using System;
using System.Linq;
using System.Text;

public static class Day9 {

    public static string Part1( string input ) {

        var builder = new StringBuilder();

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

                string useLetters = input.Substring( i + 1, amount );
                string createString = String.Concat( Enumerable.Repeat( useLetters, Int32.Parse( repetition ) ) );

                builder.Append( createString );

                i += amount;
            }

            else builder.Append( character );

        }

        return builder.ToString().Length.ToString();
    }
}