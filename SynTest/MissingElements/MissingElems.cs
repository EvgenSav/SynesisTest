using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynTest.MissingElements {
    public class MissingElems {
        public static IEnumerable<int> MissingElements(params int[] arr) {
            HashSet<int> input = new HashSet<int>(arr);
            HashSet<int> needed = new HashSet<int>();
            if (arr.Length > 1) {
                for (int i = arr[0]; i < arr[arr.Length - 1]; i++) {
                    needed.Add(i);
                }
            }
            return needed.Except(input);
        }
    }
}
