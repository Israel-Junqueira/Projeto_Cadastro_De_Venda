using System;

namespace CadastroDeVendas.Models
{
    public class SalesRecord
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public double amount { get; set; }
        public SaleStatus status { get; set; }
        public Seller Seller { get; set; } //pois cada VEnda possui um vendedor

        public SalesRecord()
        {

        }

        public SalesRecord(int iD, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            ID = iD;
            Date = date;
            this.amount = amount;
            this.status = status;
            Seller = seller;
        }
    }
}
