﻿using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace RaccoonDocumentation.Web.Services
{
	public static class DocumentationParser
	{
		static readonly Regex CodeFinder = new Regex(@"{CODE(.+)/}", RegexOptions.Compiled);

		public static string ParesDocumentation(this string content)
		{
			return CodeFinder.Replace(content, match => GenerateCodeStatemnt(match.Groups[1].Value.Trim()));
		}

		private static string GenerateCodeStatemnt(string value)
		{
			var values = value.Split('@');
			var section = values[0];
			var file = values[1];

			var fileContent = LocateFile(file);
			var sectionContent = ExtractSection(section, fileContent);

			return ConvertMarkdownCodeStatment(sectionContent);
		}

		private static string ConvertMarkdownCodeStatment(string code)
		{
			var line = code.Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
			var formattedLines = line.Select(l => string.Format("    {0}", l));
			return string.Join(Environment.NewLine, formattedLines);
		}

		private static string ExtractSection(string section, string file)
		{
			var startText = string.Format("#region {0}", section);
			var start = file.IndexOf(startText) + startText.Length;
			var end = file.IndexOf("#endregion");
			var sectionContent = file.Substring(start, end - start);
			return sectionContent;
		}

		private static string LocateFile(string file)
		{
			var appDataDir = HttpContext.Current.Server.MapPath("~/App_Data");
			var codePath = Path.Combine(appDataDir, "code-samples", file);
			if (File.Exists(codePath) == false)
				throw new FileNotFoundException(string.Format("({0} not found", file));
			return File.ReadAllText(codePath);
		}
	}
}