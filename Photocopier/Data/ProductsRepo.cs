using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Photocopier.Models;

namespace Photocopier.Data
{
    public class ProductsRepo
    {
        protected List<Copier> Records;
        protected readonly string Path;

        public ProductsRepo(string path)
        {
            Records = new List<Copier>();
            Path = path;
            Deserialize();
        }
        
        protected void Deserialize()
        {
            string fullPath = HttpContext.Current.Server.MapPath(Path);
            TextReader txtReader = new StreamReader(fullPath);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Copier>));
            Records = (List<Copier>)xmlSerializer.Deserialize(txtReader);
            txtReader.Close();
        }

        protected virtual Predicate<Copier> CreatePredicateFrom(Expression<Func<Copier, bool>> expression)
        {
            return new Predicate<Copier>(expression.Compile());
        }

        public IEnumerable<Copier> All()
        {
            return Records.ToList();
        }

        public bool Any(Expression<Func<Copier, bool>> predicate)
        {
            var func = predicate.Compile();
            return Records.Any(func);
        }

        public Copier Find(Expression<Func<Copier, bool>> predicate)
        {
            var pred = CreatePredicateFrom(predicate);

            return Records.Find(pred);
        }
    }
}