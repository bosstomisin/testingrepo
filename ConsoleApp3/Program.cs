

//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Threading.Tasks;
//using HtmlAgilityPack;

//class UnicodeGrid
//{
//    static async Task Main(string[] args)
//    {
//        string url = "https://docs.google.com/document/d/e/2PACX-1vSvM5gDlNvt7npYHhp_XfsJvuntUhq184By5xO_pA4b_gCWeXb6dM6ZxwN8rE6S4ghUsCj2VKR21oEP/pub";
//       // string url = "https://docs.google.com/document/d/e/2PACX-1vTMOmshQe8YvaRXi6gEPKKlsC6UpFJSMAk4mQjLm_u1gmHdVVTaeh7nBNFBRlui0sTZ-snGwZM4DBCT/pub";
//        await PrintUnicodeGrid(url);
//    }

//    static async Task PrintUnicodeGrid(string docUrl)
//    {
//        //Fetch the published Google Doc HTML
//        using HttpClient client = new HttpClient();
//        client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
//        string html = await client.GetStringAsync(docUrl);

//        //Parse HTML
//        var htmlDoc = new HtmlDocument();
//        htmlDoc.LoadHtml(html);

//        //Find the table
//       var table = htmlDoc.DocumentNode.SelectSingleNode("//table");
//        if (table == null)
//            throw new Exception("No table found in the document.");

//        var rows = table.SelectNodes(".//tr");
//        if (rows == null || rows.Count == 0)
//            throw new Exception("No rows found in table.");

//        //Parse header row to find column indices
//       var headerCells = rows[0].SelectNodes(".//th|.//td");
//        var headers = new List<string>();
//        foreach (var cell in headerCells)
//            headers.Add(cell.InnerText.Trim());

//        int xIdx = headers.IndexOf("x-coordinate");
//        int yIdx = headers.IndexOf("y-coordinate");
//        int charIdx = headers.IndexOf("Character");

//        if (xIdx == -1 || yIdx == -1 || charIdx == -1)
//            throw new Exception("Required columns (x, y, Character) not found in header.");

//        //Parse data rows into a dictionary
//        var charMap = new Dictionary<(int x, int y), string>();

//        for (int i = 1; i < rows.Count; i++)
//        {
//            var cells = rows[i].SelectNodes(".//td|.//th");
//            if (cells == null || cells.Count < 3) continue;

//            if (!int.TryParse(cells[xIdx].InnerText.Trim(), out int x)) continue;
//            if (!int.TryParse(cells[yIdx].InnerText.Trim(), out int y)) continue;
//            string ch = cells[charIdx].InnerText.Trim();

//            charMap[(x, y)] = ch;
//        }

//        if (charMap.Count == 0)
//        {
//            Console.WriteLine("No data found.");
//            return;
//        }

//        //Determine grid dimensions
//        int maxX = 0, maxY = 0;
//        foreach (var key in charMap.Keys)
//        {
//            if (key.x > maxX) maxX = key.x;
//            if (key.y > maxY) maxY = key.y;
//        }
//        //for (int y = maxY; y >= 0; y--)
//        //{
//        //    for (int x = 0; x <= maxX; x++)
//        //    {
//        //        Console.Write(charMap.TryGetValue((x, y), out string? ch) ? ch : "");
//        //    }
//        //    //Console.WriteLine();

//        //}
//        
//    }

//}



using HtmlAgilityPack;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
public class Program
{

