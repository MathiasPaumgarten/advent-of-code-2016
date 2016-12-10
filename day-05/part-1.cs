using System.Security.Cryptography;
using System.Text;

public class Day5 {

    public static string Part1( string input ) {

        string password = "";

        using ( MD5 md5 = MD5.Create() ) {

            int count = 0;

            while ( password.Length < 8 ) {

                string hashable = input + count;
                string hash = GetMD5Hash( md5, hashable );

                if ( hash.Substring( 0, 5 ).Equals( "00000" ) ) {
                    password += hash[ 5 ];
                }

                count++;
            }
        }

        return password;
    }

    private static string GetMD5Hash( MD5 md5Hash, string input ) {
        byte[] data = md5Hash.ComputeHash( Encoding.UTF8.GetBytes( input ) );

        StringBuilder builder = new StringBuilder();

        for ( var i = 0; i < data.Length; i++ ) {
            builder.Append( data[ i ].ToString( "x2" ) );
        }

        return builder.ToString();
    }
}