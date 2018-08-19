using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynTest.MyStrings {
    public static class MyString {
        public static string ReverseString(this string input) {
            string res = "";
            if (input.Length > 1) {
                for (int i = input.Length - 1; i >= 0; i--) {
                    res += input[i];
                }
            } else {
                if (input.Length == 0) {
                    res = "String is empty!";
                } else {
                    res = input;
                }
            }
            return res;
        }
        public static bool IsPalindrome(this string input) {
            return input == ReverseString(input);
        }
    }
}
