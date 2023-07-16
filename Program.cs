using Newtonsoft.Json;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");

var salesTotalDir = Path.Combine(currentDirectory, "salesTotalDir");
Directory.CreateDirectory(salesTotalDir);

var salesFiles = FindFiles(storesDirectory);
var salesTotal = CalculateSalesTotal(salesFiles);

File.AppendAllText(Path.Combine(salesTotalDir, "totals.txt"), $"{salesTotal}{Environment.NewLine}");

static IEnumerable<string> FindFiles(string folderName) {
    List<string> salesFiles = new();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var foundFile in foundFiles) {
        var extension = Path.GetExtension(foundFile);
        if (extension == ".json") {
            salesFiles.Add(foundFile);
        }
    }

    return salesFiles;
}

static double CalculateSalesTotal(IEnumerable<string> salesFiles) {
    double salesTotal = 0;

    //Loop over each file path in salesFiles
    foreach (var salesFile in salesFiles){
        //Read the contents of the file
        string salesJson = File.ReadAllText(salesFile);

        //Parse the contents as JSON
        SalesData? data = JsonConvert.DeserializeObject<SalesData?>(salesJson);

        //Add the amount found in the Total field to the salesTotal variable
        salesTotal += data?.Total ?? 0;
    }

    return salesTotal;
}
record SalesData(double Total);