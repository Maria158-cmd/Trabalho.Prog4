using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using UMFG.Venda.Aprensetacao.Classes;
using UMFG.Venda.Aprensetacao.Models;

namespace UMFG.Venda.Aprensetacao.Comandos
{
    internal class ListarProdutosViewModel : AbstractViewModel
    {
        private PedidoModel _pedido;
        private ProdutoModel _produtoSelecionado;
        internal object Pedido;

        public ObservableCollection<ProdutoModel> Produtos { get; set; }

        public ProdutoModel ProdutoSelecionado
        {
            get => _produtoSelecionado;
            set
            {
                if (_produtoSelecionado != value)
                {
                    _produtoSelecionado = value;
                    PropertyChanged(nameof(ProdutoSelecionado));
                }
            }
        }

        public ICommand Remover { get; }

        public ListarProdutosViewModel()
        {
            // Inicialize seus produtos e pedido aqui
            Produtos = new ObservableCollection<ProdutoModel>();
            _pedido = new PedidoModel();

            // Inicialize o comando Remover
            Remover = new RelayCommand(RemoverItem, CanRemoverItem);
        }

        private bool CanRemoverItem(object obj)
        {
            // Verifica se há um item selecionado e se esse item está presente no pedido
            return ProdutoSelecionado != null && _pedido.Produtos.Contains(ProdutoSelecionado);
        }

        private void RemoverItem(object obj)
        {
            // Remove o item selecionado do pedido
            _pedido.Produtos.Remove(ProdutoSelecionado);
        }
    }
}
