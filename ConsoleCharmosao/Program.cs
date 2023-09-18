using System.CommandLine;

// Crie uma descrição que será exibida caso o usuario não passe nenhum argumento.
// Isso também serve para você escrever uma descrição da sua ferramenta console.
var description = @"
Bem vindo ao meu console charmosão com vários 
comandos listados e documentados";

var rootCommand = new RootCommand(description);

// Crie um novo comando
var lengthCommand = new Command("length", "Quantidade de caracteres em uma string");

// define nomes alternativos para chamar esse comando
lengthCommand.AddAlias("len");
lengthCommand.AddAlias("l");

// crie novo argumento a 
var lengthArgument = new Argument<string>("string", "string para ser processada");
lengthArgument.SetDefaultValue(string.Empty);

// adicione o novo argumento ao comando
lengthCommand.AddArgument(lengthArgument);

// crie uma nova opção
var lengthOptionRepeat = new Option<int>("--repeat", "Imprime quantas vezes?");
lengthOptionRepeat.AddAlias("-r");
lengthOptionRepeat.SetDefaultValue(1);

// adicione essa opção ao lengthComand
lengthCommand.AddOption(lengthOptionRepeat);

lengthCommand.SetHandler((lengthArgumentValue, lengthOptionRepeatValue) =>
{
    // recendo os valores e processando-os
    for (int i = 0; i < lengthOptionRepeatValue; i++) 
    {
        Console.WriteLine($"{i + 1}. {lengthArgumentValue.Length}");
    }

}, lengthArgument, lengthOptionRepeat); // lembre-se de passar os parametros aqui


// adicionando o length command ao nosso comando principal
rootCommand.AddCommand(lengthCommand);

// Passe os argumentos recebidos pela a console aplication para o objeto rootCommand 
// através do seu metódo invoke.
rootCommand.Invoke(args);