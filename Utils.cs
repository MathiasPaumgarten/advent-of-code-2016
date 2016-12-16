using System.Collections;
using System.IO;
using System.Collections.Generic;

public static class Utils {
    public static IEnumerable ReadLines( this string value ) {
        string line;

        using ( var reader = new StringReader( value ) ) {
            while( ( line = reader.ReadLine() ) != null ) {
                yield return line;
            }
        }
    }

    public static T Shift<T>( this List<T> list ) {
        T temp = list[ 0 ];
        list.RemoveAt( 0 );
        return temp;
    }
}