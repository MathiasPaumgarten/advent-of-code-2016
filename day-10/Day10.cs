using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Day10 {

    private static int Part1Result;
    private static int Part2Result = 1;

    private static Dictionary<int, Bot> bots = new Dictionary<int, Bot>();
    private static Dictionary<int, Output> outputs = new Dictionary<int, Output>();
    private static List<Bot> processChain = new List<Bot>();

    public static string Part1( string input ) {
        Process( input );

        return Part1Result.ToString();
    }

    public static string Part2( string input ) {
        Process( input );

        return Part2Result.ToString();
    }

    private static void Process( string input ) {

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
            bots[ pair.Key ].SetValue( pair.Value );

            while ( processChain.Count > 0 ) {
                processChain.Shift().Process();
            }
        }
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

        public void SetValue( int value ) {
            Values.Add( value );

            if ( Values.Count == 2 ) {

                if ( Values.Min == 17 && Values.Max == 61 ) {
                    Part1Result = Name;
                }

                processChain.Add( this );
            }
        }

        public void Process() {
            LowConnection.SetValue( Values.Min );
            HighConnection.SetValue( Values.Max );

            Values.Clear();
        }
    }

    public class Output : IConnector {

        private int Name;
        private List<int> Value = new List<int>();

        public Output( int name ) {
            Name = name;
        }

        public void SetValue( int value ) {
            Value.Add( value );

            if ( Name == 0 || Name == 1 || Name == 2 ) {
                if ( Value.Count == 1 ) {
                    Part2Result *= value;
                }
            }
        }
    }

    public interface IConnector {
        void SetValue( int value );
    }
}