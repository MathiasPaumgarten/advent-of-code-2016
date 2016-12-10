using System.Collections;
using System.IO;

public static class Utils {
    public static IEnumerable ReadLines( this string value ) {
        string line;

        using ( var reader = new StringReader( value ) ) {
            while( ( line = reader.ReadLine() ) != null ) {
                yield return line;
            }
        }
    }
}