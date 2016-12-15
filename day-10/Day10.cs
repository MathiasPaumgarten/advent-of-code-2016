using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Day10 {

    public static string Part1( string input ) {

        var instructionRegex = new Regex( @"bot (\d+) gives low to bot (\d+) and high to bot (\d+)" );
        var valueRegex = new Regex( @"value (\d+) goes to bot (\d+)" );

        var bots = new Dictionary<int, Bot>();

        foreach ( string line in input.ReadLines() ) {
            var valuePattern = valueRegex.Match( line );
            var instructionPattern = instructionRegex.Match( line );

            if ( valuePattern.Success ) {

                int name = Int32.Parse( valuePattern.Groups[ 1 ].Value );
                int value = Int32.Parse( valuePattern.Groups[ 0 ].Value );

                Bot bot = GetBot( ref bots, name );

            }
        }

        return "";

    }

    private static Bot GetBot( ref Dictionary<int, Bot> bots, int name ) {
        if ( ! bots.ContainsKey( name ) ) bots.Add( name, new Bot() );

        return bots[ name ];
    }

    public class Bot {
        public Bot() {}
    }

}