using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno:");
                        var aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine();
                        Console.WriteLine("Informe a nota do aluno:");
                        
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                            Console.WriteLine();
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Conceito conceitoGeral = new Conceito();

                                if (a.Nota < 2)
                                {
                                conceitoGeral = Conceito.E;
                                }
                                else if(a.Nota < 4)
                                {
                                conceitoGeral = Conceito.D;
                                }
                                else if(a.Nota < 6)
                                {
                                conceitoGeral = Conceito.C;
                                }
                                else if(a.Nota < 8)
                                {
                                conceitoGeral = Conceito.B;
                                }
                                else if(a.Nota < 10)
                                {
                                conceitoGeral = Conceito.A;
                                }

                                Console.WriteLine($"Aluno: {a.Nome}\n\nNota: {a.Nota}\n\nConceito: {conceitoGeral}");
                                Console.WriteLine();
                            }
                            
                        }

                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nAlunos = 0;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nAlunos;

                        
                        
                        Console.WriteLine($"Média Geral: {mediaGeral}");
                        
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
        }
        
        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular Média Geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