    public static async Task Main(string[] args)
    {
        String s1 = "Geeks";
        concat1(s1); // s1 is not changed 
        Console.WriteLine("Using String Class: " + s1);

        int[] ints = new int[] { 1, 2, 0, 1, 0, 1, 0, 3, 0, 1 };
       // Console.WriteLine(solve());
      //  Console.WriteLine(MoveZeroes(ints));
        //Console.OutputEncoding = Encoding.UTF8;
        int[] a = null;
        //int[] b = [2];
       // ReverseWords();
        //int[] a = [121, 144, 19, 161, 19, 144, 19, 11];
        int[] b = [121, 14641, 20736, 361, 25921, 361, 20736, 361];
       // Console.WriteLine(DuplicateEncode("abc"));

        //Console.WriteLine(CreateAnagram("GNNHDSXSH", "VVNRVULVB"));
        //8
        //string url = "https://docs.google.com/document/d/e/2PACX-1vSvM5gDlNvt7npYHhp_XfsJvuntUhq184By5xO_pA4b_gCWeXb6dM6ZxwN8rE6S4ghUsCj2VKR21oEP/pub";
        //await PrintGoogleDocGrid(url);
    }

    public static void concat1(String s1)
    {

        // taking a string which 
        // is to be Concatenate 
        String st = "forGeeks";

        // using String.Concat method 
        // you can also replace it with 
        // s1 = s1 + "forgeeks"; 
        s1 = string.Concat(s1, st);
    }
    public static string solve(string s = "abbaa")
    {
            string t = string.Concat(s.Reverse());
                 if (t == s)
                    return "OK";
            //for (int i = 0; i < s.Length; i++)
            //{
            //    var remove = s.Remove(i, 1);
            //    var y = string.Concat(remove.Reverse());
            //     if (y == remove)
            //        return "remove one";
            //}

        //if(u)
        //  return "remove one";

        //return "not possible";
        var f = s.Select((x, i) => s.Remove(i, 1)).Reverse();
        var ty = s.Where((x, i) => s.Remove(i, 1).SequenceEqual(s.Remove(i, 1).Reverse())).Any() ? "remove one" : "not possible";
        return ty;
    }
    
    public static int[] MoveZeroes(int[] arr )
    {
        var t = arr.Where(x => x == 0).ToArray();
        var u = arr.Where(x => x != 0).ToArray();
       var y = t.Concat(u);
        List<int> list = new List<int>();
        list.AddRange(u);
        list.AddRange(t);

        var list2 =arr.ToList();
        return list.ToArray();
        // TODO: Program me
    }
    public static string Counter(string word)
    {
        if (string.IsNullOrEmpty(word))
            return null;
        var f = word.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

        foreach ( var letter in word)
        {
            if (f[letter] == 1)
                return letter.ToString();
        }
        return word.GroupBy(x => x).Select(x => x).Where(x => x.Count() == 1).FirstOrDefault().Key.ToString();
    }

    public static string Correct(string dateString)
    {
        var date = Convert.ToDateTime( Convert.ToDouble(dateString), new CultureInfo("en-US"));
        return date.ToString();
    }
    public static string Accum(string s)
    {

        StringBuilder sb = new StringBuilder();
        //for (int i = 0; i < s.Length; i++) {
        //    string temp = s[i].ToString().ToUpper();
        //    sb.Append(temp);
        //    sb.Append(char.ToLower( s[i]), i);
        //    sb.Append("-");
        //}
        // return sb.ToString().Trim('-'); // your code
        var red = String.Join("-", s.Select((c, i) => new string( char.ToLower(c), i)));
        return red;











            //(c, i) => Char.ToUpper(c) + new String(Char.ToLower(c), i)));

    }
    public static string ReverseWords(string str = "")
    {
        str = "  This is an example  ";
        if(string.IsNullOrWhiteSpace(str)) return str;
        var d = str.Split(" ");
        string result = "";
        int startSpace = 0;
        int endSpace = 0;
        var y = string.Join(" ", d.Select(x => new string(x.Reverse().ToArray())));
        var z = string.Join(" ", d.Select(x => string.Concat(x.Reverse())));


        foreach (var i in str)
        {
            if (i == ' ')
                startSpace++;
            else
                break;
        }
        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (str[i] == ' ')
                endSpace++;
            else
                break;
        }
        for (var i = 0; i < d.Length; i++)
        {
            var j = d[i].Reverse();
            var r = string.Join("", j);
            result += " " + r;
        }
         result = result.Trim();

