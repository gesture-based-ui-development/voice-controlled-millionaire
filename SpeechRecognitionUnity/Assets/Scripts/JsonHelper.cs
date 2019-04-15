using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

/*
JsonHelper contains functions to help with  parsing and formatting our JSON file of questions.
*/
public static class JsonHelper
{
    /*
    FromJson takes the Json file and returns a Wrapper array of items.
     */
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    /*
    ToJson returns a string version of a Json file. 
    */
    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    /*
    ToJson returns a string version of a Json file. 
    */
    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}