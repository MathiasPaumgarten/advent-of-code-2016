using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System;

public class Day5 {

    public static string Part1( string input ) {

        string password = "";

        using ( MD5 md5 = MD5.Create() ) {

            foreach ( string hash in WhileValidHash( md5, input ) ) {
                password += hash[ 5 ];

                if ( password.Length == 8 ) break;
            }
        }

        return password;
    }


    public static string Part2( string input ) {
        char[] password = new char[ 8 ];

        using ( MD5 md5 = MD5.Create() ) {

            foreach ( string hash in WhileValidHash( md5, input ) ) {

                int position = 0;

                if ( Int32.TryParse( hash[ 5 ].ToString(), out position ) && position < 8 ) {
                    if ( password[ position ] == '\0' ) {
                        password[ position ] = hash[ 6 ];
                    }
                }

                if ( IsCompletePassword( ref password ) ) break;
            }

        }

        return new string( password );
    }

    private static IEnumerable WhileValidHash( MD5 md5, string input ) {
        var count = 0;

        while ( true ) {
            string hash = GetMD5Hash( md5, input + count );

            if ( hash.Substring( 0, 5 ).Equals( "00000" ) ) {
                yield return hash;
            }

            count++;
        }
    }

    private static string GetMD5Hash( MD5 md5Hash, string input ) {
        byte[] data = md5Hash.ComputeHash( Encoding.UTF8.GetBytes( input ) );

        StringBuilder builder = new StringBuilder();

        for ( var i = 0; i < data.Length; i++ ) {
            builder.Append( data[ i ].ToString( "x2" ) );
        }

        return builder.ToString();
    }

    private static bool IsCompletePassword( ref char[] array ) {
        for ( var i = 0; i < array.Length; i++ ) {
            if ( array[ i ] == '\0' ) return false;
        }

        return true;
    }
}