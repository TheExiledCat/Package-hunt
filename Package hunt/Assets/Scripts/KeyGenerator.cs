using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGenerator
{
   
    public string GenerateKey(string format)//creates a code in provided format, example format: (XXX###) would be letter*3, number*3
    {
        char empty = ' ';
        string emptyFill = new string(empty, format.Length);
        char[] code = emptyFill.ToCharArray();
        int r = 2;
        
        for(int i = 0; i < code.Length; i++)
        {
            if (char.IsLetter(format[i]))
            {
                code[i] = (char)('A' + Random.Range(0, 26));
            }
            else
            {
                code[i] = Mathf.FloorToInt(Random.Range(0, 10)).ToString()[0];
            }
        }
        string key = new string(code);
        Debug.Log(key);

        return key;
        
    }
}
