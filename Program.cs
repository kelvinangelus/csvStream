using static System.Console;

//LerCSV();
CriarCSV();
WriteLine("\n\npressione [enter] para finalizar");
ReadLine();

static void CriarCSV()
{
    var path = Path.Combine(Environment.CurrentDirectory,
    "Saida");

    var pessoas = new List<Pessoa>(){
        new Pessoa()
        {
            Nome = "José da Silva",
            Email = "js@gmail.com",
            Telefone = 123456,
            Nascimento = new DateOnly(year: 1970, month: 2, day: 14)
        },
        new Pessoa()
        {
            Nome = "Pedro Paiva",
            Email = "pp@gmail.com",
            Telefone = 456789,
            Nascimento = new DateOnly(year: 2002, month: 4, day: 20)
          
        },
        new Pessoa()
        {
            Nome = "Maria Antonia",
            Email = "ma@gmail.com",
            Telefone = 123456,
            Nascimento = new DateOnly(year: 1982, month: 12, day: 4)
          
        },
        new Pessoa()
        {
            Nome = "Carla Moraes",
            Email = "cms@gmail.com",
            Telefone = 9987411,
            Nascimento = new DateOnly(year: 2000, month: 7, day: 20)
          
        }
    };

    var di = new DirectoryInfo(path);
    if(!di.Exists)
    {
        di.Create();
        path = Path.Combine(path,"usuarios.csv");
    }
    using var sw = new StreamWriter(path);
    sw.WriteLine("nome,email,telefone,nascimento");

    foreach(var pessoa in pessoas)
    {
        var linha = $"{pessoa.Nome},{pessoa.Email},{pessoa.Telefone},{pessoa.Nascimento}";
        sw.WriteLine(linha);
    }
}

static void LerCSV()
{
    var path = Path.Combine(
        Environment.CurrentDirectory,"Entrada",
        "usuarios-exportacao.csv");

    if(File.Exists(path))
    {
        using var sr = new StreamReader(path);

        //split pega cada ponto e vírgula e transforma
        //numa string separada. cabecalho é um array de string
        var cabecalho = sr.ReadLine()?.Split(';'); //nullable enabled

        while(true)
        {
            var registro = sr.ReadLine()?.Split(';'); //cada linha é salva 
                                                    //em registro
            if(registro == null) break;
            if(cabecalho.Length != registro.Length)
            {
                WriteLine("Arquivo fora do padrão");
                break;
            }
            for(int i =0; i < registro.Length; i++)
            {
                //? garante que no caso de ser nulo, nada será printado
                WriteLine($"{cabecalho?[i]}:{registro[i]}");
            }
            WriteLine("------------------");
        }

    }
    else
    {
        WriteLine($"O arquivo{path} não existe");
    }
}

class Pessoa
{
    public string Nome{get; set;}

    public string Email{get; set;}

    public int Telefone{get; set;}

    public DateOnly Nascimento{get; set;}
}