﻿using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_Algorithms;

public class TestUnit
{
    HashSet<Sometxt> hs = new HashSet<Sometxt>();
    string[] sm = new string[1000];

    public TestUnit()
    {
        for (int i = 0; i < this.sm.Length; i++)
        {
            string t = GetRandomString(5);
            this.sm[i] = t;
            hs.Add(new Sometxt() { text = t });
        }
    }

    [Benchmark(Description = "IsExistsInMassive")]
    public bool IsExistsInMassive()
    {
        string s = "text to find";
        for (int i = 0; i < this.sm.Length; i++)
        {
            if (this.sm[i] == s) return true;
        }
        return false;
    }
    [Benchmark(Description = "IsExistsInHashSet")]
    public bool IsExistsInHashSet()
    {
        string s = "text to find";
        var sv = new Sometxt() { text = s };
        return hs.Contains(sv);
    }
    string GetRandomString(int pwdLength)
    {
        string ch = "ABCDEFGHJKLMNOPQRSTUVWXYZ1234567890";
        var rndGen = new Random();
        char[] pwd = new char[pwdLength];
        for (int i = 0; i < pwd.Length; i++)
            pwd[i] = ch[rndGen.Next(ch.Length)];
        return new string(pwd);
    }
}
