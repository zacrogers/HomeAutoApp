using HtmlAgilityPack;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeAutoApp
{
    public class SensorNode
    {
        private readonly int _numSensors = 3;
        public SensorNode(string name, string baseUrl)
        {
            Name = name;
            BaseUrl = baseUrl;
        }

        public string BaseUrl { set; get; }
        public string Name { set; get; }

        public List<string> getValues()
        {
            List<string> sensorVals = new List<string>();
            string html = Scraper.getHtml($"{BaseUrl}/sensors");

            if(!String.IsNullOrEmpty(html))
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                var query = from table in doc.DocumentNode.SelectNodes("//table").Cast<HtmlNode>()
                            from row in table.SelectNodes("tr").Cast<HtmlNode>()
                            from cell in row.SelectNodes("th|td").Cast<HtmlNode>()
                            select new { Table = table.Id, CellText = cell.InnerText };

                /* Looping this way to discard headers */
                foreach (int index in Enumerable.Range(_numSensors, _numSensors))
                {
                    var cell = query.ElementAt(index);
                    sensorVals.Add(cell.CellText);
                }
            }
            else
            {
                foreach (int index in Enumerable.Range(_numSensors, _numSensors))
                {
                    sensorVals.Add("0");
                }
            }

            return sensorVals;
        }
    }
}
