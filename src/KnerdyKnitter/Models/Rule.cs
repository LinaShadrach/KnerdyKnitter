using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnerdyKnitter.Models
{
    public static class Rule
    {
        public static string[] BaseCombos { get; set; }
        public static string[][] AllRules { get; set; }
        public static int Count { get; set; }
        public static int Power { get; set; }
        public static void MakeRules()
        {
            BaseCombos = new string[8];
            BaseCombos[0] = "111";
            BaseCombos[1] = "110";
            BaseCombos[2] = "101";
            BaseCombos[3] = "100";
            BaseCombos[4] = "011";
            BaseCombos[5] = "010";
            BaseCombos[6] = "001";
            BaseCombos[7] = "000";

            AllRules = new string[256][];
            Power = 128;
            GetAllRules();
        }

        public static string[] GetRule(string[] rule, int count, int power)
        {
            if (power == 0)
            {
                return rule;
            }
            else
            {
                int index = Array.IndexOf(rule, null);
                if ((count - power) >= 0)
                {
                    rule[index] = "1";
                    count = count - power;
                }
                else
                {
                    rule[index] = "0";
                }
                if (power == 1)
                {
                    power = 0;
                }
                power = power / 2;
                return GetRule(rule, count, power);
            }
        }

        public static void GetAllRules()
        {
            int count;
            int power = 128;
            for (var i = 0; i < 256; i++)
            {
                count = i;
                string[] rule = new string[8];
                rule = GetRule(rule, count, power);
                AllRules[i] = rule;
            }
        }
    }
}