        if (startSpace > 0)
        {
            result = new string(' ', startSpace) + result;
           // return result;

        }
        if (endSpace > 0)
        {
            result += new string(' ', endSpace);
           // return result;

        }
        Console.Write(result.TrimStart());
        return result;
    }
    //Write your code here
    
    public static long MaxRot(long n)
    {
        long max = n;
        string numAsString = n.ToString();
        for (int i = 0; i < numAsString.Length; i++)
        {
            char temp = numAsString[i] ;

            numAsString = numAsString.Remove(i, 1);
            numAsString += temp;
            if(Convert.ToInt64(numAsString) > max)
                max = Convert.ToInt64(numAsString);
        }
        return max; // your code
    }

        public static bool IsAnagram(string a, string b)
    {
        // your code goes here
        a = string.Concat(a.Order());
        b = string.Concat(b.Order());
        bool result = a.Equals(b);
          return result;
    }
    public static int[] MissinNumber(int[] myList)
    {
        int first = myList.Min();
        int last = myList.Max();

        // Create complete range and find missing numbers
        List<int> completeRange = Enumerable.Range(first, last - first + 1).ToList();
        List<int> missingNumbers = completeRange.Except(myList).ToList();

        Console.WriteLine("Missing Numbers:");
        foreach (int missing in missingNumbers)
        {
            Console.WriteLine(missing);
        }
        return missingNumbers.ToArray();
    }
    public static int CreateAnagram(string s, string t)
    {

        //coding and coding..
        var x = s.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        var y = t.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        int count = 0;
        foreach (var item in x)
        {
            if (y.ContainsKey(item.Key))
            {
                int county = y[item.Key];
                int countx = x[item.Key];
                if (countx > county)
                    count += countx - county;
            }
            else
                count += x[item.Key];
        }
        return count;
    }
    public static long Fibonacci(int max)
    {
        if (max <= 2)
            return 0;
        int a = 0;
        int b = 1;
        int temp = 0;
        int sum = 0;
        string testing = "kata";
        var result = testing.ToCharArray();
        Array.Reverse(result);

        Console.WriteLine(result);
        for (int i = 2; i < max; i++)
        {
            temp = a + b;
            if (temp % 2 == 0)
                sum = sum + temp;
            a = b;
            b = temp;
        }
        return sum;
    }
    public static int Fib(int n)
    {
        // your code here!
        //if (n == 0) 
        //    return 0;
        //if (n == 1)
        //    return 1;

        //return Fib(n - 1) + Fib(n - 2);
        if (n == 0)
            return 0;
        if (n == 1)
            return 1;
        int first = 0;
        int second = 1;
        int temp = 0;
        for (int i = 2; i <= n; i++)
        {
            temp = first + second;
            first = second;
            second = temp;
        }
        return temp;
    }
    public static int DuplicateCount(string str)
    {
        return str.ToLower().GroupBy(str => str).Where(x => x.Count() > 1).ToList().Count;
    }
    public static string DuplicateEncode(string word)
    {
        StringBuilder sb = new ();
        var y = word.GroupBy(x => x).Where(t => t.Count() > 1).Select(x => x.Key).ToList();
    
        //foreach (var x in word)
        //{
        //    if (y.Contains(x))
        //    {
        //        sb.Append(")");
        //    }
        //    else
        //        sb.Append("(");
        //}
        var rev = string.Concat(word.Reverse());
        return rev;
    }
    public static string Occurence(string n)
    {
        var occur = n.GroupBy(x => x).Select(x => new { Count = x.Count(), Key = x.Key });
        foreach (var item in occur)
        {
            Console.WriteLine($"Key {item.Key}, Count {item.Count}");
        }
        return "";
    }
    public static int FindDeletedNumber(List<int> startingList, List<int> mixedList)
    {
        // Your code here
        int missen = 0;
        var list = mixedList.Except(startingList).FirstOrDefault();
        for (int i = 0; i < startingList.Count(); i++)
        {
            //if(!list.Contains(startingList[i]))
            //{
            //    missen = startingList[i];
            //    break;
            //}

        }
        return missen;
        var l = mixedList.Where(mixedList.Contains).ToList();
    }
    public static bool comp(int[] a, int[] b)
    {
        // your code
        if (a == null || b == null)
            return false;

        if (a.Length == 0 || b.Length == 0 || a == null || b == null)
            return false;
        //var t = b.Where(x => a.Contains((int)Math.Sqrt(x))).ToList();
        // var y = b.Contains(Math.Sqrt)
        //var y = b.Any(x => a.Contains((int)Math.Sqrt(x)));
        var c = a.Select(x => (int)Math.Pow(x, 2)).OrderByDescending(x=>x).ToList();
        var d = b.OrderByDescending(x=>x).ToList();
        bool l = c.SequenceEqual(d);

        //var i = ay.GroupBy(x => x).Select(x =>  new { count = x.Key});
        //foreach (var item in a)
        //{
        //    Console.WriteLine(item.k);
        //};
        return l;
        //return t.Count == b.Length ;
    }

    public static async Task PrintGoogleDocGrid(string url)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0");
        var rawHtml = await client.GetStringAsync(url);

        string rawText = HtmlToText(rawHtml);


        var points = ParseEntries(rawText);
        int maxX = 0;
        int maxY = 0;

        foreach (var point in points.Keys)
        {
            if (point.x > maxX) maxX = point.x;
            if (point.y > maxY) maxY = point.y;
        }
        for (int y = maxY; y >= 0; y--)
        {
            char[] row = new char[maxX + 1];
            Array.Fill(row, ' ');

            for (int x = 0; x <= maxX; x++)
            {
                if (points.TryGetValue((x, y), out char ch))
                {
                    row[x] = ch;
                }
            }
            Console.WriteLine(new string(row));
        }
    }

    private static string HtmlToText(string rawHtml)
    {
        rawHtml = Regex.Replace(rawHtml, @"(?is)<(script|style).*?>.*?</\1>", "");
        rawHtml = Regex.Replace(rawHtml, @"(?i)<br\s*/?>", "\n");
        rawHtml = Regex.Replace(rawHtml, @"(?i)</(p|div|tr|td|th|li|h[1-6])>", "\n");
        rawHtml = Regex.Replace(rawHtml, @"(?s)<[^>]+>", "");
        return WebUtility.HtmlDecode(rawHtml);
    }

    private static Dictionary<(int x, int y), char> ParseEntries(string text)
    {
        var lines = new List<string>();
        foreach (var line in text.Split('\n'))
        {
            string trimmed = line.Trim();
            if (!string.IsNullOrEmpty(trimmed))
            {
                lines.Add(trimmed);
            }
        }

        int startIndex = 0;

        for (int i = 0; i <= lines.Count - 3; i++)
        {
            if (lines[i].Equals("x-coordinate", StringComparison.OrdinalIgnoreCase) &&
                lines[i + 1].Equals("Character", StringComparison.OrdinalIgnoreCase) &&
                lines[i + 2].Equals("y-coordinate", StringComparison.OrdinalIgnoreCase))
            {
                startIndex = i + 3;
                break;
            }
        }

        var points = new Dictionary<(int x, int y), char>();
        bool foundAny = false;
        int iPtr = startIndex;

        while (iPtr + 2 < lines.Count)
        {
            string xStr = lines[iPtr];
            string charStr = lines[iPtr + 1];
            string yStr = lines[iPtr + 2];

            if (int.TryParse(xStr, out int x) &&
                int.TryParse(yStr, out int y) &&
                !string.IsNullOrEmpty(charStr))
            {
                points[(x, y)] = charStr[0];
                foundAny = true;
                iPtr += 3;
            }
            else
            {
                iPtr++;
            }
        }

        if (!foundAny)
        {
            throw new Exception("Could not find any valid grid entries in the document.");
        }

        return points;
    }
}