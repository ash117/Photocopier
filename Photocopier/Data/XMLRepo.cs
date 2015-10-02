using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using Photocopier.Models;

namespace Photocopier.Data
{
    public abstract class XMLRepo<TEntity> : IProducts<TEntity>
    {
        protected readonly List<TEntity> Records;
        protected readonly string Path;
        private string p;

        protected XMLRepo(string path)
        {
            Records = new List<TEntity>();
            Path = path;
        }
        
        protected virtual Predicate<TEntity> CreatePredicateFrom(Expression<Func<TEntity, bool>> expression)
        {
            return new Predicate<TEntity>(expression.Compile());
        }

        protected virtual void ReadFile()
        {
            var contents = string.Empty;
            string fullPath = HttpContext.Current.Server.MapPath(Path);
            if (File.Exists(fullPath))
            {
                contents = File.ReadAllText(fullPath);
            }

            if (string.IsNullOrEmpty(contents))
            {
                return;
            }

            var deserializer = new XmlSerializer(typeof(Copier), new XmlRootAttribute("Copiers"));

            using (var stringReader = new StringReader(contents))
            using (var reader = XmlReader.Create(stringReader))
            {
                var records = (List<TEntity>) deserializer.Deserialize(reader);

                Records.Clear();
                Records.AddRange(records);
            }
        }

        public IEnumerable<TEntity> All()
        {
            return Records.ToArray();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            var func = predicate.Compile();
            return Records.Any(func);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            var pred = CreatePredicateFrom(predicate);

            return Records.Find(pred);
        }
    }
}