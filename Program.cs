namespace Validar_CPF {
    class Program {
        public static bool IsCPF(string cpf) {
            int[] multiplicador1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            int[] multiplicador2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};
            string tempCpf, digito;
            int soma, resto;

            //.Trim remove espaços laterais no inicio e fim
            cpf = cpf.Trim();
            //.Replace troca o da primeira "" pela segunda ""
            cpf = cpf.Replace(".","").Replace("-","");
            //.Length retorna o tamanho da string
            if (cpf.Length != 11)
                return false;
            //.Substring extrai uma subcadeia de caracteres (inicio (0), final(9))
            tempCpf =  cpf.Substring(0,9);
            soma = 0;

            for (int i=0; i<9; i++)
            //.ToString retorna o conteúdo para string
            //transformando char (tempCpf) em string para virar int com o parse
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i=0; i<10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma %11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            //.EndsWith verifica se as strings cpf e digito são as mesmas
            return cpf.EndsWith(digito);
        }

        public static void Main (string[] args){

            Console.Write("Digite o cpf: ");
            if (IsCPF(Console.ReadLine()))
                Console.WriteLine("Válido");
            else
                Console.WriteLine("Inváldo");
        }
    }
}