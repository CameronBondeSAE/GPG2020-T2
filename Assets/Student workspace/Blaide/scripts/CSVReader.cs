
/*
	CSVReader by Dock. (24/8/11)
	http://starfruitgames.com
 
	usage: 
	CSVReader.SplitCsvGrid(textString)
 
	returns a 2D string array. 
 
	Drag onto a gameobject for a demo of CSV parsing.
*/

using System;
using UnityEngine;
using System.Collections;
using System.Linq; 
 
public class CSVReader : MonoBehaviour 
{
	public TextAsset csvFile;
	public string[] naughtyWords;
	public void Start()
	{
		string[,] grid = SplitCsvGrid(csvFile.text);
		Debug.Log("size = " + (1+ grid.GetUpperBound(0)) + "," + (1 + grid.GetUpperBound(1))); 
 
		DebugOutputGrid(grid);
		
		naughtyWords = To1DArray(grid);
		naughtyWords[naughtyWords.Length -1] = "Zexual";
		
		Array.Sort(naughtyWords, (x, y) => y.Length.CompareTo(x.Length));
	}
	


	static string[] To1DArray(string[,] input)
	{
		// Step 1: get total size of 2D array, and allocate 1D array.
		int size = (input.Length/2);
		string[] result = new string[size];

		// Step 2: copy 2D array elements into a 1D array.
		int write = 0;
		for (int i = 0; i <= input.GetUpperBound(0); i++)
		{
			for (int z = 0; z <= input.GetUpperBound(1); z += 2)
			{
				result[write++] = input[i, z];
			}
		}
		// Step 3: return the new array.
		return result;
	}
	
	// outputs the content of a 2D array, useful for checking the importer
	static public void DebugOutputGrid(string[,] grid)
	{
		string textOutput = ""; 
		for (int y = 0; y < grid.GetUpperBound(1); y++) {	
			for (int x = 0; x < grid.GetUpperBound(0); x++) {
 
				textOutput += grid[x,y]; 
				textOutput += "|"; 
			}
			textOutput += "\n"; 
		}
		Debug.Log(textOutput);
	}
 
	// splits a CSV file into a 2D string array
	static public string[,] SplitCsvGrid(string csvText)
	{
		string[] lines = csvText.Split("\n"[0]); 
 
		// finds the max width of row
		int width = 0; 
		for (int i = 0; i < lines.Length; i++)
		{
			string[] row = SplitCsvLine( lines[i] ); 
			width = Mathf.Max(width, row.Length); 
		}
 
		// creates new 2D string grid to output to
		string[,] outputGrid = new string[width + 1, lines.Length + 1]; 
		for (int y = 0; y < lines.Length; y++)
		{
			string[] row = SplitCsvLine( lines[y] ); 
			for (int x = 0; x < row.Length; x++) 
			{
				outputGrid[x,y] = row[x]; 
 
				// This line was to replace "" with " in my output. 
				// Include or edit it as you wish.
				outputGrid[x,y] = outputGrid[x,y].Replace("\"\"", "\"");
			}
		}
 
		return outputGrid; 
	}
 
	// splits a CSV row 
	static public string[] SplitCsvLine(string line)
	{
		return (from System.Text.RegularExpressions.Match m in System.Text.RegularExpressions.Regex.Matches(line,
		@"(((?<x>(?=[,\r\n]+))|""(?<x>([^""]|"""")+)""|(?<x>[^,\r\n]+)),?)", 
		System.Text.RegularExpressions.RegexOptions.ExplicitCapture)
		select m.Groups[1].Value).ToArray();
	}
}