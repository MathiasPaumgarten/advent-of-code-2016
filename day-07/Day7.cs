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

        var aba = @"([a-z])(?!\1)([a-z])\1";

        var regexA = new Regex( aba + @".*\[[a-z]*\2\1\2[a-z]*\]" );
        var regexB = new Regex( @"\[[a-z]*" + aba + @"[a-z]*\].*\2\1\2" );

        foreach ( string line in input.ReadLines() ) {
            if ( regexA.Match( line ).Success || regexB.Match( line ).Success ) count++;
        }

        return count.ToString();
    }
}