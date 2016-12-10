using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Day4 {

    public static string Part1( string input ) {

        var sum = 0;

        foreach ( RoomData line in EachValidRoom( input ) ) {
            sum += line.SectorID;
        }

        return sum.ToString();
    }

    public static string Part2( string input ) {

        foreach ( RoomData line in EachValidRoom( input ) ) {

            string realName = "";

            foreach ( char character in line.Name ) {
                if ( character == '-' && IsOdd( line.SectorID ) ) realName += ' ';
                else if ( character == '-' ) realName += '-';
                else {
                    realName += Convert.ToChar(
                        ( ( Convert.ToInt32( character ) - 97 + line.SectorID ) % 26 ) + 97
                    );
                }
            }

           if ( realName.Contains( "north" ) ) {
               return line.SectorID.ToString();
           }
        }

        return "";
    }

    private static IEnumerable<RoomData> EachValidRoom( string input ) {
        var pattern = @"([a-z\-]+)-(\d{3})\[([a-z]{5})\]";

        foreach ( string line in input.ReadLines() ) {

            var regex = new Regex( pattern );
            var groups = regex.Match( line ).Groups;

            var name = groups[ 1 ].Value;
            var sectorID = groups[ 2 ].Value;
            var checksum = groups[ 3 ].Value;

            if ( IsValidRoom( name, checksum ) ) {
                yield return new RoomData( name, Int32.Parse( sectorID ), checksum );
            }
        }
    }

    private static bool IsOdd( int value ) {
        return value % 2 == 0;
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

    private class RoomData {
        public string Name { get; }
        public int SectorID { get; }
        public string CheckSum { get; }

        public RoomData( string name, int sectorID, string checksum ) {
            Name = name;
            SectorID = sectorID;
            CheckSum = checksum;
        }
    }
}
