﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Api.Domain.Entities
{
    public class Produit
    {
        public int Id { get; }
        public string Nom { get; }
        public double Prix { get; }

        internal Produit(int id, string nom, double prix)
        {
            Id = id;
            Nom = nom;
            Prix = prix;
        }
    }
}
