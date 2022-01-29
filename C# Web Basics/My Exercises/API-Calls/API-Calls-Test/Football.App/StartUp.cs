using Football.App;

var fixtureId = 770994;

var deserializer = new Deserializer();

//string fixtureData = await deserializer.DeserilizeFixture(fixtureId);

//Console.WriteLine(fixtureData);

string rounds = await deserializer.DeserializeRounds(61, 2019);

Console.WriteLine(rounds);