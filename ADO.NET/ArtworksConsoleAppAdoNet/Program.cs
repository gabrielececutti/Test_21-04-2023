using ArtworksConsoleAppAdoNet.Repositories;
using System.Data.Common;

var artistRepository = new ArtistRepositorty();
var museumRepository = new MuseumRepository();
var newModelRepository = new NewModelRepository();

// 1 QUERY
Console.WriteLine("Scrivere una query per recuperare i nomi degli artisti le cui opere sono conservate a Parigi.");
var query1 = artistRepository.GetByCounrtyArtwork("Parigi");
if (query1.Any())
{
    foreach (var item in query1) Console.WriteLine(item.Name);
}
else
{
    Console.WriteLine("Nessun elemento trovato");
}
Console.WriteLine();

// 2 QUERY
Console.WriteLine("Scrivere una query \"select\" per recuperare la lista contenete: museo, nome opera, nome personaggio degli artisti italiani.");
var query2 = newModelRepository.GetByArtistNationality("Italia");
if (query2.Any())
{
    foreach (var item in query2) Console.WriteLine($"Museo: {item.Museum}, nome opera: {item.ArtworkName}, nome personaggio: {item.CharacterName}");
}else
{
    Console.WriteLine("Nessun elemento trovato");
}
Console.WriteLine();

// 3 QUERY
Console.WriteLine("Scrivere una query “select” per recuperare la città del museo in quale è conservato quadro \"Flora\".");
var query3 = museumRepository.GetByPictureName("Flora");
if (query3.Any())
{
    foreach (var museum in query3) Console.WriteLine(museum.City);
}else
{
    Console.WriteLine("Nessun elemento trovato");
}




