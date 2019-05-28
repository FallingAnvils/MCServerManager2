using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Linq;

namespace MCServerManager2
{
    internal class MiscTools
    {
        public static string DirWithoutFile(string file)
        {
            return file.Substring(0, file.LastIndexOf("/")) + "/";
        }

        public static string CommonStartsWith(IEnumerable<string> strings)
        {
            return new string(strings.First().Substring(0, strings.Min(s => s.Length)).TakeWhile((c, i) => strings.All(s => s[i] == c)).ToArray());
        }

        public static void SpawnBackgroundWorker(Action work, Action continueWith)
        {
            using (var worker = new BackgroundWorker())
            {
                worker.DoWork += (s, e) => work();
                worker.RunWorkerCompleted += (s, e) => continueWith();
                worker.RunWorkerAsync();
            }
        }

        public static void SpawnBackgroundWorker(Action work)
        {
            using (var worker = new BackgroundWorker())
            {
                worker.DoWork += (s, e) => work();
                worker.RunWorkerAsync();
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        /// <summary>
        /// Sets the parent of something, unless we're not on windows
        /// </summary>
        /// <param name="hWndChild"></param>
        /// <param name="hWndNewParent"></param>
        public static bool SetParentCrossCompatible(IntPtr hWndChild, IntPtr hWndNewParent)
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetParent(hWndChild, hWndNewParent);
                return true;
            }
            return false;
        }
    }

    internal static class StringExtensions
    {
        public static string Quotate(this string str)
        {
            return '"' + str + '"';
        }
        public static string BetterPathJoinSlash(this string str, string otherStr)
        {           
            if (str.EndsWith("/") && otherStr.StartsWith("/")) return str.TrimEnd('/') + '/' + otherStr.TrimStart('/');
            if (!str.EndsWith("/") && otherStr.StartsWith("/")) return str + '/' + otherStr.TrimStart('/');
            if (str.EndsWith("/") && !otherStr.StartsWith("/")) return str + otherStr;
            if (!str.EndsWith("/") && !otherStr.StartsWith("/")) return str + '/' + otherStr;
            throw new FormatException($"I have no idea what just happened, or you just did something stupid. Input strings: \"{str}\", \"{otherStr}\"");
        }
        public static string CombineCommand(this string str, string otherStr)
        {
            return str + ';' + otherStr;
        }
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }

    internal static class ListExtensions
    {
        public static List<T> RemoveLastElement<T>(this List<T> list)
        {
            list.RemoveAt(list.Count - 1);
            return list;
        }
    }
    internal static class ArrayExtensions
    {
        public static T[] RemoveLastElement<T>(this T[] arr)
        {
            Array.Resize(ref arr, arr.Length - 1);
            return arr;
        }
    }
}
