/// <summary>
/// Special Object containt an int array.
/// This was required to use decode json.
/// json requires an object to decode to.
/// An int[] is a primitive type and not object, this class however is an object.
/// </summary>
public class IntArray
{
    public int[] intList;
}