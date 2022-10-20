using RestDDD.Application.DTOS;
using RestDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestDDD.Infraestructure.CrossCutting.Intercafes
{
    public interface IMapperProduto
    {
        Produto MapperDTOEntity(ProdutoDTO clienteDTO);
        IEnumerable<ProdutoDTO> MapperListProdutoDTO(IEnumerable<Produto> produto);
        ProdutoDTO MapperEntityToDTO(Produto produto);
    }
}
