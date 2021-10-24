using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductCatalogv2.Data;
using ProductCatalogv2.Models;

namespace ProductCatalogv2.Controllers
{
    public class CategoryController : Controller
    {
        private readonly StoreDataContexts _context; //Acesso a dados --> Representação do Banco de Dados em Memória
        //A cada instância de DataContext abre-se uma conexão com DB --> Deve-se garantir que tenha apenas uma intância de DataContext instância a fim de garantir a segurança do DB

        //Solução --> Injeção de Dependência --> Injetar algo no construtor gera uma dependência
        public CategoryController(StoreDataContexts context)
        {
            //Evitar -- _context = new StoreDataContext(); --> Abre conexção do DB
            _context = context;
        }

        [Route("v1/categories")]
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.AsNoTracking().ToList(); //As no tracking --> Leitura o EF traz o proxy --> Infos adicionais(criacao, edicao, etc) --> Afeta a performance
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category GetCategoryById(int id)
        {
            //Find() ainda não suporta as no tracking
            return _context.Categories.AsNoTracking().Where(x => x.Id == id).FirstOrDefault(); //O primeiro item que encontrar ou retorna null .Find(id)
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return _context.Products.AsNoTracking().Where(x => x.categoryId == id).ToList();
        }


        [Route("v1/categories")]
        [HttpPost]
        public Category InsertCategory([FromBody] Category category) //O parâmetro será recebido a partir do corpo da requisição
        {
            _context.Categories.Add(category);
            _context.SaveChanges();//Context é sempre na memória por isso deve usar o saveChanges

            return category;
        }

        [Route("v1/categories")]
        [HttpPut]
        public Category UpdateCategory([FromBody] Category category)
        {
            
            //_context.Entry<Category>(category).State = EntityState.Modified; //Entrada da categoria alterada --> EntityState.Modified --> Indica para o EF que o estado do objeto/entidade foi alterado 
            //_context.SaveChanges();

            return category;

        }

        [Route("v1/categories")]
        [HttpDelete]

        public Category DeleteCategory([FromBody] Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return category;
        }






    }
}