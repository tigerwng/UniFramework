# SimpleJson Usage

## Sample
This is the JSON string which will be used in this example:

```json
{
    "version": "1.0",
    "data": {
        "sampleArray": [
            "string value",
            5,
            {
                "name": "sub object"
            }
        ]
    }
}
```

```c#
var N = JSON.Parse(the_JSON_string);
var versionString = N["version"].Value;        // versionString will be a string containing "1.0"
var versionNumber = N["version"].AsFloat;      // versionNumber will be a float containing 1.0
var name = N["data"]["sampleArray"][2]["name"];// name will be a string containing "sub object"
 
//C#
string val = N["data"]["sampleArray"][0];      // val contains "string value"
 
//UnityScript
var val : String = N["data"]["sampleArray"][0];// val contains "string value"
 
var i = N["data"]["sampleArray"][1].AsInt;     // i will be an integer containing 5
N["data"]["sampleArray"][1].AsInt = i+6;       // the second value in sampleArray will contain "11"
 
N["additional"]["second"]["name"] = "FooBar";  // this will create a new object named "additional" in this object create another
                                               //object "second" in this object add a string variable "name"
 
var mCount = N["countries"]["germany"]["moronCount"].AsInt; // this will return 0 and create all the required objects and
                                                            // initialize "moronCount" with 0.
 
if (N["wrong"] != null)                        // this won't execute the if-statement since "wrong" doesn't exist
{}
if (N["wrong"].AsInt == 0)                     // this will execute the if-statement and in addition add the "wrong" value.
{}
 
N["data"]["sampleArray"][-1] = "Test";         // this will add another string to the end of the array
N["data"]["sampleArray"][-1]["name"] = "FooBar"; // this will add another object to the end of the array which contains a string named "name"
 
N["data"] = "erased";                          // this will replace the object stored in data with the string "erased"
```

## Reference
1. [SimpleJSON From Unify Community Wiki](https://wiki.unity3d.com/index.php/SimpleJSON#UnityScript_.28Unity.27s_Javascript.29)