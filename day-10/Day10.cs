using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Day10 {

    public static Dictionary<int, Bot> bots = new Dictionary<int, Bot>();
    public static Dictionary<int, Output> outputs = new Dictionary<int, Output>();

    public static string Part1( string input ) {

        var instructionRegex = new Regex( @"bot (\d+) gives low to (\w+) (\d+) and high to (\w+) (\d+)" );
        var valueRegex = new Regex( @"value (\d+) goes to bot (\d+)" );

        var values = new List<KeyValuePair<int, int>>();

        foreach ( string line in input.ReadLines() ) {
            var valuePattern = valueRegex.Match( line );
            var instructionPattern = instructionRegex.Match( line );

            if ( valuePattern.Success ) {

                int name = Int32.Parse( valuePattern.Groups[ 2 ].Value );
                int value = Int32.Parse( valuePattern.Groups[ 1 ].Value );

                values.Add( new KeyValuePair<int, int>( name, value ) );

            } else if ( instructionPattern.Success ) {

                int name = Int32.Parse( instructionPattern.Groups[ 1 ].Value );
                string lowType = instructionPattern.Groups[ 2 ].Value;
                int low = Int32.Parse( instructionPattern.Groups[ 3 ].Value );
                string highType = instructionPattern.Groups[ 4 ].Value;
                int high = Int32.Parse( instructionPattern.Groups[ 5 ].Value );

                Bot bot = GetBot( name );

                bot.LowConnection = GetConnector( lowType, low );
                bot.HighConnection = GetConnector( highType, high );
            }
        }

        foreach ( var pair in values ) {
            var result = GetBot( pair.Key ).SetValue( pair.Value );

            if ( result ) break;
        }

        return "";
    }

    private static Bot GetBot( int name ) {
        if ( ! bots.ContainsKey( name ) ) bots.Add( name, new Bot( name ) );

        return bots[ name ];
    }

    private static Output GetOutput( int name ) {
        if ( ! outputs.ContainsKey( name ) ) outputs.Add( name, new Output( name ) );

        return outputs[ name ];
    }

    private static IConnector GetConnector( string type, int name ) {
        return type.Equals( "output" ) ? (IConnector) GetOutput( name ) : GetBot( name );
    }

    public class Bot : IConnector {

        private int Name;
        private SortedSet<int> Values = new SortedSet<int>();

        public IConnector LowConnection { get; set; }
        public IConnector HighConnection { get; set; }

        public Bot( int name ) {
            Name = name;
        }

        public bool SetValue( int value ) {
            Values.Add( value );

            if ( Values.Count == 2 ) {

                if ( Values.Min == 17 && Values.Max == 61 ) {
                    Console.WriteLine( Name );
                    return true;
                }

                return LowConnection.SetValue( Values.Min ) || HighConnection.SetValue( Values.Max );
            }

            return false;
        }
    }

    public class Output : IConnector {

        public List<int> Value = new List<int>();

        public Output( int name ) {}

        public bool SetValue( int value ) {
            Value.Add( value );
            return false;
        }
    }

    public interface IConnector {
        bool SetValue( int value );
    }

}