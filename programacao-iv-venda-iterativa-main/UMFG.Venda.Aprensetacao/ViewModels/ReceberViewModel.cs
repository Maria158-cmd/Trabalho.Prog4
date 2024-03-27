using System;
using System.Windows.Controls;
using UMFG.Venda.Aprensetacao.Classes;
using UMFG.Venda.Aprensetacao.Interfaces;
using UMFG.Venda.Aprensetacao.Models;

namespace UMFG.Venda.Aprensetacao.ViewModels
{
    internal sealed class ReceberViewModel : AbstractViewModel
    {
        private PedidoModel _pedido = new PedidoModel();

        public PedidoModel Pedido
        {
            get => _pedido;
            set => SetField(ref _pedido, value);
        }

        public ReceberViewModel(UserControl userControl, IObserver observer, PedidoModel pedido) : base("Receber")
        {
            UserControl = userControl ?? throw new ArgumentNullException(nameof(userControl));
            MainUserControl = observer ?? throw new ArgumentNullException(nameof(observer));

            // Verifica se o pedido possui itens antes de atribuir o valor ao Pedido
            if (pedido == null || pedido.Produtos.Count == 0)
            {
                throw new ArgumentException("Não é possível navegar para a tela de recebimento sem itens no pedido.");
            }

            Pedido = pedido;

            Add(observer);
        }
    }
}
