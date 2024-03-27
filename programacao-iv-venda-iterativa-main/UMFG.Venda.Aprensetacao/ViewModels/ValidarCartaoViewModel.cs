using System;
using System.ComponentModel;
using System.Windows.Input;
using UMFG.Venda.Aprensetacao.Classes;
using UMFG.Venda.Aprensetacao.Models;

namespace UMFG.Venda.Aprensetacao.ViewModels
{
    internal class ucReceberViewModel : AbstractViewModel, INotifyPropertyChanged
    {
        private PedidoModel _pedido;
        private string _nome;
        private string _numeroCartao;
        private string _dataVencimento;
        private string _cvv;
        private string _opcaoSelecionada;

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (_nome != value)
                {
                    _nome = value;
                    OnPropertyChanged(nameof(Nome));
                }
            }
        }

        public string NumeroCartao
        {
            get { return _numeroCartao; }
            set
            {
                if (_numeroCartao != value)
                {
                    _numeroCartao = value;
                    OnPropertyChanged(nameof(NumeroCartao));
                }
            }
        }

        public string DataVencimento
        {
            get { return _dataVencimento; }
            set
            {
                if (_dataVencimento != value)
                {
                    _dataVencimento = value;
                    OnPropertyChanged(nameof(DataVencimento));
                }
            }
        }

        public string CVV
        {
            get { return _cvv; }
            set
            {
                if (_cvv != value)
                {
                    _cvv = value;
                    OnPropertyChanged(nameof(CVV));
                }
            }
        }

        public string OpcaoSelecionada
        {
            get { return _opcaoSelecionada; }
            set
            {
                if (_opcaoSelecionada != value)
                {
                    _opcaoSelecionada = value;
                    OnPropertyChanged(nameof(OpcaoSelecionada));
                }
            }
        }

        public ICommand ReceberCommand { get; }

        public ucReceberViewModel(PedidoModel pedido)
        {
            _pedido = pedido ?? throw new ArgumentNullException(nameof(pedido));

            ReceberCommand = new RelayCommand(Receber, CanReceber);
        }

        private bool CanReceber(object obj)
        {
            
            return !string.IsNullOrWhiteSpace(Nome) &&
                   !string.IsNullOrWhiteSpace(NumeroCartao) &&
                   !string.IsNullOrWhiteSpace(DataVencimento) &&
                   !string.IsNullOrWhiteSpace(CVV);
        }

        private void Receber(object obj)
        {
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

