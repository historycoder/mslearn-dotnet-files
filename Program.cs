using System.IO;
using System.Collections.Generic;

var currentDirectory = Directory.GetCurrentDirectory();
var storesDirectory = Path.Combine(currentDirectory, "stores");
var salesFiles = FindFiles(storesDirectory);

foreach (var salesFile in salesFiles){
    Console.WriteLine(salesFile);
}

static IEnumerable<string> FindFiles(string folderName) {
    List<string> salesFiles = new();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var foundFile in foundFiles) {
        var extension = Path.GetExtension(foundFile);
        if (extension == ".json"){
            salesFiles.Add(foundFile);
        }
    }

    return salesFiles;
}