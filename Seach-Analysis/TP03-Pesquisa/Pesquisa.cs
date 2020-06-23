using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TP03_Pesquisa
{
    class Pesquisa
    {
        //Definição da List que receberá os dados do arquivo
        List<Airbnb> AirbnbC;

        //Inicia a classe definindo que ela recebe um List com os dados e seta a List local da classe com os dados recebidos
        public Pesquisa(List<Airbnb> _AirbnbData)
        {
            AirbnbC = _AirbnbData;
        }

        //Abaixo são programados todos os métodos de busca que são chamados na função PesquisaAirbnb

        //1 - Implementação da Pesquisa Sequencial, que recebe um RoomID e NumComp como referência;
        //Busca o RoomID definido dentro da List e incrementa o NumComp para cada iteração, caso encontre o RoomID retorna o objeto Airbnb referente a ele e caso não, retorna nulo;
        public Airbnb PesquisaSequencial(int RoomID, ref int NumComp)
        {
            foreach (Airbnb Dado in AirbnbC)
            {
                NumComp++;

                if (Dado.RoomID == RoomID)
                    return Dado;
            }

            return default(Airbnb);
        }

        //2 - Implementação da Pesquisa Binária, que recebe um RoomID e NumComp como referência;
        //Primeiro, transforma a List da classe em um Array e em seguida executa um QuickSort para realizar a ordenação dos dados (requisito da Pesquisa Binária);
        //Depois busca o RoomID definido dentro do Array ordenado e incrementa o NumComp para cada iteração, caso encontre o RoomID retorna o objeto Airbnb referente a ele e caso não, retorna nulo;
        public Airbnb PesquisaBinária(int RoomID, ref int NumComp)
        {
            Airbnb[] AirbnbArray = AirbnbC.ToArray();

            QuickSort(AirbnbArray, 0, AirbnbArray.Length - 1);

            int início = 0, fim = AirbnbArray.Length - 1;
            while (início <= fim)
            {
                int meio = (início + fim) / 2;
                NumComp++;
                if (RoomID == AirbnbArray[meio].RoomID)
                    return AirbnbArray[meio];
                else if (RoomID < AirbnbArray[meio].RoomID)
                    fim = meio - 1;
                else
                    início = meio + 1;
            }

            return default(Airbnb);
        }

        //Implementação de um método QuickSort que fará a ordenação necessária para a Busca Binária
        private void QuickSort(Airbnb[] vetor, int esquerda, int direita)
        {
            int i = esquerda,
                j = direita;
            Airbnb pivot = vetor[(esquerda + direita) / 2];

            while (i <= j)
            {
                while (vetor[i].RoomID < pivot.RoomID && i < direita) i++;
                while (vetor[j].RoomID > pivot.RoomID && j > esquerda) j--;

                if (i <= j)
                {
                    Airbnb aux = vetor[i];
                    vetor[i] = vetor[j];
                    vetor[j] = aux;

                    i++;
                    j--;
                }
            }

            if (j > esquerda)
                QuickSort(vetor, esquerda, j);

            if (i < direita)
                QuickSort(vetor, i, direita);
        }

        //3 - Implementação da Pesquisa em Árvore, que recebe um RoomID e NumComp como referência;
        //Primeiro, instancia a Árvore binária para busca. Em seguida, executa um foreach na List da classe com os dados, e insere o objeto Airbnb na Árvore a cada iteração.
        //Como a Árvore é uma estrutura de dados construída "externamente", é chamado um método na classe ÁrvoreBinária que faz o retorno da pesquisa do RoomID.
        public Airbnb Árvore(int RoomID, ref int NumComp)
        {
            ÁrvoreBinária MinhaÁrvore = new ÁrvoreBinária();

            foreach (Airbnb Dado in AirbnbC)
                MinhaÁrvore.Inserir(Dado);

            return MinhaÁrvore.Pesquisar(RoomID, ref NumComp);
        }

        //4 - Implementação da Pesquisa em Tabela Hash, que recebe um RoomID e NumComp como referência;
        //Primeiro, instancia a Tabela Hash para busca. Em seguida, executa um foreach na List da classe com os dados, e insere o objeto Airbnb na Tabela a cada iteração.
        //Como a Tabela Hash é uma estrutura de dados construída "externamente", é chamado um método na classe TabelaHash que faz o retorno da pesquisa do RoomID.
        public Airbnb TabelaHash(int RoomID, ref int NumComp)
        {
            TabelaHash MinhaTabelaHash = new TabelaHash();
            foreach (Airbnb Dado in AirbnbC)
                MinhaTabelaHash.Inserir(Dado);

            return MinhaTabelaHash.Pesquisar(RoomID, ref NumComp);
        }
        
    }

    //Implementação da Árvore Binária de Busca
    class ÁrvoreBinária
    {
        //Primeiramente é definido o No da Árvore que contém um item Airbnb, e dois outros Nos (esquerda e direita).
        //Essa classe no é iniciada definindo o item Airbnb
        class No
        {
            public Airbnb Item;
            public No Esq, Dir;
            public No(Airbnb item)
            {
                Item = item;
                Esq = Dir = null;
            }
        }

        //Criação do Nodo Raiz da Árvore Binária
        private No raiz;

        //Definição da Raiz como nula quando a Árvore for iniciada
        public ÁrvoreBinária()
        {
            raiz = null;
        }

        //Implementação da função Pesquisar da Árvore, que recebe o código (ou nesse caso o RoomID) e um NumComp como referência 
        public Airbnb Pesquisar(int código, ref int NumComp)
        {
            //Cria um No chamando outro método pesquisar e o retorna caso ele não seja nulo
            No no = pesquisar(raiz, código, ref NumComp);
            if (no != null)
                return no.Item;
            return null;
        }

        //O método pesquisar funciona de forma recursiva que verifica No a No se o RoomID do seu item é maior ou menor que o RoomID a ser pesquisado
        //Se for menor, pesquisa no No filho da esquerda
        //Se for maior, pesquisa no No filho da direita
        //O método pesquisar é sempre acompanhado de uma referência ao NumComp, que incrementa seu valor a cada iteração
        //Ao encontrar um item do No que corresponda ao RoomID a ser pesquisado faz o retorno deste
        private No pesquisar(No no, int RoomID, ref int NumComp)
        {
            NumComp++;
            if (no == null)
                return null;
            else if (RoomID < no.Item.RoomID)
                return pesquisar(no.Esq, RoomID, ref NumComp);
            else if (RoomID > no.Item.RoomID)
                return pesquisar(no.Dir, RoomID, ref NumComp);

            return no;
        }

        //Implementação da função Inserir da Árvore, que recebe o objeto Airbnb e chama um outro método que faz a inserção do objeto na Árvore
        public void Inserir(Airbnb item)
        {
            raiz = inserir(raiz, item);
        }

        //O método inserir funciona de forma recursiva que verifica No a No se o RoomID do seu item é maior ou menor que o RoomID do item a ser inserido
        //Se for menor, insere no No filho da esquerda
        //Se for maior, insere no No filho da direita
        //Quando encontra o No nulo, faz a inserção neste
        private No inserir(No no, Airbnb item)
        {
            if (no == null)
                no = new No(item);
            else if (item.RoomID < no.Item.RoomID)
                no.Esq = inserir(no.Esq, item);
            else if (item.RoomID > no.Item.RoomID)
                no.Dir = inserir(no.Dir, item);
            return no;
        }
    }

    //Implementação da Tabela Hash

    //Primeiramente, cria uma classe de Lista encadeada padrão com os métodos Inserir e Pesquisar
    class Lista
    {
        class Elemento
        {
            public Airbnb Airbnb;
            public Elemento Prox;

            public Elemento()
            {
                Airbnb = null;
                Prox = null;
            }
        }

        private Elemento Início;
        private Elemento Fim;
        private Elemento Aux;

        public Lista()
        {
            Início = null;
            Fim = null;
        }

        public void Inserir(Airbnb Dado)
        {
            Elemento Novo = new Elemento();

            Novo.Airbnb = Dado;

            if (Início == null)
            {
                Início = Novo;
                Fim = Novo;

                Novo.Prox = null;
            }
            else
            {
                Fim.Prox = Novo;
                Fim = Novo;
                Fim.Prox = null;
            }
        }

        //A única modificação (além das adaptações de contexto) da classe Lista foi a inclusão do contador de comparações necessárias para buscar o RoomID na Lista (que nesse caso é uma posição da Tabela)
        public Airbnb Pesquisar(int RoomID, ref int NumComp)
        {
            Aux = Início;

            while (Aux != null)
            {
                NumComp++;
                if (Aux.Airbnb.RoomID == RoomID)
                {
                    return Aux.Airbnb;
                }
                else
                {    
                    Aux = Aux.Prox;
                }
            }

            return null;
        }
    }

    //Tabela Hash usando Lista Encadeada
    class TabelaHash
    {
        //Declara um vetor de Listas encadeadas para ser a Tabela e define o tamanho máximo dela como 751 (número primo que também servirá como a chave hash)
        Lista[] Tabela;
        int Max = 751;

        //Instancia uma Tabela Hash como um vetor de Listas e com o total de posições máximo
        public TabelaHash()
        {
            Tabela = new Lista[Max];

            //Para cada posição do vetor Tabela, cria uma nova Lista encadeada
            for(int i = 0; i < Max; i++)
            {
                Tabela[i] = new Lista();
            }
        }

        //O método Mod calcula a chave ou posição de inserção da tabela dividindo o número do parâmetro pelo Max (chave hash)
        private int Mod(int _chave)
        {
            return _chave % Max;
        }

        //O método Inserir recebe o objeto Airbnb a ser inserido
        //Calcula a posição de inserção com o RoomID do objeto
        //Depois chama a função Inserir na posição calculada da tabela(da classe Lista), passando o objeto Airbnb como parâmetro
        public void Inserir(Airbnb Dado)
        {
            int Pos = Mod(Dado.RoomID);
            Tabela[Pos].Inserir(Dado);
        }

        //Por último, o método Pesquisar recebe o RoomID como parâmetro e um NumComp como referência
        //Ele calcula a posição na Tabela que esse Airbnb foi inserido
        //Logo, o objeto Dado recebe o resultado da pesquisa (implementada na classe Lista) para esse RoomID e o retorna
        //O NumComp é atualizado primeiramente aqui para sinalizar a busca da posição e como referência na chamada do método Pesquisa na classe Lista
        public Airbnb Pesquisar(int RoomID, ref int NumComp)
        {
            int Pos = Mod(RoomID);

            NumComp++;

            Airbnb Dado = Tabela[Pos].Pesquisar(RoomID, ref NumComp);

            return Dado;
        }
    }
}
