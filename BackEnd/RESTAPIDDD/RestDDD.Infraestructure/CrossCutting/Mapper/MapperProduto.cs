using RestDDD.Application.DTOS;
using RestDDD.Domain.Entities;
using RestDDD.Infraestructure.CrossCutting.Intercafes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestDDD.Infraestructure.CrossCutting.Mapper
{
    public class MapperProduto : IMapperProduto
    {
        //IEnumerable<ClienteDTO> clienteDTO = new List<ClienteDTO>();
        public Produto MapperDTOEntity(ProdutoDTO produtoDTO)
        {
            var produto = new Produto()
            {
                id = produtoDTO.Id,
                Nome = produtoDTO.Nome,
                Valor = produtoDTO.Valor
            };

            return produto;
        }

        public ProdutoDTO MapperEntityToDTO(Produto produto)
        {
            var produtoDTO = new ProdutoDTO()
            {
                Id = produto.id,
                Nome = produto.Nome,
                Valor = produto.Valor
            };

            return produtoDTO;
        }

        public IEnumerable<ProdutoDTO> MapperListProdutoDTO(IEnumerable<Produto> produtos)
        {
            var dto = produtos.Select(c => new ProdutoDTO
            {
                Id = c.id,
                Nome = c.Nome,
                Valor = c.Valor
            });

            return dto;
        }
    }
}
