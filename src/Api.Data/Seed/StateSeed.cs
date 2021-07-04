using System;
using System.Collections.Generic;
using Api.Domain.Entities;

namespace Api.Data.Seed
{
    public class StateSeed
    {
        public List<StateEntity> Seed()
        {
            List<StateEntity> list = new List<StateEntity>(){
                new StateEntity
                {
                    Id = 1,
                    Name = "Acre",
                    Initials = "AC",
                    Iso = "12",
                    Slug = "acre",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 2,
                    Name = "Alagoas",
                    Initials = "AL",
                    Iso = "27",
                    Slug = "alagoas",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 3,
                    Name = "Amazonas",
                    Initials = "AM",
                    Iso = "13",
                    Slug = "amazonas",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 4,
                    Name = "Amapá",
                    Initials = "AP",
                    Iso = "16",
                    Slug = "amapa",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 5,
                    Name = "Bahia",
                    Initials = "BA",
                    Iso = "29",
                    Slug = "bahia",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 6,
                    Name = "Ceará",
                    Initials = "CE",
                    Iso = "23",
                    Slug = "ceara",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 7,
                    Name = "Distrito Federal",
                    Initials = "DF",
                    Iso = "53",
                    Slug = "distrito-federal",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 8,
                    Name = "Espírito Santo",
                    Initials = "ES",
                    Iso = "32",
                    Slug = "espirito-santo",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 9,
                    Name = "Goiás",
                    Initials = "GO",
                    Iso = "52",
                    Slug = "goias",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 10,
                    Name = "Maranhão",
                    Initials = "MA",
                    Iso = "21",
                    Slug = "maranhao",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 11,
                    Name = "Minas Gerais",
                    Initials = "MG",
                    Iso = "31",
                    Slug = "minas-gerais",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 12,
                    Name = "Mato Grosso do Sul",
                    Initials = "MS",
                    Iso = "50",
                    Slug = "mato-grosso-do-sul",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 13,
                    Name = "Mato Grosso",
                    Initials = "MT",
                    Iso = "51",
                    Slug = "mato-grosso",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 14,
                    Name = "Pará",
                    Initials = "PA",
                    Iso = "15",
                    Slug = "para",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 15,
                    Name = "Paraiba",
                    Initials = "PB",
                    Iso = "25",
                    Slug = "paraiba",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 16,
                    Name = "Pernambuco",
                    Initials = "PE",
                    Iso = "26",
                    Slug = "pernambuco",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 17,
                    Name = "Piauí",
                    Initials = "PI",
                    Iso = "22",
                    Slug = "piaui",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 18,
                    Name = "Paraná",
                    Initials = "PR",
                    Iso = "41",
                    Slug = "parana",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 19,
                    Name = "Rio de Janeiro",
                    Initials = "RJ",
                    Iso = "33",
                    Slug = "rio-de-janeiro",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 20,
                    Name = "Rio Grande do Norte",
                    Initials = "RN",
                    Iso = "24",
                    Slug = "rio-grande-do-norte",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 21,
                    Name = "Rondônia",
                    Initials = "RO",
                    Iso = "11",
                    Slug = "rondonia",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 22,
                    Name = "Roraima",
                    Initials = "RR",
                    Iso = "14",
                    Slug = "roraima",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 23,
                    Name = "Rio Grande do Sul",
                    Initials = "RS",
                    Iso = "43",
                    Slug = "rio-grande-do-sul",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 24,
                    Name = "Santa Catarina",
                    Initials = "SC",
                    Iso = "42",
                    Slug = "santa-catarina",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 25,
                    Name = "Sergipe",
                    Initials = "SE",
                    Iso = "28",
                    Slug = "sergipe",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 26,
                    Name = "São Paulo",
                    Initials = "SP",
                    Iso = "35",
                    Slug = "sao-paulo",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                },
                new StateEntity
                {
                    Id = 27,
                    Name = "Tocantins",
                    Initials = "TO",
                    Iso = "17",
                    Slug = "tocantins",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                }
            };
            return list;
        }
    }
}