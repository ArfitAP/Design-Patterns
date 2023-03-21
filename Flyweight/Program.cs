using Flyweight;

Console.Title = "Flyweight";

var bunchOfCharacters = "abba";

var characterFactory = new CharacterFactory();

var characterObject = characterFactory.GetCharacter(bunchOfCharacters[0]);
characterObject?.Draw("Arial", 12);

characterObject = characterFactory.GetCharacter(bunchOfCharacters[1]);
characterObject?.Draw("Times New Roman", 14);

characterObject = characterFactory.GetCharacter(bunchOfCharacters[2]);
characterObject?.Draw("Comic Sans", 16);

characterObject = characterFactory.GetCharacter(bunchOfCharacters[3]);
characterObject?.Draw("Noto Sans", 10);


// Create unshared concrete flyweight (paragraph)
var paragraph = characterFactory.CreateParagraph(new List<ICharacter>() { characterObject }, 1);

paragraph.Draw("Lucinda", 19);

Console.ReadLine();
