using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAutoApp
{
    private readonly int _numSensors = 3;
    public class SensorNode
    {
        public SensorNode(string name, string baseUrl)
        {
            Name = name;
            BaseUrl = baseUrl;
        }

        public string BaseUrl { set; get; }
        public string Name { set; get; }

        public List<string> getStates()
        {
            List<string> sensorVals = new List<string>();

            string html = Scraper.getHtml($"{BaseUrl}/sensors");

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
                states.Add(cell.CellText);
            }

            return states;
        }
    }
}
