﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace CadastroDeVendas.Models

{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date) ]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthData { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; } //pois os vendedores possui uma venda
        public int DepartmentId { get; set; }// garante que o Id exista e a coluna não fique nula
        public List<SalesRecord> records { get; set; } = new List<SalesRecord>(); //pois os vendedores possuem varias vendas

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime birthData, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthData = birthData;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord sales)
        {
            records.Add(sales);
        }

        public void RemoveSales(SalesRecord sales)
        {
            records.Remove(sales);
        }

        public double TotalSales(DateTime inicial, DateTime Finaldata)
        {//retorne (a coleção records) Filtrando com Where(expressão lambida)  
         //(Salesrecord talque salesrecord seja maior ou igual minha data inicial
         // e salesrecord data seja menor ou igual data final) 

            //Sum - soma (soma doque ? expressão lambda)
            //salesrecord que leva salesrecord.Amount 
            return records.Where(salesrecord => salesrecord.Date >= inicial && salesrecord.Date <= Finaldata).Sum(salesrecord => salesrecord.amount);
        }

    }
}
