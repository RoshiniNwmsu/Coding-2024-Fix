using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls;

namespace Coding2024_Fix
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Path to the CSV file (make sure it's in the MyData folder)
                string filePath = Server.MapPath("~/MyData/DataForTest.csv");

                // Get all data from the CSV file
                DataTable dtCreatures = GetMyData(filePath);

                // Bind the complete list to the first GridView
                gvAllCreatures.DataSource = dtCreatures;
                gvAllCreatures.DataBind();

                // Get all unique creature types
                var types = dtCreatures.AsEnumerable()
                    .Select(row => row.Field<string>("Type"))
                    .Distinct()
                    .ToList();

                if (types.Count >= 2)
                {
                    // Randomly select two different types
                    Random rnd = new Random();
                    string firstType = types[rnd.Next(types.Count)];
                    types.Remove(firstType);
                    string secondType = types[rnd.Next(types.Count)];

                    // Show the types in labels
                    lblFirstType.Text = firstType;
                    lblSecondType.Text = secondType;

                    // Filter and display the data for each type
                    gvFirstGrid.DataSource = FilterByType(dtCreatures, firstType);
                    gvFirstGrid.DataBind();

                    gvSecondGrid.DataSource = FilterByType(dtCreatures, secondType);
                    gvSecondGrid.DataBind();
                }
            }
        }

        // Function to read CSV file and return as DataTable
        private DataTable GetMyData(string filePath)
        {
            DataTable dt = new DataTable();

            if (!File.Exists(filePath))
                throw new FileNotFoundException("CSV file not found at: " + filePath);

            using (StreamReader sr = new StreamReader(filePath))
            {
                bool isFirstLine = true;
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] fields = line.Split(',');

                    if (isFirstLine)
                    {
                        foreach (string header in fields)
                            dt.Columns.Add(header.Trim());
                        isFirstLine = false;
                    }
                    else
                    {
                        dt.Rows.Add(fields);
                    }
                }
            }

            return dt;
        }

        // Function to filter creatures by type
        private DataTable FilterByType(DataTable dtCreatures, string type)
        {
            DataRow[] filteredRows = dtCreatures.Select($"Type = '{type}'");

            if (filteredRows.Length == 0)
                return null;

            DataTable dtFiltered = dtCreatures.Clone();

            foreach (DataRow row in filteredRows)
                dtFiltered.ImportRow(row);

            return dtFiltered;
        }
    }
}