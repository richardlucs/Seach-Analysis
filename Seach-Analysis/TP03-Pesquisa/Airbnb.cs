using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TP03_Pesquisa
{
    class Airbnb
    {
        //Criando atributos da classe Airbnb de acordo com o arquivo disponibilizado
        public int RoomID { get; set; }
        public int HostID { get; set; }
        public string RoomType { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public double Reviews { get; set; }
        public double OverallSatisfaction { get; set; }
        public int Accommodates { get; set; }
        public double Bedrooms { get; set; }
        public double Price { get; set; }
        public string PropertyType { get; set; }


        //Construtor da classe Airbnb que inicia todos os atributos declarados
        public Airbnb(int _RoomID, int _HostID, string _RoomType, string _City, string _Country, string _Neighborhood, double _Reviews, double _OverallSatisfaction, int _Accommodates, double _Bedrooms, double _Price, string _PropertyType)
        {
            RoomID = _RoomID;
            HostID = _HostID;
            RoomType = _RoomType;
            City = _City;
            Country = _Country;
            Neighborhood = _Neighborhood;
            Reviews = _Reviews;
            OverallSatisfaction = _OverallSatisfaction;
            Accommodates = _Accommodates;
            Bedrooms = _Bedrooms;
            Price = _Price;
            PropertyType = _PropertyType;
        }
    }
}
