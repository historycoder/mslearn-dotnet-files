using System.IO;
using System.Collections.Generic;

var salesFiles = FindFiles("stores");

foreach (var salesFile in salesFiles){
    Console.WriteLine(salesFile);
}

static IEnumerable<string> FindFiles(string folderName) {
    List<string> salesFiles = new();

    var foundFiles = Directory.EnumerateFiles(folderName, "*", SearchOption.AllDirectories);

    foreach (var foundFile in foundFiles) {
        if (foundFile.EndsWith("sales.json")){
            salesFiles.Add(foundFile);
        }
    }

    return salesFiles;
}