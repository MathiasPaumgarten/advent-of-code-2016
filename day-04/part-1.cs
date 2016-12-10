using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Day4 {

    public static string Part1( string input ) {

        var sum = 0;
        var pattern = @"([a-z\-]+)-(\d{3})\[([a-z]{5})\]";

        foreach ( string line in input.ReadLines() ) {

            var regex = new Regex( pattern );
            var groups = regex.Match( line ).Groups;

            var name = groups[ 1 ].Value;
            var sectorID = groups[ 2 ].Value;
            var checksum = groups[ 3 ].Value;

            if ( IsValidRoom( name, checksum ) ) sum += Int32.Parse( sectorID );
        }

        return sum.ToString();
    }

    private static bool IsValidRoom( string name, string checksum ) {

        var dictionary = new Dictionary<char, int>();
        var list = new List<KeyValuePair<char, int>>();

        foreach ( char character in name ) {
            if ( character == '-' ) continue;

            if ( dictionary.ContainsKey( character ) ) dictionary[ character ]++;
            else dictionary[ character ] = 1;
        }

        foreach ( KeyValuePair<char, int> pair in dictionary ) {
            list.Add( pair );
        }

        list.Sort( ( a, b ) => {
            if ( a.Value == b.Value ) return a.Key.CompareTo( b.Key );
            else return b.Value.CompareTo( a.Value );
        } );

        for ( var i = 0; i < 5; i++ ) {
            if ( list[ i ].Key != checksum[ i ] ) {
                return false;
            }
        }

        return true;;
    }
}